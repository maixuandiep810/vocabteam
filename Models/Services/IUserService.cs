
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
        void Insert(User u);
        void Update(User u);
        void Delete(User u);
        IEnumerable<User> Filter(Expression<Func<User, bool>> filter);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User FindUserByUsername(string username);
        IQueryable<RoleModel> GetRolesOfUser(User user);
        UserModel Insert(RegisterRequest model);
        void Logout(User u);
        // UserInfoResponse GetAll_WithRoles();
    }
}