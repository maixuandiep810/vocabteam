using System.Net.Mime;

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
    public class TestRepository : MySqlRepository<Test>, ITestRepository
    {
        public TestRepository(VocabteamContext context) : base(context)
        {
        }
        public void InsertIncludeOrder(Test entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                entity.CreatedTime = DateTime.Now;
                entity.UpdatedTime = DateTime.Now;
                Test lastTest = null;
                List<Test> listTest = entities.Where(p => p.CategoryId == entity.CategoryId).OrderByDescending(p => p.UpdatedTime).ToList();

                if (listTest.Count() > 0)
                {
                    lastTest = listTest[0];
                    entity.Order = lastTest.Order + 1;

                    // entity.N_Index = entity.UpdatedTime
                    TimeSpan? interval = entity.CreatedTime - lastTest.CreatedTime;
                    float totalDays = Convert.ToSingle(interval?.TotalDays);
                    entity.N_Index = Convert.ToSingle(-totalDays / Math.Log(entity.Result));
                }
                else
                {
                    entity.Order = 0;
                    entity.Result = 100;
                }
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