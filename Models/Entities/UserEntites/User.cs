using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class User : BaseEntity
    {
        [JsonProperty(PropertyName = "Username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "AvatarUrl")]
        public string AvatarUrl { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "Token")]
        public string Token { get; set; }
        [JsonIgnore]
        public virtual List<UserRole> UserRoles { get; set; }
        [JsonIgnore]
        public virtual List<UserPermission> UserPermissions { get; set; }
        [JsonIgnore]
        public virtual List<Test> Tests { get; set; }

        public User() : base()
        {

        }

        public User(BaseEntity baseEntity) : base(baseEntity)
        {

        }
    }
}