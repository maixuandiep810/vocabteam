using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;
using vocabteam.Helpers;

namespace vocabteam.Models.ViewModels
{
    public class ListRoleModel
    {
        [JsonProperty(PropertyName = "List")]
        public List<RoleModel> ListRole { get; set; }

        public ListRoleModel(List<Role> list)
        {
            ListRole = 
            TransformEntityModel.getListTransformEntityModel<Role, RoleModel>(list);
        }

        // HELPER
    }
}