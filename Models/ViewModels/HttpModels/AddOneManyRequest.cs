using System.Collections.Generic;

namespace vocabteam.Models.ViewModels
{
    public class AddOneManyRequest
    {
        public string OneId { get; set; }
        
        public List<string> ListManyId { get; set; }
    }
}