using System.Configuration;

namespace NavigatingAzure
{
    public interface IGeoConfiguration 
    {
        string Location { get; set; }
    }

    public class GeoConfiguration : IGeoConfiguration 
    {
        public string Location { get; set; }
    }
}