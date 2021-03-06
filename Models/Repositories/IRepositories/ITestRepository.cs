
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using vocabteam.Models.Entities;
using vocabteam.Models.Repositories;
using vocabteam.Models.ViewModels;

namespace vocabteam.Models.Repositories
{
    public interface ITestRepository :IRepository<Test>
    {
        void InsertIncludeOrder(Test entity);
        List<Test> GetTest(int userId, int categoryId);
        List<Category> GetNameTest(int userId);
    }
}