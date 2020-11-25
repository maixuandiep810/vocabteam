using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;
using vocabteam.Helpers;


namespace vocabteam.Models.ViewModels
{
    public class ListTestSettingModel
    {
        [JsonProperty(PropertyName = "List")]
        public List<TestSettingModel> ListTestSetting { get; set; }

        public ListTestSettingModel(List<UserSetting> list)
        {
            ListTestSetting =
            TransformEntityModel.getListTransformEntityModel<UserSetting, TestSettingModel>(list);
        }
    }
}