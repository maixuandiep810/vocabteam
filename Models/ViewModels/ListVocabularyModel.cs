using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;
using vocabteam.Helpers;


namespace vocabteam.Models.ViewModels
{
    public class ListVocabularyModel
    {
        [JsonProperty(PropertyName = "List")]
        public List<VocabularyModel> ListVocabulary { get; set; }

        public ListVocabularyModel(List<Vocabulary> list)
        {
            ListVocabulary =
            TransformEntityModel.getListTransformEntityModel<Vocabulary, VocabularyModel>(list);
        }
    }
}