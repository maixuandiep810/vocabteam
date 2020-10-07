
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
    public class PermisisonRepository : MySqlRepository<Permission>, IPermissionRepository
    {

        public PermisisonRepository(VocabteamContext context) : base(context)
        {
        }

        public bool CheckPermission(Permission per, User user)
        {
            var query = from p in _context.Permissions
                        join m in _context.RolePermissions on p.Id equals m.PermissionId
                        join x in _context.Roles on m.RoleId equals x.Id
                        join y in _context.UserRoles on x.Id equals y.RoleId
                        join t in _context.Users on y.UserId equals t.Id
                        where (p.Id == per.Id && t.Id == user.Id)
                        select new { Permission = p, User = t};
            return query.Count() > 0 ? true : false;
        }

        // public List GetUserByPermission(Permission per)
        // {
        //     var query = from p in _context.Permissions
        //                 join m in _context.RolePermissions on p.Id equals m.PermissionId
        //                 join x in _context.Roles on m.RoleId equals x.Id
        //                 join y in _context.UserRoles on x.Id equals y.RoleId
        //                 join t in _context.Users on y.UserId equals t.Id
        //                 select new { Permission = p, User = t};
        //     var data = query.ToLookup(p => p.Permission).ToList();
        // }
    }
}