using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class Vocabulary : BaseEntity
    {
        [JsonProperty(PropertyName = "Word")]
        public string Word { get; set; }
        [JsonProperty(PropertyName = "Meaning")]
        public string Meaning { get; set; }
        [JsonProperty(PropertyName = "Definition")]
        public string Definition { get; set; }
        [JsonProperty(PropertyName = "Sentence")]
        public string Sentence { get; set; }
        [JsonProperty(PropertyName = "AudioUrl")]
        public string AudioUrl { get; set; }
        [JsonProperty(PropertyName = "ImageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "CategoryId")]
        public int? CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonProperty(PropertyName = "Questions")]
        public virtual List<Question> Questions { get; set; }

        public Vocabulary() : base()
        {
            
        }

        public Vocabulary(BaseEntity baseEntity) : base(baseEntity)
        {
            
        }
    }
}