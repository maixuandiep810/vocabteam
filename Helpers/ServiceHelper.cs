using System;
using System.Collections.Generic;

using vocabteam.Models.ViewModels;

namespace vocabteam.Helpers
{
    public class ServiceHelper
    {
        public static void AddManyManyRecord<TEntity, TOne_N_Model>(Action<TEntity> _insertDelegate, Add_N_N_Request<TOne_N_Model> _add_N_N_Request) where TEntity : new() where TOne_N_Model : class
        {
            foreach (One_N_Model itemOne_N_Model in _add_N_N_Request.List)
            {
                int aA_Id = itemOne_N_Model.AModelId;
                foreach (int bB_Id in itemOne_N_Model.ListBModelId)
                {
                    TEntity newTEntity = GenericHelper.CreateGenericObject<TEntity>(aA_Id, bB_Id);
                    _insertDelegate.Invoke(newTEntity);
                }
            }
        }
    }
}