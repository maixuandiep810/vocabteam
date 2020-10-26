using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vocabteam.Models.Entities
{
    public class RolePermission : BaseEntity
    {
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int? PermissionId { get; set; }
        public virtual Permission Permission { get; set;}

        public RolePermission() : base()
        {
            
        }

        public RolePermission(BaseEntity baseEntity) : base(baseEntity)
        {
            
        }
    }
}