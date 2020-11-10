using System.Collections.Generic;
using System.Linq;
using vocabteam.Helpers;
using vocabteam.Helpers.CustomExceptions;
using vocabteam.Models.Entities;

namespace vocabteam.Models.Repositories
{
    public class VocabularyRepository : MySqlRepository<Vocabulary>, IVocabularyRepository
    {

        public VocabularyRepository(VocabteamContext context) : base(context)
        {
        }

        public List<Vocabulary> GetAllQuestion()
        {
            List<Vocabulary> result;
            try
            {
                result = GetAll().ToList();
                for (int i = 0; i < result.Count(); i++)
                {
                    result[i].Questions = _context.Questions.Where(p => p.VocabularyId == result[i].Id).ToList();
                }
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
            }

            return result;
        }

        public List<Vocabulary> GetByCategoryAllQuestion(int categoryId)
        {
            List<Vocabulary> result;
            try
            {
                result = Filter(x => x.CategoryId == categoryId).ToList();
                for (int i = 0; i < result.Count(); i++)
                {
                    result[i].Questions = _context.Questions.Where(p => p.VocabularyId == result[i].Id).ToList();
                }
            }
            catch (System.Exception)
            {
                throw new CustomException(ConstantVar.ResponseCode.REPOSITORY_ERROR);
            }

            return result;
        }

        
 
    }
}