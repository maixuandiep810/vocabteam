
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
    public interface ICategoryService
    { 
        IQueryable<Category> GetAll();
        Category GetById(int id);
        void Insert(Category u);
        void Update(Category u);
        void Delete(Category u);
        IEnumerable<Category> Filter(Expression<Func<Category, bool>> filter);
        List<Category> GetByLevel(int levelId);
        List<Category> GetBySetting_HaveToDoTest(int levelId);
    }
}