
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
    public class UserCategoryService : IUserCategoryService
    {
        private readonly ICategoryRepository _CategoryRepo;
        private readonly IUserCategoryRepository _UserCategoryRepo;
        private readonly IUserSettingRepository _UserSettingRepo;
        private readonly AppSettings _AppSettings;

        public UserCategoryService(ICategoryRepository categoryRepo, IUserCategoryRepository userCategoryRepo, IUserSettingRepository userSettingRepo, IOptions<AppSettings> appSettings)
        {
            _CategoryRepo = categoryRepo;
            _UserCategoryRepo = userCategoryRepo;
            _UserSettingRepo = userSettingRepo;
            _AppSettings = appSettings.Value;

        }
        public IQueryable<UserCategory> GetAll()
        {
            IQueryable<UserCategory> result = null;
            try
            {
                result = _UserCategoryRepo.GetAll();
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
        public UserCategory GetById(int id)
        {
            UserCategory result = null;
            try
            {
                result = _UserCategoryRepo.GetById(id);
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
        public void Insert(UserCategory userCate)
        {
            try
            {
                _UserCategoryRepo.Insert(userCate);

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
        public void Update(UserCategory userCate)
        {
            try
            {
                _UserCategoryRepo.Update(userCate);

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
        public void Delete(UserCategory userCate)
        {
            try
            {
                _UserCategoryRepo.Delete(userCate);

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

        public IEnumerable<UserCategory> Filter(Expression<Func<UserCategory, bool>> filter)
        {
            IEnumerable<UserCategory> result = null;
            try
            {
                result = _UserCategoryRepo.Filter(filter);

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

        public List<UserCategoryModel> GetByUser(int userId, int? levelId, bool? isDifficult, bool? isTodoTest)
        {
            List<UserCategoryModel> result = null;
            try
            {
                result = _UserCategoryRepo.GetByUser(userId, levelId, isDifficult, isTodoTest);
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