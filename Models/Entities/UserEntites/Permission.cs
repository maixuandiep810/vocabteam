using System.Text.Json.Serialization;

namespace vocabteam.Models.Entities
{
    public class Permission : BaseEntity
    {
        public string Table { get; set; }
        public string Action { get; set; }
    }
}