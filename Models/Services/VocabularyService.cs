
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
    public class VocabularyService : IVocabularyService
    {
        private readonly IVocabularyRepository _VocabularyRepo;

        public VocabularyService(IVocabularyRepository vocabularyRepo)
        {
            _VocabularyRepo = vocabularyRepo;
        }
        public IQueryable<Vocabulary> GetAll()
        {
            IQueryable<Vocabulary> result = null;
            try
            {
                result = _VocabularyRepo.GetAll();
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
        public List<Vocabulary> GetAllQuestion()
        {
            List<Vocabulary> result = null;
            try
            {
                result = _VocabularyRepo.GetAllQuestion();
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

        public List<Vocabulary> GetByCategoryAllQuestion(int categoryId)
        {
            List<Vocabulary> result = null;
            try
            {
                result = _VocabularyRepo.GetByCategoryAllQuestion(categoryId);
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

        public Vocabulary GetById(int id)
        {
            Vocabulary result = null;
            try
            {
                result = _VocabularyRepo.GetById(id);
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
        public void Insert(Vocabulary entity)
        {
            try
            {
                _VocabularyRepo.Insert(entity);
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
        public void Update(Vocabulary entity)
        {
            try
            {
                _VocabularyRepo.Update(entity);
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
        public void Delete(Vocabulary entity)
        {

        }

        public IEnumerable<Vocabulary> Filter(Expression<Func<Vocabulary, bool>> filter)
        {
            IEnumerable<Vocabulary> result = null;
            try
            {
                result = _VocabularyRepo.Filter(filter);
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

        public Vocabulary FindByWord(string word)
        {
            Vocabulary result = null;
            try
            {
                result = Filter(x => x.Word == word).FirstOrDefault<Vocabulary>();
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


// public void Create(VocabularyRequest model)
// {
//     Vocabulary newVocabulary = new Vocabulary
//     {
//         Word = model.Word,
//         Meaning = model.Meaning,
//         Sentence = model.Sentence,
//         Definition = model.Definition
//     };

//     try
//     {
//         _VocabularyRepo.Insert(newVocabulary);
//     }
//     catch (CustomException ex)
//     {
//         throw ex;
//     }
//     catch (System.Exception)
//     {
//         throw new CustomException(ConstantVar.ResponseCode.SYSTEM_ERROR);
//     }
// }