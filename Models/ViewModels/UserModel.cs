using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class UserModel
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty(PropertyName = "roles")]
        public List<RoleModel> Roles { get; set; }
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        public UserModel()
        {
        }
        
        public UserModel(User u, string token)
        {
            Username = u.Username;
            Email = u.Email;
            AvatarUrl = u.AvatarUrl;
            Token = token;
        }
    }
}