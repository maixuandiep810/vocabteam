using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class VocabularyResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Data")]
        public ListVocabularyModel Data { get; set; }

        public VocabularyResponse() : base()
        {
        }

        public VocabularyResponse(ListVocabularyModel list) : base()
        {
            Data = list;
        }

        public VocabularyResponse(ListVocabularyModel list, BaseResponse baseRes) : base(baseRes)
        {
            Data = list;
        }
    }
}