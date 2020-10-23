using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class ListVocabularyModel
    {
        [JsonProperty(PropertyName = "list")]
        public List<Vocabulary> ListVocabulary { get; set; }

        public ListVocabularyModel(List<Vocabulary> list)
        {
            ListVocabulary = list;
        }
    }
}