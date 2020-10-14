using System.Linq;
using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;

namespace vocabteam.Models.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _PermissionRepo;

        public PermissionService(IPermissionRepository permissionRepo)
        {
            _PermissionRepo = permissionRepo;
        }

        public Permission GetByPermission(Permission permissionInput) {
            return _PermissionRepo.Filter(p => p.ObjectName == permissionInput.ObjectName && p.Action == permissionInput.Action).FirstOrDefault<Permission>();
        }

        public bool CheckPermission(Permission permission, User user) {
            return _PermissionRepo.CheckPermission(permission, user);
        }
    }
}