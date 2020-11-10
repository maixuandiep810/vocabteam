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
        public double Result { get; set; }
        [JsonProperty(PropertyName = "Result")]
        public double N_Index { get; set; }
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