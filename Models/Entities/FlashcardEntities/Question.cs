using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class Question : BaseEntity
    {
        [JsonProperty(PropertyName = "FirstAnswer")]
        public string FirstAnswer { get; set; }
        [JsonProperty(PropertyName = "SecondAnswer")]
        public string SecondAnswer { get; set; }
        [JsonProperty(PropertyName = "ThirdAnswer")]
        public string ThirdAnswer { get; set; }
        [JsonProperty(PropertyName = "VocabularyId")]
        public int? VocabularyId { get; set; }
        [JsonIgnore]
        public virtual Vocabulary Vocabulary { get; set; }


        public Question() : base()
        {

        }

        public Question(BaseEntity baseEntity) : base(baseEntity)
        {

        }
    }
}