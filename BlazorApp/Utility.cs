using System.Collections.Generic;
using System.Linq;

namespace BlazorApp
{
    public static class Utility
    {
        /// <summary>
        /// Determines whether a list is null or empty.
        /// </summary>
        /// <typeparam name="T">Type name.</typeparam>
        /// <param name="enumerable">The enumerable object to check.</param>
        /// <returns>True if list is empty; otherwise false.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null) 
                return true;

            if (enumerable is ICollection<T> collection)
                return collection.Count < 1;

            return !enumerable.Any();
        }

        public static string ToYesNoString(this bool value)
        {
            return value ? "Yes" : "No";
        }
    }
}