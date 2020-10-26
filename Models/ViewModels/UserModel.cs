using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class UserModel : User
    {
        [JsonProperty(PropertyName = "Roles")]
        public List<RoleModel> Roles { get; set; }

        public UserModel() : base()
        {
            
        }

        public UserModel(User u) : base(u)
        {
            Id = u.Id;
            Username = u.Username;
            Email = u.Email;
            AvatarUrl = u.AvatarUrl;
            Token = u.Token;
        }

    }
}