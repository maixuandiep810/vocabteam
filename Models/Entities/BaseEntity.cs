using System;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class BaseEntity
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Active")]
        public bool Active { get; set; }
        [JsonProperty(PropertyName = "UpdatedTime")]
        public DateTime? UpdatedTime { get; set; }
        [JsonProperty(PropertyName = "CreatedTime")]
        public DateTime? CreatedTime { get; set; }

        public BaseEntity()
        {
            Active = true;
            CreatedTime = DateTime.UtcNow;
            UpdatedTime = DateTime.UtcNow;
        }

        public BaseEntity(BaseEntity baseEntity)
        {
            Id = baseEntity.Id;
            CreatedTime = baseEntity.CreatedTime;
            UpdatedTime = baseEntity.UpdatedTime;
        }
    }
}