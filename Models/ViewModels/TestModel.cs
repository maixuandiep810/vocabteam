using System.Buffers.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class TestModel : Test
    {
        [JsonProperty(PropertyName = "Strength")]
        public double Strength { get; set; }

        public TestModel() : base()
        {
            
        }

        public TestModel(Test t) : base(t)
        {
            UserId = t.UserId;
            CategoryId = t.CategoryId;
            Result = t.Result;
        }

    }
}