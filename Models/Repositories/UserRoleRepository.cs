
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using vocabteam.Helpers;
using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;
using vocabteam.Models.ViewModels;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace vocabteam.Models.Repositories
{
    public class UserRoleRepository : MySqlRepository<UserRole>, IUserRoleRepository
    {

        public UserRoleRepository(VocabteamContext context) : base(context)
        {
        }
    }
}