using System.Data.SqlClient;

namespace DemoAPI.Db
{
    public class DbSqlserver
    {
        static SqlConnection _sqlConnection;
          public DbSqlserver()
        {
            if (_sqlConnection == null)
            {
                _sqlConnection = new SqlConnection
                               (@"Server=.\sql2019,9999;database=Db2023MemesLight;user=UserDb2023MemesLight;password=UserDb2023MemesLight");
            }
     }

        public static SqlConnection SqlConnection { get => _sqlConnection; set => _sqlConnection = value; }

        public SqlDataReader Get(string query)
        {
            try
            {
                if (_sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    _sqlConnection.Open();
                }
                using (SqlCommand cmd = _sqlConnection.CreateCommand())
                {
                    cmd.CommandText = query;
                    return cmd.ExecuteReader();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T GetScalar<T>(string query)
        {
            try
            {
                if (_sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    _sqlConnection.Open();
                }
                using (SqlCommand cmd = _sqlConnection.CreateCommand())
                {
                    cmd.CommandText = query;
                    return (T)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Insert(string query)
        {
            int resultat = -1;
            try
            {
                if (_sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    _sqlConnection.Open();
                }
                using (SqlCommand cmd = _sqlConnection.CreateCommand())
                {
                    cmd.CommandText = query;
                    resultat = cmd.ExecuteNonQuery();

                }
                _sqlConnection.Close();

            }
            catch (Exception ex)
            {

            }
            return resultat;
        }

    }
}
