using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class UserInfoResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Data")]
        public UserModel Data { get; set; }

        public UserInfoResponse() : base()
        {
        }

        public UserInfoResponse(UserModel user) : base()
        {
            Data = user;
        }

        public UserInfoResponse(UserModel user, BaseResponse baseRes) : base(baseRes)
        {
            Data = user;
        }
    }
}