using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class VocabularyModel : Vocabulary
    {
        [JsonProperty(PropertyName = "Answer")]
        public string[] Answers { get; set; }


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
            Answers = CreateQuestion(Questions, Word);
        }

        private string[] CreateQuestion(List<Question> questions, string word)
        {
            string[] answersString = new string[4];
            Random r = new Random();
            int index = r.Next(0, questions.Count);
            int a = r.Next(0, 4);
            int b = r.Next(0, 4);
            answersString[0] = questions[index].FirstAnswer;
            answersString[1] = questions[index].SecondAnswer;
            answersString[2] = questions[index].ThirdAnswer;
            answersString[3] = word;

            string temp = answersString[a];
            answersString[a] = answersString[b];
            answersString[b] = temp;

            return answersString;
        }

    }
}