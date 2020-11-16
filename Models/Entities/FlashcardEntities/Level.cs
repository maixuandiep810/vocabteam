using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class Level : BaseEntity
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual List<Category> Categories { get; set; }

        public Level() : base()
        {

        }

        public Level(BaseEntity baseEntity) : base(baseEntity)
        {

        }
    }
}