using BackOnyx.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using static Google.Protobuf.Reflection.UninterpretedOption.Types;


namespace BackOnyx.DB
{
    public class Gameh
    {
        private MySqlConnection _connection;

        public Gameh(MySqlConnection connection)
        {
            _connection = connection;
        }

        public int addGameh(GamehModel gamehM)
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
            int numPart = this.getNumPart();

            

            return numPart;
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

        public int getNumPart()
        {
            int numPart = -1;

            try
            {
                _connection.Open();
            
                string requette = "SELECT LAST_INSERT_ID() AS num_click";
                MySqlCommand cmd = new MySqlCommand(requette, _connection);

                object data = cmd.ExecuteScalar();
                if (data != null)
                {
                    numPart = Convert.ToInt32(data);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
            finally { _connection.Close(); }
            
            return numPart;
        }

        public void putData(int numPart, int bestTime, int averageTime)
        {
            try
            {
                _connection.Open();
                string requette = "UPDATE gameh SET best_time = @best_time, average_time = @average_time where num_part = @num_part";
                MySqlCommand cmd = new MySqlCommand(requette, _connection);
                cmd.Parameters.AddWithValue("@best_time", bestTime);
                cmd.Parameters.AddWithValue("@average_time", averageTime);
                cmd.Parameters.AddWithValue("@num_part", numPart);
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("erreur :  "+ ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
