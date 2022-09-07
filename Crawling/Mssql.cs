

using System.Data.SqlClient;

namespace Crawling
{
    class Mssql
    {
        //서버연결 정보
        SqlConnection con;

        //DB 커맨드 보낼때
        SqlCommand cmd;

        //쿼리를 보낸후 데이터 받는 역할
        public SqlDataReader rdr;

        //접속할 서버 주소
        string ServerIP;
        //접속할 데이터베이스 이름
        string DataBase;
        //서버접속 아이디
        string ServerID;
        //서버접속 비밀번호
        string ServerPW;

        //********22.07.20 Mssql 외부접속 확인.********
        public Mssql(string IP = "", string DBbase = "", string ID = "", string PW = "")
        {
            //서버 정보를 갱신함
            ServerIP = IP;
            DataBase = DBbase;
            ServerID = ID;
            ServerPW = PW;

            con = new SqlConnection($"Server={ServerIP};database={DataBase};Uid={ServerID};Pwd={ServerPW}");
            con.Open();
        }

        public object GetQueryCnt(string str)
        {
            //해당 쿼리문의 개수를 알아낸다
            cmd = new SqlCommand(str, con);
            return cmd.ExecuteScalar();
        }

        public void SendQuery(string str)
        {
            //전달받은 쿼리문을 보낸다.
            cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
        }
        public void ReadData(string str)
        {
            //해당 쿼리를 보내 데이터를 읽어서 필요한부분에서 데이터 처리를해서 사용한다.
            cmd = new SqlCommand(str, con);
            rdr = cmd.ExecuteReader();
        }

        public void RdrClose()
        {
            //쿼리 보낸후 데이터를 다받고 처리후에 꺼주지않으면 에러가 났음.
            rdr.Close();
        }

        public void ConClose()
        {
            //서버 연결 종료
            con.Close();
        }

    }
}
