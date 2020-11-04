using System;

using vocabteam.Models.Entities;

namespace vocabteam.Helpers
{
    public class GenericHelper
    {
        public static T CreateGenericObject<T>(params object[] _listParams)
        {
            T varT = (T) Activator.CreateInstance(typeof(T), _listParams);
            return varT;
        }
    }
}