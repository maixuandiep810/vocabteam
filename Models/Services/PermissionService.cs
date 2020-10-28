using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using vocabteam.Helpers.CustomExceptions;
using System.Linq.Expressions;
using System;

using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;
using vocabteam.Models.ViewModels;

namespace vocabteam.Models.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _PermissionRepo;
        private readonly IRolePermissionRepository _RolePermissionRepo;


        public PermissionService(IPermissionRepository permissionRepo, IRolePermissionRepository rolePermissionRepo)
        {
            _PermissionRepo = permissionRepo;
            _RolePermissionRepo = rolePermissionRepo;
        }

        public IQueryable<Permission> GetAll()
        {
            IQueryable<Permission> result = null;
            try
            {
                result = _PermissionRepo.GetAll();
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            return result;
        }
        public Permission GetById(int id)
        {
            Permission result = null;
            try
            {
                result = _PermissionRepo.GetById(id);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            return result;
        }
        public void Insert(Permission perm)
        {
            try
            {
                _PermissionRepo.Insert(perm);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
        }
        public void Update(Permission perm)
        {
            try
            {
                _PermissionRepo.Update(perm);

            }
            catch (CustomException ex)
            {
                throw ex;
            }
        }
        public void Delete(Permission perm)
        {
            try
            {
                _PermissionRepo.Delete(perm);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Permission> Filter(Expression<Func<Permission, bool>> filter)
        {
            IEnumerable<Permission> result = null;
            try
            {
                result = _PermissionRepo.Filter(filter);

            }
            catch (CustomException ex)
            {
                throw ex;
            }
            return result;
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



        ///
        /// ROLE_PERMISSION REPOSITORY
        ///

        public void InsertRolePermission(RolePermission rolePerm)
        {
            try
            {
                _RolePermissionRepo.Insert(rolePerm);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
        }

        public void Add1PermissionNRole(Add1PermissonNRoleRequest reqModel)
        {
            string permId = reqModel.PermissionId;
            List<string> listNRole = reqModel.ListNRole;
            try
            {
                foreach (var item in listNRole)
                {
                    RolePermission newRolePermission = new RolePermission()
                    {
                        PermissionId = Convert.ToInt32(permId),
                        RoleId = Convert.ToInt32(item)
                    };
                    InsertRolePermission(newRolePermission);
                }
            }
            catch (CustomException ex)
            { 
                throw ex;
            }
        }
    }
}