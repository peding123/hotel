using System.Data.SqlClient;

namespace hotel
{
    internal class connect
    {
        public SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection("Data Source=FPC-01\\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True");
            return conn;
        }
    }
}
