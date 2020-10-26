using System;
using Newtonsoft.Json;


namespace vocabteam.Models.ViewModels
{
    public class BaseModel
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Active")]
        public bool Active { get; set; }
        [JsonProperty(PropertyName = "UpdatedTime")]
        public DateTime? UpdatedTime { get; set; }
        [JsonProperty(PropertyName = "CreatedTime")]
        public DateTime? CreatedTime { get; set; }
    }
}