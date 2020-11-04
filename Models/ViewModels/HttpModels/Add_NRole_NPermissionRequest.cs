using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class Add_NRole_NPermissonRequest : Add_N_N_Request<OneRole_NPermission>
    {
        [JsonProperty(PropertyName = "List")]
        public List<OneRole_NPermission> List { get; set; }
    }

    public class OneRole_NPermission : One_N_Model
    {
        [JsonProperty(PropertyName = "RoleId")]
        public int AModelId { get; set; }
        
        [JsonProperty(PropertyName = "ListNPermissionId")]
        public List<int> ListBModelId { get; set; }
    }
}