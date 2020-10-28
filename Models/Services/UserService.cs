
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepo;
        private readonly AppSettings _AppSettings;

        public UserService(IUserRepository userRepo, IOptions<AppSettings> appSettings)
        {
            _UserRepo = userRepo;
            _AppSettings = appSettings.Value;

        }
        public IQueryable<User> GetAll()
        {
            IQueryable<User> result = null;
            try
            {
                result = _UserRepo.GetAll();
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
        public User GetById(int id)
        {
            User result = null;
            try
            {
                result = _UserRepo.GetById(id);
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
        public void Insert(User u)
        {
            try
            {
                _UserRepo.Insert(u);
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
        public void Update(User u)
        {
            try
            {
                _UserRepo.Update(u);
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
        public void Delete(User u)
        {
            try
            {
                _UserRepo.Delete(u);
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

        public IEnumerable<User> Filter(Expression<Func<User, bool>> filter)
        {
            IEnumerable<User> result = null;
            try
            {
                result = _UserRepo.Filter(filter);
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

        public IQueryable<RoleModel> GetRolesOfUser(User user)
        {
            IQueryable<RoleModel> result = null;
            try
            {
                result = _UserRepo.GetRolesOfUser(user.Id);

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

        // public UserInfoResponse GetAll_WithRoles() {
        //     var input = _UserRepo.GetAll_WithRoles();
        //     var result = new UserInfoResponse();
        //     result.data.Roles= input;
        //     return result;
        // }


        public UserModel Authenticate(AuthenticateRequest model)
        {
            User user = null;
            String token = null;
            try
            {
                user = _UserRepo.Filter(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault<User>();
                if (user == null) return null;
                token = generateJwtToken(user);
                user.Token = token;
                Update(user);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return new UserModel(user);
        }

        public User FindUserByUsername(string username)
        {
            User user = null;
            try
            {
                user = _UserRepo.Filter(x => x.Username == username).FirstOrDefault<User>();
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return user;
        }

        public UserModel Insert(RegisterRequest model)
        {
            User user = null;
            try
            {
                var insertUser = new User()
                {
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email
                };
                this.Insert(insertUser);
                user = _UserRepo.Filter(x => x.Username == insertUser.Username && x.Password == insertUser.Password).FirstOrDefault<User>();
                if (user == null) return null;
                var token = generateJwtToken(user);
                user.Token = token;
                Update(user);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return new UserModel(user);
        }

        public void Logout(User u)
        {
            try
            {
                u.Token = null;
                Update(u);
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



        ///
        /// HELPER 
        /// 

        private string generateJwtToken(User user) 
        {
            // generate token that is valid for 365 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(365),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}