using Newtonsoft.Json;

namespace QuranGuide.Models
{
    public class Verse
    {
        [JsonProperty]
        private int number { get; set; }

        [JsonProperty]
        public int numberInSurah { get; set; }

        [JsonProperty]
        public string text { get; set; }

        [JsonProperty]
        public Surah surah { get; set; }


    }
}
