using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class UserResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data")]
        public UserViewModel data { get; set; }      
    }
}