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

        public IQueryable<Vocabulary> GetAllQuestion()
        {
            IQueryable<Vocabulary> result;
            try
            {
                result = GetAll();
                foreach (var item in result)
                {
                    item.Questions = _context.Questions.Where(p => p.VocabularyId == item.Id).ToList();
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