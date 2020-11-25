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
    public interface IUserSettingService
    { 
        IQueryable<UserSetting> GetAll();
        List<UserSetting> GetSetting_ToDoTest(int userId);
        UserSetting GetById(int id);
        void Insert(UserSetting u);
        void Update(UserSetting u);
        void Delete(UserSetting u);
        IEnumerable<UserSetting> Filter(Expression<Func<UserSetting, bool>> filter);
    }
}