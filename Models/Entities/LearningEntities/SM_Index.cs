using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class SM_Index : BaseEntity
    {
        [JsonProperty(PropertyName = "UserId")]
        public int? UserId { get; set; }

        [JsonProperty(PropertyName = "LevelId")]
        public int LevelId { get; set; }

        [JsonProperty(PropertyName = "Order")]
        public int Order { get; set; }

        [JsonProperty(PropertyName = "I_Index")]
        public float I_Index { get; set; }

        [JsonProperty(PropertyName = "EF_Index")]
        public float EF_Index { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        public SM_Index() : base()
        {
            
        }

        public SM_Index(BaseEntity baseEntity) : base(baseEntity)
        {

        }
    }
}