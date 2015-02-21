namespace _01.StringBuilderExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Defines extension methods for the System.Text.StringBuilder class
    /// </summary>
    public static class StringBuilderExtensionMethods
    {
        /// <summary>
        /// Returns a new String object, containing the elements in the given range. 
        /// If the range exceeds the length of the StringBuilder, all elements from the start index to the end of the StringBuilder are taken.
        /// </summary>
        /// <param name="sb">The StringBuilder object.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="length">The length of the substring.</param>
        /// <returns>A String object.</returns>
        public static string Substring(this StringBuilder sb, int startIndex, int length)
        {
            if (startIndex < 0 || sb.Length <= startIndex)
            {
                throw new IndexOutOfRangeException("The start index should be between 0 and the length of the string minus 1.");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "The length cannot be negative.");
            }

            StringBuilder substring = new StringBuilder();

            for (int index = startIndex; index < startIndex + length; index++)
            {
                if (index >= sb.Length)
                {
                    break;
                }

                substring.Append(sb[index]);
            }

            return substring.ToString();
        }

        /// <summary>
        /// Removes all occurrences of the specified text (case-insensitive) from the StringBuilder
        /// </summary>
        /// <param name="sb">The StringBuilder object to be modified.</param>
        /// <param name="text">The text to remove.</param>
        public static void RemoveText(this StringBuilder sb, string text)
        {
            while (true)
            {
                string stringBuilderAsString = sb.ToString();
                int startIndex = stringBuilderAsString.IndexOf(text, StringComparison.InvariantCultureIgnoreCase);

                if (startIndex == -1)
                {
                    return;
                }

                int length = text.Length;

                sb.Remove(startIndex, length);
            }
        }

        /// <summary>
        /// Appends the string representations of all items from the specified collection to the StringBuilder.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="sb">The current StringBuilder object.</param>
        /// <param name="items">The list of items to be appended.</param>
        public static void AppendAll<T>(this StringBuilder sb, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                sb.Append(item);
            }
        }
    }
}
