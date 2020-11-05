using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class Add_NUser_NRoleRequest : Add_N_N_Request<OneUser_NRole>
    {
        [JsonProperty(PropertyName = "List")]
        public List<OneUser_NRole> List { get; set; }
    }

    public class OneUser_NRole : One_N_Model
    {
        [JsonProperty(PropertyName = "UserID")]
        public int AModelId { get; set; }
        
        [JsonProperty(PropertyName = "ListNRoleId")]
        public List<int> ListBModelId { get; set; }
    }
}