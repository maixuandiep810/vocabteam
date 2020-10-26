using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class CategoryModel : BaseModel
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "ImageUrl")]
        public string ImageUrl { get; set; }
        public CategoryModel()
        {
        }
        
        public CategoryModel(Category cate)
        {
            Name = cate.Name;
            Description = cate.Description;
            ImageUrl = cate
        }
    }
}