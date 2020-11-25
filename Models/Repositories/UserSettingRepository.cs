
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
    public class UserSettingRepository : MySqlRepository<UserSetting>, IUserSettingRepository
    {

        public UserSettingRepository(VocabteamContext context) : base(context)
        {

        }

        public List<UserSetting> GetSetting_ToDoTest()
        {
            UserSetting[] settings = new UserSetting[6];
            List<UserSetting> result;
            try
            {
                result = _context.UserSettings.Where(p => p.Name.StartsWith(ConstantVar.ENUM_UserSettingString(ConstantVar.ENUM_UserSetting.PREFIX_TODOTEST))).ToList();
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
            }

            return result;
        }
    }
}