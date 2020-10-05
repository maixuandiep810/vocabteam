using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class BaseResponse
    {
        [JsonProperty(PropertyName = "success")]
        public int success { get; set; }
        [JsonProperty(PropertyName = "error")]
        public int error { get; set; }
        [JsonProperty(PropertyName = "message")]
        public int message { get; set; }
    }
}