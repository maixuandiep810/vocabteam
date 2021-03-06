
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;
using vocabteam.Models.ViewModels;

namespace vocabteam.Models.Repositories
{
    public interface IUserCategoryRepository : IRepository<UserCategory>
    {
        List<UserCategoryModel> GetByUser(int userId, int levelIdValue, int isDifficultValue, int isTodoTestValue);
        int getAchievement(int userId);
    }
}