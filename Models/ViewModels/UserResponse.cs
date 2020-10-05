using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class UserResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data")]
        public UserResponse_Data data { get; set; }      
    }

    public class UserResponse_Data {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty(PropertyName = "user_roles")]
        public string UserRoles { get; set; }
    }
}