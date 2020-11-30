using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class UserCategoryModel : Category
    {
        [JsonProperty(PropertyName = "UserId")]
        public int? UserId { get; set; }


        [JsonProperty(PropertyName = "CategoryId")]
        public int? CategoryId { get; set; }


        [JsonProperty(PropertyName = "IsDifficult")]
        public bool IsDifficult { get; set; }


        [JsonProperty(PropertyName = "IsCustomCategory")]
        public bool IsCustomCategory { get; set; }


        [JsonProperty(PropertyName = "IsTested")]
        public bool IsTested { get; set; }


        [JsonProperty(PropertyName = "NextTime")]
        public DateTime? NextTime { get; set; }


        [JsonProperty(PropertyName = "Days")]
        public int? Days { get; set; }



        public UserCategoryModel() : base()
        {
        }

        public UserCategoryModel(UserCategory userCate) : base(userCate)
        {
            setUserCategory(userCate);
        }

        public UserCategoryModel(UserCategory userCate, Category cate) : base(userCate)
        {
            setUserCategory(userCate);
            setCategory(cate);
        }

        public void setCategory(Category cate)
        {
            CategoryId = cate.Id;
            Name = cate.Name;
            ImageUrl = cate.ImageUrl;
            LevelId = cate.LevelId;
        }
        public void setUserCategory(UserCategory userCate)
        {
            UserId = userCate.UserId;
            IsCustomCategory = userCate.IsCustomCategory;
            IsDifficult = userCate.IsDifficult;
        }
        public void setTest(Test test)
        {
            IsTested = true;
            NextTime = test.NextTime;
            DateTime now = DateTime.UtcNow;
            TimeSpan timeSpan = test.NextTime.Subtract(now);
            Days = timeSpan.Days;
        }
    }
}