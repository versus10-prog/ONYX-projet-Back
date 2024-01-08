using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;

namespace BackOnyx.DB
{
    public class Config
    {
        private static string ConnectionString = 
            "Server=localhost;" +
            "Database=onyx_db;" +
            "User Id=root;" +
            "Password=root;";

        private static MySqlConnection connection = null;

        private Config()
        {
            connection = new MySqlConnection(ConnectionString);
        } 

        public static MySqlConnection configInstance()
        {
            if(connection == null)
            {
                new Config();
            }
            return connection;
        }

    }
}

