using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace Crawling
{
    public partial class Form1 : Form
    {
        ChromeDriver driver;
        Mssql ms = new Mssql();
        List<string> hrefs;//해당 사이트주소 저장
        string SerchUrl = "https://search.naver.com/search.naver?where=news&ie=utf8&sm=nws_hty&query=";
        public Form1()
        {
            InitializeComponent();
        }
        
        private void ChromeDriverSetting()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();

            string user_agent = "--user-agent=Mozilla/5.0 (Linux; Android 9; SM-G975F) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.83 Mobile Safari/537.36";
            //options.AddArgument(user_agent);

            //options.AddArgument("headless");//브라우저 비활성화
            options.AddArgument("disable-gpu");
            options.AddArgument("--mute-audio");

            driver = new ChromeDriver(driverService, options);
        }

        private void BtnKeyword_Click(object sender, EventArgs e)
        {
            Serch();
        }
        private void Serch()
        {
            //현재 테스트용으로 10페이지까지만 검색.
            int NowPage = 1;
            driver.Navigate().GoToUrl(SerchUrl + TxtKeyword.Text);
            while (true)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));

                var ui = driver.FindElement(By.XPath("//*[@id=\"main_pack\"]/section[1]/div/div[2]/ul"));

                foreach (var view in ui.FindElements(By.ClassName("bx")))
                {
                    var _title = view.FindElement(By.ClassName("news_tit"));


                    //추후 사이트이름으로 특정 뉴스사만 제외하고 저장할수있게 기능 추가예정. 22.09.06
                    string title = _title.Text;//기사제목
                    string sitename = view.FindElement(By.ClassName("thumb_box")).Text;//뉴스 홈페이지 이름
                    string href = _title.GetAttribute("href");//기사 링크

                    //DB에 데이터 저장
                    string query = $"INSERT INTO SEARCH(KEYWORD,TITLE,HREF,SITENAME) VALUES ('{TxtKeyword.Text}','{title.Replace("'","")}','{href}','{sitename}');";
                    ms.SendQuery(query);
                }

                var pagenumbers = driver.FindElement(By.ClassName("sc_page_inner")).FindElements(By.TagName("a"));
                bool Checknextpage = true;//다음페이지가 없을경우 계속 True값을 유지하기때문에 자동으로 반복문이 나가진다.
                foreach (var page in pagenumbers)
                {
                    if ((NowPage + 1) == Convert.ToInt32(page.Text))
                    {
                        Checknextpage = false;
                        //다음페이지로
                        NowPage++;

                        //해당페이지를 클릭으로 넘어가지않고 엔터로 넘어감.
                        //가끔씩 클릭오류가 발생하기때문에
                        page.SendKeys(OpenQA.Selenium.Keys.Enter);
                        break;
                    }
                }
                if (NowPage > 10)
                    break;

                if (Checknextpage)
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ChromeDriverSetting();
        }

        private void TxtKeyword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                Serch();
            }
        }

        private void BtnDBRefresh_Click(object sender, EventArgs e)
        {
            LbSearchList.Items.Clear();
            string query = "SELECT DISTINCT KEYWORD FROM SEARCH";
            ms.ReadData(query);
            while (ms.rdr.Read())
            {
                LbSearchList.Items.Add(ms.rdr["KEYWORD"].ToString());
            }
            ms.RdrClose();
        }

        private void LbSearchList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //더블클릭했을때 선택된 아이템이 없을경우 종료
            if (((ListBox)sender).SelectedIndex == -1)
                return;
            LbTitles.Items.Clear();
            string query = $"SELECT * FROM SEARCH WHERE KEYWORD = '{LbSearchList.Items[LbSearchList.SelectedIndex].ToString()}'";
            hrefs = new List<string>();
            ms.ReadData(query);
            while (ms.rdr.Read())
            {
                LbTitles.Items.Add(ms.rdr["TITLE"].ToString());//타이틀 출력
                hrefs.Add(ms.rdr["HREF"].ToString());//링크값 저장
            }
            ms.RdrClose();
        }

        private void LbTitles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //더블클릭했을때 선택된 아이템이 없을경우 종료
            int index = ((ListBox)sender).SelectedIndex;
            if ( index == -1)
                return;

            //해당 주소로 이동시킴
            driver.Navigate().GoToUrl(hrefs[index]);

        }
    }
}
