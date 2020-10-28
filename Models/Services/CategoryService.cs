
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
        private readonly AppSettings _AppSettings;

        public CategoryService(ICategoryRepository categoryRepo, IOptions<AppSettings> appSettings)
        {
            _CategoryRepo = categoryRepo;
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

    }
}