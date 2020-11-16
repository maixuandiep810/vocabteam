using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class N_Index : BaseEntity
    {
        [JsonProperty(PropertyName = "UserId")]
        public int? UserId { get; set; }

        [JsonProperty(PropertyName = "LevelId")]
        public int LevelId { get; set; }

        [JsonProperty(PropertyName = "Order")]
        public int Order { get; set; }

        [JsonProperty(PropertyName = "Index")]
        public float Index { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        public N_Index() : base()
        {
            
        }

        public N_Index(BaseEntity baseEntity) : base(baseEntity)
        {

        }
    }
}