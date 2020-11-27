using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class UserCategoryResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Data")]
        public ListUserCategoryModel Data { get; set; }

        public UserCategoryResponse() : base()
        {
        }

        public UserCategoryResponse(ListUserCategoryModel list) : base()
        {
            Data = list;
        }

        public UserCategoryResponse(ListUserCategoryModel list, BaseResponse baseRes) : base(baseRes)
        {
            Data = list;
        }
    }
}