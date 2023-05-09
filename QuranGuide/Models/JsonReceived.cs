using Newtonsoft.Json;

namespace QuranGuide.Models
{
    public class JsonReceived
    {
        [JsonProperty]
        private int code {get; set;}
        [JsonProperty]
        private string status { get; set;}

        [JsonProperty]
        public Data data { get; set;}



    }
}
