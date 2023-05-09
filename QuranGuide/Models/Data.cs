using Newtonsoft.Json;

namespace QuranGuide.Models
{
    public class Data
    {
        [JsonProperty]
        private int count { get; set; }
        [JsonProperty]
        public List<Verse> matches { get; set; }   
    }
}
