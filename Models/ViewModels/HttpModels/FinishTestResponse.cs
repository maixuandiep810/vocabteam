using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class FinishTestResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Data")]
        public TestModel Data { get; set; }

        public FinishTestResponse() : base()
        {
        }

        public FinishTestResponse(TestModel testModel) : base()
        {
            Data = testModel;
        }

        public FinishTestResponse(TestModel testModel, BaseResponse baseRes) : base(baseRes)
        {
            Data = testModel;
        }
    }
}