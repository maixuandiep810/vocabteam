using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class TestSettingResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Data")]
        public ListTestSettingModel Data { get; set; }

        public TestSettingResponse() : base()
        {
        }

        public TestSettingResponse(ListTestSettingModel list) : base()
        {
            Data = list;
        }

        public TestSettingResponse(ListTestSettingModel list, BaseResponse baseRes) : base(baseRes)
        {
            Data = list;
        }
    }
}