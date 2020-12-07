using System.Buffers.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class TestModel : Test
    {
        public TestModel() : base()
        {
            
        }

        public TestModel(Test t) : base(t)
        {
            UserId = t.UserId;
            CategoryId = t.CategoryId;
            Result = t.Result;
            ImproveIndex = t.ImproveIndex;
            NextTime = t.NextTime;
            Order = t.Order;
        }

    }
}