using vocabteam.Models.Entities;

namespace vocabteam.Models.Repositories
{
    public class VocabularyRepository : MySqlRepository<Vocabulary>, IVocabularyRepository
    {

        public VocabularyRepository(VocabteamContext context) : base(context)
        {
        }
 
    }
}