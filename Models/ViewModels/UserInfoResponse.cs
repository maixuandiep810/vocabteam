using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class UserInfoResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data")]
        public UserModel data { get; set; }

        public UserInfoResponse()
        {
        }

        public UserInfoResponse(UserModel user)
        {
            data = user;
        }

        public UserInfoResponse(UserModel user, BaseResponse baseRes)
        {
            data = user;
            success = baseRes.success;
            code = baseRes.code;
            message = baseRes.message;
        }
    }
}