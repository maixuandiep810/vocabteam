using System.Net.Mime;

using System;
using System.
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
    public class TestRepository : MySqlRepository<Test>, ITestRepository
    {
        public TestRepository(VocabteamContext context) : base(context)
        {
        }
        public void InsertIncludeOrdinalNumber(Test entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                int maxId = entities.OrderByDescending(p => p.UpdatedTime).ToList()[0].Id;

                entity.Order = entities.Where(p => p.CategoryId == entity.CategoryId).Count() + 1;
                entity.CreatedTime = DateTime.Now;
                entity.UpdatedTime = DateTime.Now;
                Test lastTest = GetById(maxId);
                entity.N_Index = entity.UpdatedTime
                entities.Add(entity);
                int a = this._context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
            }
        }
    }
}