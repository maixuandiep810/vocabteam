
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
    public interface IUserRepository :IRepository<User>
    {
        IQueryable<RoleViewModel> GetRolesOfUser(int id);
        List<UserViewModel> GetAll_WithRoles();
    }
}