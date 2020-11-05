using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using vocabteam.Models.Entities;
using vocabteam.Models.ViewModels;

namespace vocabteam.Models.Services
{
    public interface IRoleService
    {
        IQueryable<Role> GetAll();
        Role GetById(int id);
        void Insert(Role role);
        void Update(Role role);
        void Delete(Role role);
        IEnumerable<Role> Filter(Expression<Func<Role, bool>> filter);

        ///
        /// ROLE_PERMISSION SERVICES
        ///
        void Insert(UserRole userRole);
        void Add_NUser_NRole(Add_NUser_NRoleRequest reqModel);
    }
}