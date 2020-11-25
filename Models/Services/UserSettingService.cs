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
using vocabteam.Helpers.CustomExceptions;

namespace vocabteam.Models.Services
{
    public class UserSettingService : IUserSettingService
    {
        private readonly IUserSettingRepository _UserSettingRepo;
        private readonly AppSettings _AppSettings;

        public UserSettingService(IUserSettingRepository userSettingRepo, IOptions<AppSettings> appSettings)
        {
            _UserSettingRepo = userSettingRepo;
            _AppSettings = appSettings.Value;

        }
        public IQueryable<UserSetting> GetAll()
        {
            IQueryable<UserSetting> result = null;
            try
            {
                result = _UserSettingRepo.GetAll();
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
        public List<UserSetting> GetSetting_ToDoTest(int userId)
        {
            List<UserSetting> result = null;
            try
            {
                result = _UserSettingRepo.GetSetting_ToDoTest(userId);
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
        public UserSetting GetById(int id)
        {
            UserSetting result = null;
            try
            {
                result = _UserSettingRepo.GetById(id);
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
        public void Insert(UserSetting u)
        {
            try
            {
                _UserSettingRepo.Insert(u);
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
        public void Update(UserSetting u)
        {
            try
            {
                _UserSettingRepo.Update(u);
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
        public void Delete(UserSetting u)
        {
            try
            {
                _UserSettingRepo.Delete(u);
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

        public IEnumerable<UserSetting> Filter(Expression<Func<UserSetting, bool>> filter)
        {
            IEnumerable<UserSetting> result = null;
            try
            {
                result = _UserSettingRepo.Filter(filter);
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