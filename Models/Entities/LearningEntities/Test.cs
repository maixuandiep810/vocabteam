using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class Test : BaseEntity
    {
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "CategoryId")]
        public int CategoryId { get; set; }
        [JsonProperty(PropertyName = "OrdinalNumber")]
        public int OrdinalNumber { get; set; }
        [JsonProperty(PropertyName = "Result")]
        public Double Result { get; set; }
        [JsonIgnore]
        public virtual List<Vocabulary> Vocabularies { get; set; }


        public Test() : base()
        {
            
        }

        public Test(BaseEntity baseEntity) : base(baseEntity)
        {
            
        }
    }
}