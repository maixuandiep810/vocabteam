using System;
using System.Collections.Generic;
using vocabteam.Models.ViewModels;
using vocabteam.Models.Entities;



namespace vocabteam.Helpers
{
    public class TransformEntityModel
    {
        public static List<TModel> getListTransformEntityModel<TEntity, TModel>(List<TEntity> list)
        {
            List<TModel> result = new List<TModel>();
            foreach (TEntity itemEntity in list)
            {
                TModel itemModel = GenericHelper.CreateGenericObject<TModel>(itemEntity);
                result.Add(itemModel);
            }
            return result;
        }
    }
}