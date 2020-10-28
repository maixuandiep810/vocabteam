using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;
using vocabteam.Helpers;

namespace vocabteam.Models.ViewModels
{
    public class ListPermissionModel
    {
        [JsonProperty(PropertyName = "List")]
        public List<PermissionModel> ListPermission { get; set; }

        public ListPermissionModel(List<Permission> list)
        {
            ListPermission = 
            TransformEntityModel.getListTransformEntityModel<Permission, PermissionModel>(list);
        }

        // HELPER
    }
}