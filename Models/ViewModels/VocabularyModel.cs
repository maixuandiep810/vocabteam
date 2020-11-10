using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class VocabularyModel : Vocabulary
    {
        public VocabularyModel() : base()
        {
        }
        public VocabularyModel(Vocabulary vocab) : base(vocab)
        {
            Word = vocab.Word;
            Meaning = vocab.Meaning;
            Definition = vocab.Definition;
            Sentence = vocab.Sentence;
            AudioUrl = vocab.AudioUrl;
            ImageUrl = vocab.ImageUrl;
            CategoryId = vocab.CategoryId;
            Questions = vocab.Questions;
        }

    }
}