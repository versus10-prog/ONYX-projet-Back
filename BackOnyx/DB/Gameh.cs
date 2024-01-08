using BackOnyx.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;


namespace BackOnyx.DB
{
    public class Gameh
    {
        private MySqlConnection _connection;

        public Gameh(MySqlConnection connection)
        {
            _connection = connection;
        }

        public void addGameh(GamehModel gamehM)
        {
            _connection.Open();

            string requette = "INSERT INTO gameh (best_time, average_time, date, user_name) VALUES (@best_time, @average_time, @date, @user_name)";
            
            MySqlCommand cmd = new MySqlCommand(requette, _connection);
            cmd.Parameters.AddWithValue("@user_name", gamehM.getUserName());
            cmd.Parameters.AddWithValue("@best_time", gamehM.getBestTime());
            cmd.Parameters.AddWithValue("@average_time", gamehM.getAverageTime());
            cmd.Parameters.AddWithValue("@date", gamehM.getDate());

            cmd.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Object> getBestScore() 
        {
            _connection.Open();
            List<Object> listeBest = new List<Object>();
            string requete = "SELECT user_name, average_time, best_time, date FROM gameh ORDER BY average_time ASC LIMIT 5";

            MySqlCommand cmd = new MySqlCommand(requete, _connection);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                string userName = data["user_name"].ToString();
                int average_time = Convert.ToInt32(data["average_time"]);
                int best_time = Convert.ToInt32(data["best_time"]);
                DateTime date = Convert.ToDateTime(data["date"]);

                List<Object> list = [userName, average_time, best_time, date];

                listeBest.Add(list);
            }

            _connection.Close();

            return listeBest;

        }
    }
}
