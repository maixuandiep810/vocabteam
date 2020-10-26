using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class ListCategoryModel
    {
        [JsonProperty(PropertyName = "List")]
        public List<CategoryModel> ListCategory { get; set; }

        public ListCategoryModel(List<Category> list)
        {
            ListCategory = getListCategoryModel(list);
        }

        // HELPER
        private List<CategoryModel> getListCategoryModel(List<Category> list)
        {
            List<CategoryModel> result = new List<CategoryModel>();
            foreach (var item in list)
            {
                var itemModel = new CategoryModel(item);
                result.Add(itemModel);
            }
            return result;
        }
    }
}