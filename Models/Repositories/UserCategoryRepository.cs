
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

        public List<UserCategoryModel> GetByUser(int userId, int? levelId, bool? isDifficult, bool? isTodoTest)
        {
            List<UserCategoryModel> result = new List<UserCategoryModel>();
            try
            {
                List<UserCategory> listUserCate = null;
                if (isDifficult == null)
                {
                    listUserCate = _context.UserCategories.Where(p => p.UserId == userId).ToList();
                }
                else
                {
                    listUserCate = _context.UserCategories.Where(p => p.UserId == userId && p.IsDifficult == isDifficult).ToList();
                }
                foreach (UserCategory item in listUserCate)
                {
                    var userCategoryModel = new UserCategoryModel(item);

                    Category cate = null;
                    Test test = null;

                    if (levelId == null)
                    {
                        cate = _context.Categories.Where(p => p.Id == item.CategoryId).FirstOrDefault();
                    }
                    else
                    {
                        cate = _context.Categories.Where(p => p.Id == item.CategoryId && p.LevelId == levelId).FirstOrDefault();
                    }

                    if (cate == null)
                    {
                        break;
                    }
                    else
                    {
                        userCategoryModel.setCategory(cate);
                    }

                    if (isTodoTest != null) // HAVE DONE TEST >= 1 TIME
                    {
                        if (isTodoTest == false) // ALL
                        {
                            test = _context.Tests.Where(p => p.Id == item.CategoryId).OrderByDescending(p => p.Order).FirstOrDefault();
                        }
                        else if (isTodoTest == true) // TODO TEST
                        {
                            test = _context.Tests.Where(p => p.Id == item.CategoryId && p.NextTime >= DateTime.UtcNow).OrderByDescending(p => p.Order).FirstOrDefault();
                        }
                        if (test == null)
                        {
                            break;
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

        // public List<UserCategoryModel> GetByLevelUser(int levelId, int userId)
        // {
        //     List<UserCategoryModel> result = new List<UserCategoryModel>();
        //     try
        //     {
        //         List<UserCategory> listUserCate = _context.UserCategories.Where(p => p.UserId == userId).ToList();
        //         foreach (UserCategory item in listUserCate)
        //         {
        //             Category cate = _context.Categories.Where(p => p.Id == item.CategoryId).FirstOrDefault();
        //             var userCategoryModel = new UserCategoryModel(item, cate);
        //             result.Add(userCategoryModel);
        //         }
        //     }
        //     catch (System.Exception)
        //     {
        //         throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
        //     }

        //     return result;
        // }


    }
}