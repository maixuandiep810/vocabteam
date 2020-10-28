
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;

namespace vocabteam.Models.Repositories
{
    public interface IPermissionRepository :IRepository<Permission>
    {
        bool CheckPermission(Permission per, User user);
    }
}