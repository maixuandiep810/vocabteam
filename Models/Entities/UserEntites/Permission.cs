using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vocabteam.Models.Entities
{
    public class Permission : BaseEntity
    {
        public string ObjectName { get; set; }
        public string Action { get; set; }
        public virtual List<RolePermission> RolePermissions { get; set; }
        public virtual List<UserPermission> UserPermissions { get; set; }

        public Permission() : base()
        {
            
        }

        public Permission(BaseEntity baseEntity) : base(baseEntity)
        {
            
        }

    }
}