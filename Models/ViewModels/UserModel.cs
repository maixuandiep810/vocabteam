using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class UserModel : BaseModel
    {
        [JsonProperty(PropertyName = "Username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "AvatarUrl")]
        public string AvatarUrl { get; set; }
        [JsonProperty(PropertyName = "Roles")]
        public List<RoleModel> Roles { get; set; }
        [JsonProperty(PropertyName = "Token")]
        public string Token { get; set; }
        public UserModel()
        {
        }
        
        public UserModel(User u, string token)
        {
            Id = u.Id;
            Username = u.Username;
            Email = u.Email;
            AvatarUrl = u.AvatarUrl;
            Token = token;
        }
    }
}