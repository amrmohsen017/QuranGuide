using Newtonsoft.Json;

namespace QuranGuide.Models
{
    public class Surah
    {
        [JsonProperty]
        private int number { get; set; }
        [JsonProperty]
        public string name { get; set; }
        [JsonProperty]
        private string revelation_type { get; set; }
    }
}
