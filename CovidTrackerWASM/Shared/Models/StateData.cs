namespace CovidTrackerWASM.Shared.Models
{
    public class StateData
    {
        public string State { get; set; }
        public int Cases { get; set; }
        public int TodayCases { get; set; }
        public int Deaths { get; set; }
        public int TodayDeaths { get; set; }
        public int Active { get; set; }
    }
}