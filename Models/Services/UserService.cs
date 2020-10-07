
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
            return _UserRepo.GetAll();
        }
        public User GetById(int id)
        {
            return _UserRepo.GetById(id);
        }
        public void Insert(User entity, bool saveChange = true)
        {

        }
        public void Update(User entity, bool saveChange = true)
        {

        }
        public void Delete(User entity, bool saveChange = true)
        {

        }

        public IEnumerable<User> Filter(Expression<Func<User, bool>> filter)
        {
            return _UserRepo.Filter(filter);
        }

        public IQueryable<RoleViewModel> GetRolesOfUser(User user) 
        {
            return _UserRepo.GetRolesOfUser(user.Id);
        }

        public UserResponse GetAll_WithRoles() {
            var input = _UserRepo.GetAll_WithRoles();
            var result = new UserResponse();
            result.data = input;
            return result;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _UserRepo.Filter(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault<User>();

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}