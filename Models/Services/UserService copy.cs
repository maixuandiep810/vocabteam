
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
    public class VocabularyService : IVocabularyService
    {
        private readonly IVocabularyRepository _VocabularyRepo;

        public VocabularyService(IVocabularyRepository vocabularyRepo)
        {
            _VocabularyRepo = vocabularyRepo;
        }
        public IQueryable<Vocabulary> GetAll()
        {
            return _VocabularyRepo.GetAll();
        }
        public Vocabulary GetById(int id)
        {
            return _VocabularyRepo.GetById(id);
        }
        public void Insert(Vocabulary entity)
        {
            _VocabularyRepo.Insert(entity);
        }
        public void Update(Vocabulary entity, bool saveChange = true)
        {

        }
        public void Delete(Vocabulary entity, bool saveChange = true)
        {

        }

        public IEnumerable<Vocabulary> Filter(Expression<Func<Vocabulary, bool>> filter)
        {
            return _VocabularyRepo.Filter(filter);
        }

    }
}