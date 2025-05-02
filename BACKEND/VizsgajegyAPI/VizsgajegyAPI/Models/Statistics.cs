namespace VizsgajegyAPI.Models
{
    public class Statistics
    {
        public double Average { get; set; }
        public double Median { get; set; }
        public int Mode { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public Dictionary<string, int> Distribution { get; set; }

    }
}
