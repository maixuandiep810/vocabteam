using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class RoleModel
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "DisplayName")]
        public string Displayname { get; set; }
    }
}