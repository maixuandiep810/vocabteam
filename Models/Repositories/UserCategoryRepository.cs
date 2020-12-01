
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
    public class UserCategoryRepository : MySqlRepository<UserCategory>, IUserCategoryRepository
    {

        public UserCategoryRepository(VocabteamContext context) : base(context)
        {
        }

        // isDifficultValue = 0, - ALL
        // levelIdValue = 0, - ALL
        // isTodoTestValue = 0, - ALL
        public List<UserCategoryModel> GetByUser(int userId, int levelIdValue, int isDifficultValue, int isTodoTestValue)
        {
            List<UserCategoryModel> result = new List<UserCategoryModel>();
            try
            {
                List<UserCategory> listUserCate = null;
                if (isDifficultValue == 0)
                {
                    listUserCate = _context.UserCategories.Where(p => p.UserId == userId).ToList();
                }
                else if (isDifficultValue == 1)
                {
                    listUserCate = _context.UserCategories.Where(p => p.UserId == userId && p.IsDifficult == true).ToList();
                }
                foreach (UserCategory item in listUserCate)
                {
                    var userCategoryModel = new UserCategoryModel(item);

                    Category cate = null;
                    Test test = null;

                    if (levelIdValue == 0) 
                    {
                        cate = _context.Categories.Where(p => p.Id == item.CategoryId).FirstOrDefault();
                    }
                    else
                    {
                        cate = _context.Categories.Where(p => p.Id == item.CategoryId && p.LevelId == levelIdValue).FirstOrDefault();
                    }

                    if (cate == null)
                    {
                        continue;
                    }
                    else
                    {
                        userCategoryModel.setCategory(cate);
                    }

                    if (isTodoTestValue != 0) // HAVE DONE TEST >= 1 TIME
                    {
                        if (isTodoTestValue == 1) // ALL
                        {
                            test = _context.Tests.Where(p => p.CategoryId == item.CategoryId && p.UserId == item.UserId).OrderByDescending(p => p.Order).FirstOrDefault();
                        }
                        else if (isTodoTestValue == 2) // TODO TEST
                        {
                            test = _context.Tests.Where(p => p.CategoryId == item.CategoryId && p.UserId == item.UserId && p.NextTime <= DateTime.UtcNow).OrderByDescending(p => p.Order).FirstOrDefault();
                        }
                        if (test == null)
                        {
                            continue;
                        }
                        userCategoryModel.setTest(test);
                    }

                    result.Add(userCategoryModel);
                }
            }
            catch (System.Exception ex)
            {
                throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
            }

            return result;
        }

        public int getAchievement(int userId)
        {
            AchievementModel achievement = new AchievementModel();
            try 
            {
                int topicCount = _context.UserCategories.Where(p => p.UserId == userId).GroupBy(p => p.CategoryId).Count();
                // achievement.Topics = topicCount;
                // int longTerm
                return topicCount;
            }
            catch (System.Exception ex)
            {
                throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
            }
        }







    }
}