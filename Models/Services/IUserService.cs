
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;
using vocabteam.Models.ViewModels;

namespace vocabteam.Models.Services
{
    public interface IUserService
    { 
        IQueryable<User> GetAll();
        User GetById(int id, bool isActive = true);
        void Insert(User entity, bool saveChange = true);
        void Update(User entity, bool saveChange = true);
        void Delete(User entity, bool saveChange = true);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}