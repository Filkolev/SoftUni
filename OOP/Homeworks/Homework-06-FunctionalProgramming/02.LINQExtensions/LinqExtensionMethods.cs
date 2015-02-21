namespace _02.LINQExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines extension methods for System.LINQ
    /// </summary>
    public static class LinqExtensionMethods
    {
        /// <summary>
        /// Filters the non-matching items from the collection.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to filter.</param>
        /// <param name="predicate">The filtering condition.</param>
        /// <returns>The filtered IEnumerable collection.</returns>
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var filteredCollection = collection.Where(element => !predicate(element));

            return filteredCollection;
        }

        /// <summary>
        /// Repeats the collection count times.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to repeat.</param>
        /// <param name="count">The number of repetitions.</param>
        /// <returns>IEnumerable collection.</returns>
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            IEnumerable<T> repeatedCollection = collection;
            for (int i = 0; i < count - 1; i++)
            {
                repeatedCollection = repeatedCollection.Concat(collection);   
            }

            return repeatedCollection;
        }

        /// <summary>
        /// Filters all items from the collection that ends with some of the specified suffixes.
        /// </summary>
        /// <param name="collection">The collection to filter.</param>
        /// <param name="suffixes">The specified suffix used as a filter condition.</param>
        /// <returns>The filtered IEnumerable collection.</returns>
        public static IEnumerable<string> WhereEndsWith(
            this IEnumerable<string> collection,
            IEnumerable<string> suffixes)
        {
            var filteredCollection =
                from element in collection
                from suffix in suffixes
                where element.EndsWith(suffix)
                select element;

            return filteredCollection;
        }
    }
}
