using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class AchievementModel
    {
        [JsonProperty(PropertyName = "Topics")]
        public int Topics { get; set; }

        [JsonProperty(PropertyName = "LongTermTopics")]
        public int LongTermTopics { get; set; }

        public AchievementModel()
        {

        }
    }
}