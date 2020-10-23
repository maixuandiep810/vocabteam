using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class AuthenticateRequest
    {
        [JsonProperty(PropertyName = "username")]

        public string Username { get; set; }
        [JsonProperty(PropertyName = "password")]

        public string Password { get; set; }
    }
}