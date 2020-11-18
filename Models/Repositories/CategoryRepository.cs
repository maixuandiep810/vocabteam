
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
using vocabteam.Helpers.CustomExceptions;

namespace vocabteam.Models.Repositories
{
    public class CategoryRepository : MySqlRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(VocabteamContext context) : base(context)
        {
        }

        public List<Category> GetByLevel(int levelId)
        {
            List<Category> result;
            try
            {
                result = _context.Categories.Where(p => p.LevelId == levelId).ToList();
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
            }

            return result;
        }
 
    }
}