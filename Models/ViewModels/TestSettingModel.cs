using System;
using System.Reflection.Metadata;
using System.Linq.Expressions;
using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;
using vocabteam.Helpers;

namespace vocabteam.Models.ViewModels
{
    public class TestSettingModel
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Value")]
        public float Value { get; set; }

        [JsonProperty(PropertyName = "Time")]
        public float Time { get; set; }

        public TestSettingModel() : base()
        {

        }

        public TestSettingModel(UserSetting u)
        {
            switch (u.Name)
            {
                // case ConstantVar.ENUM_UserSettingString(ConstantVar.ENUM_UserSetting.TODOTEST_A1):
                // Name = ConstantVar.GetLevel(ConstantVar.ENUM_UserSetting.TODOTEST_A1);
                // break;
                // case ConstantVar.ENUM_UserSettingString(ConstantVar.ENUM_UserSetting.TODOTEST_A2):
                // Name = ConstantVar.GetLevel(ConstantVar.ENUM_UserSetting.TODOTEST_A2);
                // break;
                // default:
                // break;

                case "ToDoTestA1":
                    Name = ConstantVar.GetLevel(ConstantVar.ENUM_UserSetting.TODOTEST_A1);
                    break;
                case "ToDoTestA2":
                    Name = ConstantVar.GetLevel(ConstantVar.ENUM_UserSetting.TODOTEST_A2);
                    break;
                case "ToDoTestB1":
                    Name = ConstantVar.GetLevel(ConstantVar.ENUM_UserSetting.TODOTEST_B1);
                    break;
                case "ToDoTestB2":
                    Name = ConstantVar.GetLevel(ConstantVar.ENUM_UserSetting.TODOTEST_B2);
                    break;
                case "ToDoTestC1":
                    Name = ConstantVar.GetLevel(ConstantVar.ENUM_UserSetting.TODOTEST_C1);
                    break;
                case "ToDoTestC2":
                    Name = ConstantVar.GetLevel(ConstantVar.ENUM_UserSetting.TODOTEST_C2);
                    break;
                default:
                    break;
            }
            Value = Convert.ToSingle(u.Value);
            Time = 100;

        }

    }
}