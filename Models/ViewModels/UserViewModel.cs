using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class UserViewModel
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty(PropertyName = "roles")]
        public List<RoleViewModel> Roles { get; set; }
        public UserViewModel(User u)
        {
            Username = u.Username;
            Email = u.Email;
            AvatarUrl = u.AvatarUrl;
        }
    }
}