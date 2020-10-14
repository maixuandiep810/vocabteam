using vocabteam.Models.Entities;

namespace vocabteam.Models.Services
{
    public interface IPermissionService
    {
        Permission GetByPermission(Permission permissionInput);
        bool CheckPermission(Permission permission, User user);
        
    }
}