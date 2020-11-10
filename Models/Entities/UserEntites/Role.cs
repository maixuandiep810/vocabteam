using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vocabteam.Models.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<RolePermission> RolePermissions { get; set; }

        public Role() : base()
        {
            
        }

        public Role(BaseEntity baseEntity) : base(baseEntity)
        {
            
        }
    }
}