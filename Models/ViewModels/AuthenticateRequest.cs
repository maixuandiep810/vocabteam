using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class AuthenticateRequest
    {
        [JsonProperty(PropertyName = "Username")]

        public string Username { get; set; }
        [JsonProperty(PropertyName = "Password")]

        public string Password { get; set; }
    }
}