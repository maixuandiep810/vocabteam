using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;
using vocabteam.Helpers;


namespace vocabteam.Models.ViewModels
{
    public class ListUserCategoryModel
    {
        [JsonProperty(PropertyName = "List")]
        public List<UserCategoryModel> ListUserCategory { get; set; }

        public ListUserCategoryModel(List<UserCategoryModel> list)
        {
            ListUserCategory = list;
        }
    }
}