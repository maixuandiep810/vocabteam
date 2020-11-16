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

        [JsonProperty(PropertyName = "LevelId")]
        public int? LevelId { get; set; }

        [JsonProperty(PropertyName = "IsCustomCategory")]
        public bool IsCustomCategory { get; set; }

        [JsonProperty(PropertyName = "UserId")]
        public int? UserId { get; set; }



        [JsonIgnore]
        public virtual List<Vocabulary> Vocabularies { get; set; }

        [JsonIgnore]
        public virtual List<Test> Tests { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        
        [JsonIgnore]
        public virtual Level Level { get; set; }


        public Category() : base()
        {
            IsCustomCategory = false;
        }

        public Category(BaseEntity baseEntity) : base(baseEntity)
        {

        }
    }
}