
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
    public interface IUserService
    { 
        IQueryable<User> GetAll();
        User GetById(int id);
        void Insert(User entity);
        void Update(User entity, bool saveChange = true);
        void Delete(User entity, bool saveChange = true);
        IEnumerable<User> Filter(Expression<Func<User, bool>> filter);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User FindUserByUsername(string username);
        IQueryable<RoleModel> GetRolesOfUser(User user);
        UserModel Insert(RegisterRequest model);
        // UserInfoResponse GetAll_WithRoles();
    }
}