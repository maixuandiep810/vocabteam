using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class CategoryResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Data")]
        public ListCategoryModel Data { get; set; }

        public CategoryResponse() : base()
        {
        }

        public CategoryResponse(ListCategoryModel list) : base()
        {
            Data = list;
        }

        public CategoryResponse(ListCategoryModel list, BaseResponse baseRes) : base(baseRes)
        {
            Data = list;
        }
    }
}