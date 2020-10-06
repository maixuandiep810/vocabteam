using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class RoleViewModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "display_name")]
        public string Displayname { get; set; }
    }
}