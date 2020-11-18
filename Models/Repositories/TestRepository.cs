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
                    entity.I_Index = I_N1_Time;
                    entity.EF_Index = EF_N1_Time >= 1.3 ? EF_N1_Time : 1.3f;
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
    }
}