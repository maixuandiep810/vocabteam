
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
        public List<UserViewModel> GetAll_WithRoles()
        {
            var query = from p in _context.Users
                        join m in _context.UserRoles on p.Id equals m.UserId
                        join x in _context.Roles on m.RoleId equals x.Id
                        select new { User = p, UserRole = m, Roles = x };
            var data = query.ToLookup(p => p.User).ToList();
            var result = new List<UserViewModel>();
            foreach (var iGroup in data)
            {
                var newUser = new UserViewModel()
                {
                    Username = iGroup.Key.Username,
                    Email = iGroup.Key.Email,
                    AvatarUrl = iGroup.Key.AvatarUrl,
                    Roles = new List<RoleViewModel>()
                };
                foreach (var item in iGroup)
                {
                    var newRole = new RoleViewModel()
                    {
                        Name = item.Roles.Name,
                        Displayname = item.Roles.DisplayName
                    };
                    newUser.Roles.Add(newRole);
                }
                result.Add(newUser);
            }
            return result;
        }

    }
}