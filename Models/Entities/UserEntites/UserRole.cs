using System.Text.Json.Serialization;

namespace vocabteam.Models.Entities
{
    public class UserRole : BaseEntity
    {
        public int? UserId { get; set; }
        
        public virtual User User { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

        public UserRole() : base()
        {
            
        }

        public UserRole(UserRole ur) : base(ur)
        {
            
        }

        public UserRole(int userId, int roleId) 
        {
            UserId = userId;
            RoleId = roleId;
        }

    }
}