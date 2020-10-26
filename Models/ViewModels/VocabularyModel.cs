using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class VocabularyModel : BaseModel
    {
        [JsonProperty(PropertyName = "Word")]
        public string Word { get; set; }
        [JsonProperty(PropertyName = "Meaning")]
        public string Meaning { get; set; }
        [JsonProperty(PropertyName = "Definition")]
        public string Definition { get; set; }
        [JsonProperty(PropertyName = "Sentence")]
        public string Sentence { get; set; }
        [JsonProperty(PropertyName = "AudioUrl")]
        public string AudioUrl { get; set; }
        [JsonProperty(PropertyName = "ImageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "CategoryId")]
        public int? CategoryId { get; set; }
        public VocabularyModel()
        {
        }
        public VocabularyModel(Vocabulary vocab)
        {
            Id = vocab.Id;
            Word = vocab.Word;
            Meaning = vocab.Meaning;
            Definition = vocab.Definition;
            Sentence = vocab.Sentence;
            AudioUrl = vocab.AudioUrl;
            ImageUrl = vocab.ImageUrl;
            CategoryId = vocab.CategoryId;
        }

    }
}