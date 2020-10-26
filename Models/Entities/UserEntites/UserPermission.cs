using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vocabteam.Models.Entities
{
    public class UserPermission : BaseEntity
    {
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? PermissionId { get; set; }
        public virtual Permission Permission { get; set;}

        public UserPermission() : base()
        {
            
        }

        public UserPermission(UserPermission up) : base (up)
        {
            
        }
    }
}