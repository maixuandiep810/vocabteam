using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class BaseResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool success { get; set; }
        [JsonProperty(PropertyName = "code")]
        public int code { get; set; }
        [JsonProperty(PropertyName = "message")]
        public int message { get; set; }
    }
}