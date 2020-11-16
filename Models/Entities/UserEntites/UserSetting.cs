using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.Entities
{
    public class UserSetting : BaseEntity
    {
        [JsonProperty(PropertyName = "UserId")]
        public int? UserId { get; set; }

        [JsonProperty(PropertyName = "A1_ChangeInTime")]
        public int? A1_ChangeInTime { get; set; }

        [JsonProperty(PropertyName = "A2_ChangeInTime")]
        public int? A2_ChangeInTime { get; set; }
        [JsonProperty(PropertyName = "B1_ChangeInTime")]
        public int? B1_ChangeInTime { get; set; }
        [JsonProperty(PropertyName = "B2_ChangeInTime")]
        public int? B2_ChangeInTime { get; set; }
        [JsonProperty(PropertyName = "C1_ChangeInTime")]
        public int? C1_ChangeInTime { get; set; }
        [JsonProperty(PropertyName = "C2_ChangeInTime")]
        public int? C2_ChangeInTime { get; set; }

        public UserSetting() : base()
        {
            A1_ChangeInTime = null;
            A2_ChangeInTime = null;
            B1_ChangeInTime = null;
            B2_ChangeInTime = null;
            C1_ChangeInTime = null;
            C2_ChangeInTime = null;
        }

        public UserSetting(BaseEntity baseEntity) : base(baseEntity)
        {

        }
    }
}