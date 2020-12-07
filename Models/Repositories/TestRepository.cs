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

                switch (listTest.Count())
                {
                    case 0:
                    entity.Order = 0;
                    entity.Result = 5;
                    entity.I_Index = 1;
                    entity.EF_Index = 1.3f;
                    TimeSpan? i1 = TimeSpan.FromDays(1);
                    entity.NextTime = entity.CreatedTime?.Add(i1 ?? new TimeSpan()) ?? DateTime.Now;
                    break;
                    // case 1:
                    // entity.Order = 1;
                    // entity.I_Index = 6;
                    // TimeSpan? i2 = TimeSpan.FromDays(6);
                    // entity.NextTime = entity.CreatedTime?.Add(i2 ?? new TimeSpan()) ?? DateTime.Now;
                    // break;
                    default:
                    lastTest = listTest[0];
                    entity.Order = lastTest.Order + 1;
                    TimeSpan? interval = entity.CreatedTime - lastTest.CreatedTime;
                    float I_N_Time = Convert.ToSingle(interval?.TotalDays);
                    float EF_N_Time = lastTest.EF_Index;
                    float EF_N1_Time = Convert.ToSingle(EF_N_Time + (0.1-(5-entity.Result)*(0.08+(5-entity.Result)*0.02)));
                    float I_N1_Time = I_N_Time * EF_N1_Time;
                    interval = TimeSpan.FromDays(I_N1_Time);
                    entity.I_Index = I_N1_Time >= 1 ? Convert.ToSingle(Math.Ceiling(I_N1_Time)) : 1;
                    entity.EF_Index = EF_N1_Time >= 1.3 ? EF_N1_Time : 1.3f;
                    entity.ImproveIndex = Convert.ToSingle(entity.EF_Index/lastTest.EF_Index);
                    entity.NextTime = entity.CreatedTime?.Add(interval ?? new TimeSpan()) ?? DateTime.Now;
                    break;
                }

                entities.Add(entity);
                int a = this._context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
            }
        }

        public List<Test> GetTest(int userId, int categoryId) {
            List<Test> result = null;
            try {
                result = entities.Where(p => p.UserId == userId && p.CategoryId == categoryId).ToList();
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
            }
            return result;
        }

        public List<Category> GetNameTest(int userId) {
            List<Category> result = null;
            // List<UserCategory> userCates = null;
            List<int?> cateIdList = null;
            try {
                cateIdList = _context.UserCategories.
                Where(
                    p => p.UserId == userId && (_context.Tests.Where(x => x.UserId == userId && x.CategoryId == p.CategoryId).Count() >= 1)
                ).Select(p => p.CategoryId).ToList();
                result = _context.Categories.Where(p => cateIdList.Contains(p.Id)).ToList();
            }
            catch (System.Exception ex)
            {
                throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
            }
            return result;
        }
    }
}