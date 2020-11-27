using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vocabteam.Models.Entities
{
    public class UserCategory : BaseEntity
    {
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public bool IsCustomCategory { get; set; }
        public bool IsDifficult { get; set; }
        public virtual User User { get; set; }
        public virtual Category Category { get; set;}

        public UserCategory() : base()
        {
            
        }

        public UserCategory(UserPermission up) : base (up)
        {
            
        }
    }
}