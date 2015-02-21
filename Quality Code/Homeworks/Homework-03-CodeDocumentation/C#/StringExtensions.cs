using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// The StringExtensions class provides various methods for manipulating strings.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Encrypts the input string using MD5
    /// </summary>
    /// <param name="input">The input string to be encrypted.</param>
    /// <returns>The MD5 encrypted string.</returns>
    public static string ToMd5Hash(this string input)
    {
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }

    /// <summary>
    /// Converts the string to a boolean value, where all values that relate to "true" or "yes" return True and the rest return False
    /// </summary>
    /// <param name="input">The input string to be converted.</param>
    /// <returns>A value of boolean type.</returns>
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
        return stringTrueValues.Contains(input.ToLower());
    }

    /// <summary>
    /// Tries to parse the input string to a value of type short. If unsuccessful, returns the default value for short.
    /// </summary>
    /// <param name="input">The string to be parsed.</param>
    /// <returns>A value of type short.</returns>
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    /// <summary>
    /// Tries to parse the input string to a value of type int. If unsuccessful, returns the default value for int.
    /// </summary>
    /// <param name="input">The string to be parsed.</param>
    /// <returns>A value of type int.</returns>
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    /// <summary>
    /// Tries to parse the input string to a value of type long. If unsuccessful, returns the default value for long.
    /// </summary>
    /// <param name="input">The string to be parsed.</param>
    /// <returns>A value of type long.</returns>
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    /// <summary>
    /// Tries to parse the input string to DateTime. If unsuccessful, returns the default value for a DateTime object.
    /// </summary>
    /// <param name="input">The string to be parsed.</param>
    /// <returns>A DateTime object.</returns>
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    /// <summary>
    /// Capitalizes the first letter of a non-empty string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The resulting string.</returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return 
            input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + 
            input.Substring(1, input.Length - 1);
    }

    /// <summary>
    /// Returns a substring of the input string, which is found between a specified start string and end string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="startString">The start string.</param>
    /// <param name="endString">The end string.</param>
    /// <param name="startFrom">The index where the search begins, optional.</param>
    /// <returns>The substring</returns>
    public static string GetStringBetween(
        this string input, string startString, string endString, int startFrom = 0)
    {
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        var startPosition = 
            input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        return input.Substring(startPosition, endPosition - startPosition);
    }

    /// <summary>
    /// Converts all Cyrillic letters in a string to Latin letters.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>A string where all Cyrillic letters have been exchanged with Latin letters.</returns>
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters = new[]
        {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
        var latinRepresentationsOfBulgarianLetters = new[]
        {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            input = input.Replace(
                bulgarianLetters[i].ToUpper(),
                latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    /// <summary>
    /// Converts all Latin letters in a string to the respective Cyrillic letters based on keyboard layout.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>A string where all Latin letters have been exchanged with Cyrillic letters based on keyboard layout.</returns>
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        var bulgarianRepresentationOfLatinKeyboard = new[]
        {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            input = input.Replace(
                latinLetters[i].ToUpper(),
                bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }

    /// <summary>
    /// Removes all special characters from a string. The resulting string will contain only letters, digits, underscores and dot and will be considered a valid username.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The resulting string which conforms to the rules for valid usernames.</returns>
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
    }

    /// <summary>
    /// Removes all special characters from a string so that the resulting string can be used as a valid file name.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The resulting string.</returns>
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
    }

    /// <summary>
    /// Gets the first charsCount characters in a string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="charsCount">The number of characters to be returned.</param>
    /// <returns>The first charsCount characters from the input string.</returns>
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    /// <summary>
    /// Retrieves the file extension of a given valid file name.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>A string containing the extension of the file name provided.</returns>
    public static string GetFileExtension(this string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    /// <summary>
    /// Returns the content type of a given file extension.
    /// </summary>
    /// <param name="fileExtension">The file extension.</param>
    /// <returns>A string containing the content type of the provided file extension.</returns>
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };
        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        return "application/octet-stream";
    }

    /// <summary>
    /// Returns an array of bytes where each symbol of the input string is converted to a value of type byte.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>A byte array.</returns>
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}
