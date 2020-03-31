using System.Text.Json.Serialization;

namespace CovidTrackerWASM.Shared.Models
{
    public class CountryInfo
    {
        [JsonIgnore]
        public int? Id { get; set; }

        public double Lat { get; set; }
        public double Long { get; set; }
        public string Flag { get; set; }
        public string Iso3 { get; set; }
        public string Iso2 { get; set; }
    }

    public class CountryData
    {
        public string Country { get; set; }
        public CountryInfo CountryInfo { get; set; }
        public int Cases { get; set; }
        public int TodayCases { get; set; }
        public int Deaths { get; set; }
        public int TodayDeaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public long? Critical { get; set; }
        public double? CasesPerOneMillion { get; set; }
        public double? DeathsPerOneMillion { get; set; }
        public long Updated { get; set; }
    }

    public class CountryDropdownItem
    {
        public string Country { get; set; }
        public string Flag { get; set; }
    }
}