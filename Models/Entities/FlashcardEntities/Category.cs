using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class Category : BaseEntity
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "ImageUrl")]
        public string ImageUrl { get; set; }
        [JsonIgnore]
        public virtual List<Vocabulary> Vocabularies { get; set; }
        [JsonIgnore]
        public virtual List<Test> Tests { get; set; }


        public Category() : base()
        {

        }

        public Category(BaseEntity baseEntity) : base(baseEntity)
        {

        }
    }
}