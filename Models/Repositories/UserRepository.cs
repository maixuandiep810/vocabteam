
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

        public IQueryable<RoleModel> GetRolesOfUser(int id)
        {
            IQueryable<RoleModel> result = null;
            try
            {
                result = (from p in _context.Users
                          join m in _context.UserRoles on p.Id equals m.UserId
                          join x in _context.Roles on m.RoleId equals x.Id
                          where p.Id == id
                          select new RoleModel
                          {
                              Name = x.Name,
                              Displayname = x.DisplayName
                          });
            }
            catch (RepositoryException001 ex)
            {
                throw ex;
            }

            return result;
        }

        public List<UserModel> GetAll_WithRoles()
        {
            List<UserModel> result = null;
            try
            {
                var query = from p in _context.Users
                            join m in _context.UserRoles on p.Id equals m.UserId
                            join x in _context.Roles on m.RoleId equals x.Id
                            select new { User = p, UserRole = m, Roles = x };
                var data = query.ToLookup(p => p.User).ToList();
                result = new List<UserModel>();
                foreach (var iGroup in data)
                {
                    var newUser = new UserModel
                    {
                        Username = iGroup.Key.Username,
                        Email = iGroup.Key.Email,
                        AvatarUrl = iGroup.Key.AvatarUrl,
                        Roles = new List<RoleModel>()
                    };
                    foreach (var item in iGroup)
                    {
                        var newRole = new RoleModel()
                        {
                            Name = item.Roles.Name,
                            Displayname = item.Roles.DisplayName
                        };
                        newUser.Roles.Add(newRole);
                    }
                    result.Add(newUser);
                }
            }
            catch (RepositoryException001 ex)
            {
                throw ex;
            }
            return result;
        }

        public void AddToken(User u)
        {
            try
            {
                Update(u);
            }
            catch (RepositoryException001 ex)
            {
                throw ex;
            }
        }

    }
}