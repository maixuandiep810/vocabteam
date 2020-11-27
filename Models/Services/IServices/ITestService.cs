
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;
using vocabteam.Models.ViewModels;

namespace vocabteam.Models.Services
{
    public interface ITestService
    {
        IQueryable<Test> GetAll();
        Test GetById(int id);
        void Insert(Test entity);
        Test InsertIncludeOrder(Test entity);
        void Update(Test entity);
        void Delete(Test entity);
        IEnumerable<Test> Filter(Expression<Func<Test, bool>> filter);

    }
}