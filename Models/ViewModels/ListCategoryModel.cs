using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;
using vocabteam.Helpers;


namespace vocabteam.Models.ViewModels
{
    public class ListCategoryModel
    {
        [JsonProperty(PropertyName = "List")]
        public List<CategoryModel> ListCategory { get; set; }

        public ListCategoryModel(List<Category> list)
        {
            ListCategory =
            TransformEntityModel.getListTransformEntityModel<Category, CategoryModel>(list);
        }
    }
}