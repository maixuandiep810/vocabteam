using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using vocabteam.Helpers.CustomExceptions;
using System.Linq.Expressions;
using System;

using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;
using vocabteam.Models.ViewModels;
using vocabteam.Helpers;

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
            catch (System.Exception ex)
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
            catch (System.Exception ex)
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
            catch (System.Exception ex)
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
            catch (System.Exception ex)
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
            catch (System.Exception ex)
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
            catch (System.Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<Permission> GetByPermission(Permission permissionInput)
        {
            try
            {
                IEnumerable<Permission> permissions = _PermissionRepo.Filter(p => p.Action == permissionInput.Action);
                List<Permission> permissionsConfirm = new List<Permission>();
                foreach (var item in permissions)
                {
                    var a = permissionInput.ObjectName;
                    var b = item.ObjectName;
                    var c = Regex.IsMatch(a, b);
                    if (Regex.IsMatch(permissionInput.ObjectName, item.ObjectName))
                    {
                        permissionsConfirm.Add(item);
                    }
                }
                return permissionsConfirm;
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckPermission(List<Permission> permissionConfirm, User user)
        {
            try
            {
                foreach (var item in permissionConfirm)
                {
                    if (_PermissionRepo.CheckPermission(item, user))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckPermission(Permission permission, User user)
        {
            try
            {
                List<Permission> permissionConfirm = GetByPermission(permission);
                foreach (var item in permissionConfirm)
                {
                    if (_PermissionRepo.CheckPermission(item, user))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }



        ///
        /// ROLE_PERMISSION SERVICES
        ///

        public void Insert(RolePermission rolePerm)
        {
            try
            {
                _RolePermissionRepo.Insert(rolePerm);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Add_NRole_NPermisson(Add_NRole_NPermissonRequest reqModel)
        {
            try
            {
                ServiceHelper.AddManyManyRecord<RolePermission, OneRole_NPermission>(Insert, reqModel);
            }
            catch (CustomException ex)
            {
                 throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}