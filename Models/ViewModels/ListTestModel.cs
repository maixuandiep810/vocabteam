using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;
using vocabteam.Helpers;

namespace vocabteam.Models.ViewModels
{
    public class ListTestModel
    {
        [JsonProperty(PropertyName = "List")]
        public List<TestModel> ListTest { get; set; }

        public ListTestModel(List<Test> list)
        {
            ListTest = 
            TransformEntityModel.getListTransformEntityModel<Test, TestModel>(list);
        }

        // HELPER
    }
}