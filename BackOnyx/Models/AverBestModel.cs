namespace BackOnyx.Models
{
    public class AverBestModel
    {
        public int Average { get; private set; }
        public int Best { get; private set; }

        public int NumPart { get; private set; }

        public AverBestModel(int average, int best, int numPart)
        {
            Average = average;
            Best = best;
            NumPart = numPart;
        }
    }
}
