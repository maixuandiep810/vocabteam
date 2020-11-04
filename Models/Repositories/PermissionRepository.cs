using System.Linq;
using vocabteam.Helpers;
using vocabteam.Models.Entities;
using System.Collections.Generic;
using vocabteam.Helpers.CustomExceptions;

namespace vocabteam.Models.Repositories
{
    public class PermissionRepository : MySqlRepository<Permission>, IPermissionRepository
    {

        public PermissionRepository(VocabteamContext context) : base(context)
        {
        }

        public bool CheckPermission(Permission per, User user)
        {
            try 
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
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
            }
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