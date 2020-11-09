
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using vocabteam.Helpers.CustomExceptions;
using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;
using vocabteam.Models.ViewModels;
using vocabteam.Helpers;


namespace vocabteam.Models.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _TestRepo;

        public TestService(ITestRepository testRepo)
        {
            _TestRepo = testRepo;
        }
        public IQueryable<Test> GetAll()
        {
            IQueryable<Test> result = null;
            try
            {
                result = _TestRepo.GetAll();
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.SYSTEM_ERROR);
            }
            return result;
        }


        public Test GetById(int id)
        {
            Test result = null;
            try
            {
                result = _TestRepo.GetById(id);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.SYSTEM_ERROR);
            }
            return result;
        }
        public void Insert(Test entity)
        {
            try
            {
                _TestRepo.Insert(entity);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.SYSTEM_ERROR);
            }
        }
        public void InsertIncludeOrdinalNumber(Test entity)
        {
            try
            {
                _TestRepo.InsertIncludeOrdinalNumber(entity);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.SYSTEM_ERROR);
            }
        }
        public void Update(Test entity)
        {
            try
            {
                _TestRepo.Update(entity);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.SYSTEM_ERROR);
            }
        }
        public void Delete(Test entity)
        {

        }

        public IEnumerable<Test> Filter(Expression<Func<Test, bool>> filter)
        {
            IEnumerable<Test> result = null;
            try
            {
                result = _TestRepo.Filter(filter);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.SYSTEM_ERROR);
            }
            return result;
        }

    }
}


