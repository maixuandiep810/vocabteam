using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class UserSetting : BaseEntity
    {
        [JsonProperty(PropertyName = "UserId")]
        public int? UserId { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }

        public UserSetting() : base()
        {
            
        }

        public UserSetting(BaseEntity baseEntity) : base(baseEntity)
        {

        }
    }
}