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
        [JsonProperty(PropertyName = "OrdinalNumber")]
        public int OrdinalNumber { get; set; }
        [JsonProperty(PropertyName = "Result")]
        public float Result { get; set; }
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