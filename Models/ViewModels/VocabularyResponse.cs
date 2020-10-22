using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class VocabularyResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data")]
        public List<Vocabulary> Data { get; set; }

        public VocabularyResponse() : base()
        {
        }

        public VocabularyResponse(List<Vocabulary> v) : base()
        {
            Data = v;
        }

        public VocabularyResponse(List<Vocabulary> v, BaseResponse baseRes) : base(baseRes)
        {
            Data = v;
        }
    }
}