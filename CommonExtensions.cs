using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace am.kon.packages.common.strings
{
	/// <summary>
	/// Common extension functions to operate with strings
	/// </summary>
	public static class CommonExtensions
	{
        /// <summary>
        /// Converts a collection of strings into a single space-separated string.
        /// </summary>
        /// <param name="list">The collection of strings to be joined with a space character as the separator.</param>
        /// <returns>A single string representation of the input collection separated by spaces, or an empty string if the list is null.</returns>
        [DebuggerStepThrough]
        public static string ToSpaceSeparatedString(this IEnumerable<string> list)
        {
            if (list == null)
            {
                return string.Empty;
            }

            return string.Join(Constants.Characters.Space, list);
        }

        /// <summary>
        /// Converts a space-separated string into a collection of strings.
        /// </summary>
        /// <param name="value">The space-separated string to be parsed.</param>
        /// <param name="separatorCharacters">The characters to be used as separators. Defaults to space character.</param>
        /// <returns>A collection of strings parsed from the input string.</returns>
        [DebuggerStepThrough]
        public static IEnumerable<string> FromSpaceSeparatedString(this string value, char[] separatorCharacters = null)
        {
            return value.Trim().Split(separatorCharacters ?? Constants.SpaceSeparatorCharactersArray, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Checks if a given string is null, empty, or consists only of whitespace characters.
        /// </summary>
        /// <param name="value">The string to be checked.</param>
        /// <returns>True if the string is null, empty, or contains only whitespace; otherwise, false.</returns>
        [DebuggerStepThrough]
        public static bool IsBlank(this string value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Determines whether a string is not null, not empty, and does not consist only of whitespace characters.
        /// </summary>
        /// <param name="value">The string to be checked.</param>
        /// <returns>True if the string is not null, not empty, and does not consist only of whitespace characters; otherwise, false.</returns>
        [DebuggerStepThrough]
        public static bool NotBlank(this string value) => !string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Obfuscates a string by replacing the majority of its content with mask characters
        /// while preserving a specified number of characters from the end of the string.
        /// </summary>
        /// <param name="value">The string to be obfuscated.</param>
        /// <param name="lastCharactersCount">The number of characters to preserve from the end of the string.</param>
        /// <param name="maskLength">The number of mask characters to replace the remaining part of the string with.</param>
        /// <returns>An obfuscated string consisting of the mask characters followed by the specified number of preserved characters,
        /// or only mask characters if the input string is null, empty, or shorter than the preserved characters count.</returns>
        public static string Obfuscate(this string value, int lastCharactersCount = 0, int maskLength = 7)
        {
            string result = new string('*', maskLength);

            if (value.IsBlank() && value.Length < lastCharactersCount)
                return result;

            return string.Concat(result, value[^lastCharactersCount..]);
        }

        /// <summary>
        /// Parses a space-delimited string into a sorted, distinct list of non-empty scopes.
        /// </summary>
        /// <param name="scopes">The input string containing space-separated scope values to be parsed.</param>
        /// <returns>A list of distinct, sorted scope strings, or null if the input string is null, empty, or contains only whitespace.</returns>
        public static List<string> ParseScopesString(this string scopes)
        {
            if (scopes.IsBlank())
            {
                return null;
            }

            scopes = scopes.Trim();

            var parsedScopes = scopes.Split(Constants.SpaceSeparatorCharactersArray, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();

            if (parsedScopes.Any())
            {
                parsedScopes.Sort();
                return parsedScopes;
            }

            return null;
        }
    }
}

