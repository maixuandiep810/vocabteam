using System.Text.Json.Serialization;

namespace vocabteam.Models.Entities
{
    public class UserRole : BaseEntity
    {
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}