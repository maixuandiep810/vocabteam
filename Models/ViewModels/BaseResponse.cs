using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class BaseResponse
    {
        [JsonProperty(PropertyName = "Code")]
        public int Code { get; set; }
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }
        public BaseResponse(int code = 0, string message = "")
        {
            Code = code;
            Message = message;
        }

        public BaseResponse(BaseResponse baseRes)
        {
            Code = baseRes.Code;
            Message = baseRes.Message;         
        }
    }
}