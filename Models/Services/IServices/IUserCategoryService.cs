
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;
using vocabteam.Models.ViewModels;

namespace vocabteam.Models.Services
{
    public interface IUserCategoryService
    { 
        IQueryable<UserCategory> GetAll();
        UserCategory GetById(int id);
        void Insert(UserCategory u);
        void Update(UserCategory u);
        void Delete(UserCategory u);
        IEnumerable<UserCategory> Filter(Expression<Func<UserCategory, bool>> filter);
        List<UserCategoryModel> GetByUser(int userId, int levelIdValue, int isDifficultValue, int isTodoTestValue);
        int getAchievement(int userId);
    }
}