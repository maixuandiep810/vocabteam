
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using vocabteam.Helpers;
using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;
using vocabteam.Models.ViewModels;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace vocabteam.Models.Repositories
{
    public class UserRepository : MySqlRepository<User>, IUserRepository
    {

        public UserRepository(VocabteamContext context) : base(context)
        {
        }
        public IQueryable<RoleViewModel> GetRolesOfUser(int id)
        {
            var result = (from p in _context.Users
                     join m in _context.UserRoles on p.Id equals m.UserId
                     join x in _context.Roles on m.RoleId equals x.Id
                     where p.Id == id
                     select new RoleViewModel
                     {
                        Name = x.Name,
                        Displayname = x.DisplayName
                     });
            return result;
        }
        public IQueryable GetAll_WithRoles() 
        {
            var result = from p in _context.Users
                     join m in _context.UserRoles on p.Id equals m.UserId
                     join x in _context.Roles on m.RoleId equals x.Id
                     group p by p.Id into userWithRoles
                     select userWithRoles;
            return result;
        }

    }
}