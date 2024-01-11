namespace BackOnyx.Models
{
    public class GamedModel
    {
        public int Time { get; private set; }
        public int NumPart { get; private set; }

        public GamedModel(int time, int numPart)
        {
            Time = time;
            NumPart = numPart;
        }
    }
}
