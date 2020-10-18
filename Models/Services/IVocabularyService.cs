
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
    public interface IVocabularyService
    { 
        IQueryable<Vocabulary> GetAll();
        Vocabulary GetById(int id);
        void Insert(Vocabulary entity);
        void Update(Vocabulary entity);
        void Delete(Vocabulary entity);
        IEnumerable<Vocabulary> Filter(Expression<Func<Vocabulary, bool>> filter);
    }
}