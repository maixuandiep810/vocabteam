
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

        public List<UserCategoryModel> GetByUser(int userId, int? levelId, bool? isDifficult)
        {
            List<UserCategoryModel> result = new List<UserCategoryModel>();
            try
            {
                List<UserCategory> listUserCate = null;
                if (isDifficult == null)
                {
                    _context.UserCategories.Where(p => p.UserId == userId).ToList();
                }
                else 
                {
                    _context.UserCategories.Where(p => p.UserId == userId && p.IsDifficult == isDifficult).ToList();
                }
                foreach (UserCategory item in listUserCate)
                {
                    Category cate = null;
                    if (levelId == null)
                    {
                        _context.Categories.Where(p => p.Id == item.CategoryId).FirstOrDefault();
                    }
                    else 
                    {
                        _context.Categories.Where(p => p.Id == item.CategoryId && p.LevelId == levelId).FirstOrDefault();
                    }
                    var userCategoryModel = new UserCategoryModel(item, cate);
                    result.Add(userCategoryModel);
                }
            }
            catch (System.Exception)
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