using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class Test : BaseEntity
    {
        [JsonProperty(PropertyName = "UserId")]
        public int? UserId { get; set; }
        [JsonProperty(PropertyName = "CategoryId")]
        public int? CategoryId { get; set; }
        [JsonProperty(PropertyName = "Order")]
        public int Order { get; set; }
        [JsonProperty(PropertyName = "Result")]
        public float Result { get; set; }
        [JsonProperty(PropertyName = "I_Index")]
        public float I_Index { get; set; }
        [JsonProperty(PropertyName = "EF_Index")]
        public float EF_Index { get; set; }
        [JsonProperty(PropertyName = "NextTime")]
        public DateTime NextTime { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }


        public Test() : base()
        {

        }

        public Test(BaseEntity baseEntity) : base(baseEntity)
        {

        }
    }
}