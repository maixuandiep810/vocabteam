using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class GetTestResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Data")]
        public ListTestModel Data { get; set; }

        public GetTestResponse() : base()
        {
        }

        public GetTestResponse(ListTestModel list) : base()
        {
            Data = list;
        }

        public GetTestResponse(ListTestModel list, BaseResponse baseRes) : base(baseRes)
        {
            Data = list;
        }
    }
}