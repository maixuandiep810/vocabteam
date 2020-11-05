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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _RoleRepo;
        private readonly IUserRoleRepository _UserRoleRepo;


        public RoleService(IRoleRepository roleRepo, IUserRoleRepository userRoleRepo)
        {
            _RoleRepo = roleRepo;
            _UserRoleRepo = userRoleRepo;
        }

        public IQueryable<Role> GetAll()
        {
            IQueryable<Role> result = null;
            try
            {
                result = _RoleRepo.GetAll();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public Role GetById(int id)
        {
            Role result = null;
            try
            {
                result = _RoleRepo.GetById(id);
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
        public void Insert(Role role)
        {
            try
            {
                _RoleRepo.Insert(role);
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
        public void Update(Role role)
        {
            try
            {
                _RoleRepo.Update(role);

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
        public void Delete(Role role)
        {
            try
            {
                _RoleRepo.Delete(role);
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

        public IEnumerable<Role> Filter(Expression<Func<Role, bool>> filter)
        {
            IEnumerable<Role> result = null;
            try
            {
                result = _RoleRepo.Filter(filter);

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


        ///
        /// ROLE_PERMISSION SERVICES
        ///

        public void Insert(UserRole userRole)
        {
            try
            {
                _UserRoleRepo.Insert(userRole);
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

        public void Add_NUser_NRole(Add_NUser_NRoleRequest reqModel)
        {
            try
            {
                ServiceHelper.AddManyManyRecord<UserRole, OneUser_NRole>(Insert, reqModel);
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