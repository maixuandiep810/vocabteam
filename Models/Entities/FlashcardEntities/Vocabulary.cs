using System.ComponentModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vocabteam.Models.Entities
{
    public class Vocabulary : BaseEntity
    {
        public string Word { get; set; }
        public string Meaning { get; set; }
        public string Definition { get; set; }
        public string Sentence { get; set; }
        public string AudioUrl { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}