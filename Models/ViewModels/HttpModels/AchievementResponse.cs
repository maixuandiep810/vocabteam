using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class AchievementResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Data")]
        public AchievementModel Data { get; set; }

        public AchievementResponse() : base()
        {
        }

        public AchievementResponse(AchievementModel achievement) : base()
        {
            Data = achievement;
        }
    }
}