using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class PermissionResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Data")]
        public ListPermissionModel Data { get; set; }

        public PermissionResponse() : base()
        {
        }

        public PermissionResponse(ListPermissionModel list) : base()
        {
            Data = list;
        }

        public PermissionResponse(ListPermissionModel list, BaseResponse baseRes) : base(baseRes)
        {
            Data = list;
        }
    }
}