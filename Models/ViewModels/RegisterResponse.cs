using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class RegisterResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data")]
        public UserViewModel data { get; set; }
    }
}