using System.Collections.Generic;
using System.Linq;
using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;
using System.Text.RegularExpressions;

namespace vocabteam.Models.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _PermissionRepo;

        public PermissionService(IPermissionRepository permissionRepo)
        {
            _PermissionRepo = permissionRepo;
        }

        public List<Permission> GetByPermission(Permission permissionInput) {
            IEnumerable<Permission> permissions =_PermissionRepo.Filter(p => p.Action == permissionInput.Action);
            List<Permission> permissionsConform = new List<Permission>();
            foreach (var item in permissions)
            {
                var a = permissionInput.ObjectName;
                var b = item.ObjectName;
                var c = Regex.IsMatch(a, b);
                if (Regex.IsMatch(permissionInput.ObjectName, item.ObjectName))
                {
                    permissionsConform.Add(item);
                }   
            }
            return permissionsConform;
        }

        public bool CheckPermission(List<Permission> permissionConform, User user) {
            foreach (var item in permissionConform)
            {
                if (_PermissionRepo.CheckPermission(item, user))
                {
                    return true;   
                }
            }
            return false;
        }

        public bool CheckPermission(Permission permission, User user) {
            List<Permission> permissionConform = GetByPermission(permission);
            foreach (var item in permissionConform)
            {
                if (_PermissionRepo.CheckPermission(item, user))
                {
                    return true;   
                }
            }
            return false;
        }
    }
}