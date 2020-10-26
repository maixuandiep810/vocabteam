using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class CategoryModel : Category
    {
        public CategoryModel() : base()
        {
        }
        
        public CategoryModel(Category cate) : base(cate)
        {
            Name = cate.Name;
            Description = cate.Description;
            ImageUrl = cate.ImageUrl;
        }
    }
}