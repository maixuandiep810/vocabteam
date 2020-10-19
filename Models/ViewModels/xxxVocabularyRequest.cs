using System.ComponentModel.DataAnnotations;

namespace vocabteam.Models.ViewModels
{
    public class xxxxVocabularyRequest
    {
        [Required]
        public string Word { get; set; }
        [Required]
        public string Meaning { get; set; }
        [Required]
        public string Definition { get; set; }
        [Required]
        public string Sentence { get; set; }

        // [Required]
        // public int? CategoryId { get; set; }
    }
}