using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using vocabteam.Models.Entities;
using vocabteam.Models.ViewModels;

namespace vocabteam.Models.Services
{
    public interface IPermissionService
    {
        IQueryable<Permission> GetAll();
        Permission GetById(int id);
        void Insert(Permission perm);
        void Update(Permission perm);
        void Delete(Permission perm);
        IEnumerable<Permission> Filter(Expression<Func<Permission, bool>> filter);

        List<Permission> GetByPermission(Permission permissionInput);
        bool CheckPermission(List<Permission> permissionConform, User user);
        bool CheckPermission(Permission permission, User user);

        ///
        /// ROLE_PERMISSION SERVICES
        ///
        void Insert(RolePermission rolePerm);
        void Add_NRole_NPermisson(Add_NRole_NPermissonRequest reqModel);
    }
}