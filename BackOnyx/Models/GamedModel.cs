namespace BackOnyx.Models
{
    public class GamedModel
    {
        private readonly int _time;
        private readonly int _numPart;

        public GamedModel (int time, int numPart)
        {
            _time = time;
            _numPart = numPart;
        }

        public int getTime ()
        {
            return _time;
        }
        public int getNumPart ()
        {
            return _numPart;
        }
    }
}
