using BackOnyx.Models;
using MySql.Data.MySqlClient;

namespace BackOnyx.DB
{
    public class Gamed
    {
        private MySqlConnection _connection;

        public Gamed(MySqlConnection connection) 
        {
            _connection = connection;
        }

        public void addGamed(GamedModel gamed)
        {
            _connection.Open();

            string requette = "INSERT INTO gamed (crono, num_part) values (@crono, @num_part)";

            MySqlCommand cmd = new MySqlCommand(requette, _connection);
            cmd.Parameters.AddWithValue("@crono", gamed.Time);
            cmd.Parameters.AddWithValue("@num_part", gamed.NumPart);

            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        

        public int getBestGamed(int numPart)
        {
            _connection.Open();

            string requette = "SELECT min(crono) FROM gamed WHERE num_part = @num_part";
            MySqlCommand cmd = new MySqlCommand(requette, _connection);
            cmd.Parameters.AddWithValue("@num_part", numPart);
            MySqlDataReader data = cmd.ExecuteReader();

            if (data.Read() && !data.IsDBNull(0))
            {
                
                int maxValue =  data.GetInt32(0);

                _connection.Close();
                return maxValue;
            }

            _connection.Close();
            return -1;
        }


        public int getAverageGamed (int numPart)
        {
            _connection.Open();

            string requette = "SELECT avg(crono) FROM gamed WHERE num_part = @num_part";
            MySqlCommand cmd = new MySqlCommand(requette, _connection);
            cmd.Parameters.AddWithValue("@num_part", numPart);
            MySqlDataReader data = cmd.ExecuteReader();

            if (data.Read() && !data.IsDBNull(0))
            {

                int maxValue = data.GetInt32(0);

                _connection.Close();
                return maxValue;
            }

            _connection.Close();
            return -1;
        }

        

    }
}
