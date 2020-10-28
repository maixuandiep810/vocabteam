using System.Collections.Generic;
namespace vocabteam.Helpers
{
    public class RepositoryHelper
    {
        public static void AddManyManyRecord<TRepo, TMany>(string _oneId, List<string> _listManyId) where TMany : new()
        {
            foreach (string manyId in _listManyId)
            {
                TMany newTMany = GenericHelper.CreateGenericObject<TMany>(_one, )
            }
        }
    }
}