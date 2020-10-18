using System.Collections.Generic;
using vocabteam.Models.Entities;

namespace vocabteam.Models.Services
{
    public interface IPermissionService
    {
        List<Permission> GetByPermission(Permission permissionInput);
        bool CheckPermission(List<Permission> permissionConform, User user);
        bool CheckPermission(Permission permission, User user);
        
    }
}