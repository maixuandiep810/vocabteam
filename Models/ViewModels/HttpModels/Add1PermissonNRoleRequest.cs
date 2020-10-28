using System.Collections.Generic;
using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class Add1PermissonNRoleRequest
    {
        [JsonProperty(PropertyName = "PermissionId")]
        public string PermissionId { get; set; }
        
        [JsonProperty(PropertyName = "ListNRole")]
        public List<string> ListNRole { get; set; }
    }
}