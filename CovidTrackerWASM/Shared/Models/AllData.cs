namespace CovidTrackerWASM.Shared.Models
{
    public class AllData
    {
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public long Updated { get; set; }
    }
}