namespace BackOnyx.Models
{
    public class GamehModel
    {
        private readonly string _userName;
        private readonly DateTime _date;
        private readonly int _averageTime;
        private readonly int _bestTime;

        public GamehModel(string userName, DateTime date, int averageTime, int bestTime)
        {
            _userName = userName;
            _date = date;
            _averageTime = averageTime;
            _bestTime = bestTime;
        }
        
        public string getUserName()
        {
            return _userName;
        }

        public DateTime getDate()
        {
            return _date;
        }

        public int getAverageTime()
        {
            return _averageTime;
        }

        public int getBestTime() 
        {
            return _bestTime;   
        }

    }
}
