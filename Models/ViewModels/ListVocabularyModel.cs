using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class ListVocabularyModel
    {
        [JsonProperty(PropertyName = "List")]
        public List<VocabularyModel> ListVocabulary { get; set; }

        public ListVocabularyModel(List<Vocabulary> list)
        {
            ListVocabulary = getListVocabularyModel(list);
        }

        // HELPER
        private List<VocabularyModel> getListVocabularyModel(List<Vocabulary> list)
        {
            List<VocabularyModel> result = new List<VocabularyModel>();
            foreach (var item in list)
            {
                var itemModel = new VocabularyModel(item);
                result.Add(itemModel);
            }
            return result;
        }
    }
}