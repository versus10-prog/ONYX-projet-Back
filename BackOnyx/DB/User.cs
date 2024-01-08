using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Sections;
using MySql.Data.MySqlClient;

namespace BackOnyx.DB
{
    public class User
    {

        private MySqlConnection _connection;

        public User(MySqlConnection connection)
        {

            _connection = connection;
        }

        public bool UserExist(string userName)
        {
            _connection.Open();

            string requete = "Select count(user_name) from user where user_name = @userName";

            MySqlCommand cmd = new MySqlCommand(requete, _connection);
            cmd.Parameters.AddWithValue("@userName", userName);
            int nb = Convert.ToInt32( cmd.ExecuteScalar());
            
            _connection.Close();

            if (nb > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void AddUser(string userName)
        {
            _connection.Open();


            string requete = "INSERT INTO user (user_name, password) VALUES (@user_name, @password)";

            MySqlCommand cmd = new MySqlCommand(requete, _connection);
            cmd.Parameters.AddWithValue("@user_name", userName);
            cmd.Parameters.AddWithValue("@password", "test");

            cmd.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
