
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
using Microsoft.AspNetCore.Http;
using vocabteam.Helpers.CustomExceptions;

namespace vocabteam.Models.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepo;
        private readonly IUserCategoryRepository _UserCategoryRepo;
        private readonly IUserSettingRepository _UserSettingRepo;
        private readonly AppSettings _AppSettings;

        public CategoryService(ICategoryRepository categoryRepo, IUserCategoryRepository userCategoryRepo, IUserSettingRepository userSettingRepo, IOptions<AppSettings> appSettings)
        {
            _CategoryRepo = categoryRepo;
            _UserCategoryRepo = userCategoryRepo;
            _UserSettingRepo = userSettingRepo;
            _AppSettings = appSettings.Value;

        }
        public IQueryable<Category> GetAll()
        {
            IQueryable<Category> result = null;
            try
            {
                result = _CategoryRepo.GetAll();
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return result;
        }
        public Category GetById(int id)
        {
            Category result = null;
            try
            {
                result = _CategoryRepo.GetById(id);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return result;
        }
        public void Insert(Category cate)
        {
            try
            {
                if (cate.ImageUrl.Count() == 0)
                {
                    cate.ImageUrl = ConstantVar.CategoryFolder + ConstantVar.ImageFolder + "/" + ConstantVar.DefaultImageCategory;
                }
                _CategoryRepo.Insert(cate);

            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
        }
        public void Update(Category cate)
        {
            try
            {
                _CategoryRepo.Update(cate);

            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
        }
        public void Delete(Category cate)
        {
            try
            {
                _CategoryRepo.Delete(cate);

            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
        }

        public IEnumerable<Category> Filter(Expression<Func<Category, bool>> filter)
        {
            IEnumerable<Category> result = null;
            try
            {
                result = _CategoryRepo.Filter(filter);

            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public List<Category> GetByLevel(int levelId)
        {
            List<Category> result = null;
            try
            {
                result = _CategoryRepo.GetByLevel(levelId);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public List<UserCategoryModel> GetByUser(int userId, int? levelId, bool? isDifficult)
        {
            List<UserCategoryModel> result = null;
            try
            {
                result = _UserCategoryRepo.GetByUser(userId, levelId, isDifficult);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public List<Category> GetBySetting_HaveToDoTest(int levelId)
        {
            List<Category> result = null;
            try
            {
                result = _CategoryRepo.GetByLevel(levelId);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return result;
        }

    }
}














        // public List<UserCategoryModel> GetByLevelUser(int levelId, int userId)
        // {
        //     List<UserCategoryModel> result = null;
        //     try
        //     {
        //         result = _UserCategoryRepo.GetByLevelUser(levelId, userId);
        //     }
        //     catch (CustomException ex)
        //     {
        //         throw ex;
        //     }
        //     catch (System.Exception ex)
        //     {
        //         throw ex; 
        //     }
        //     return result;
        // }