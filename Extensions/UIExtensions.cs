using System;
using System.Collections.Generic;
using System.Linq;

namespace SGComum.Extensions
{
    public static class UIExtensions
    {
        public static dynamic Field(this Dictionary<string, dynamic> dictionary, string fieldName)
        {
            return dictionary.FirstOrDefault(c => c.Key.ToLower().Equals(fieldName.ToLower())).Value;
        }

        public static T Field<T>(this Dictionary<string, dynamic> dictionary, string fieldName)
        {
            dynamic value;

            if (dictionary.TryGetValue(fieldName, out value))
            {
                try
                {
                    return Convert.ChangeType(value, typeof(T));
                }
                catch (Exception)
                {
                    return value is T ? (T)value : default(T);
                }
            }
            else
                return default(T);
        }
    }
}
