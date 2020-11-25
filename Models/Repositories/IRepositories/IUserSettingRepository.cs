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
    public interface IUserSettingRepository :IRepository<UserSetting>
    {
        public List<UserSetting> GetSetting_ToDoTest(int userId);
    }
}