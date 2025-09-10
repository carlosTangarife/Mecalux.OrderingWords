using System;
using System.Collections.Generic;

namespace Mecalux.OrderingWords.Infrastructure.Helpers
{
    public static class EnumHelper
    {
        public static List<KeyValuePair<string, int>> GetEnumList<T>()
        {
            var keyValuePairs = new List<KeyValuePair<string, int>>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                keyValuePairs.Add(new KeyValuePair<string, int>(e.ToString() ?? string.Empty, (int)e));
            }
            return keyValuePairs;
        }
    }
}
