using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class UserCategoryModel : Category
    {
        public int? UserId { get; set; }
        public bool IsDifficult { get; set; }
        public bool IsCustomCategory { get; set; }
        public UserCategoryModel() : base()
        {
        }

        public UserCategoryModel(UserCategory userCate, Category cate) : base(userCate)
        {
            setUserCategory(userCate);
            setCategory(cate);
        }

        public void setCategory(Category cate)
        {
            Name = cate.Name;
            ImageUrl = cate.ImageUrl;
        }
        public void setUserCategory(UserCategory userCate)
        {
            IsCustomCategory = userCate.IsCustomCategory;
            IsDifficult = userCate.IsDifficult;
        }
    }
}