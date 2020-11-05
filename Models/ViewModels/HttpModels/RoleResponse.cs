using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class RoleResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Data")]
        public ListRoleModel Data { get; set; }

        public RoleResponse() : base()
        {
        }

        public RoleResponse(ListRoleModel list) : base()
        {
            Data = list;
        }

        public RoleResponse(ListRoleModel list, BaseResponse baseRes) : base(baseRes)
        {
            Data = list;
        }
    }
}