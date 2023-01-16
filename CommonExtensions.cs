using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace am.kon.packages.common.strings
{
	/// <summary>
	/// Common extensionn functions to operate with strings
	/// </summary>
	public static class CommonExtensions
	{
        /// <summary>
        /// Transform <see cref="IEnumerable<string>" into space separated string/>
        /// </summary>
        /// <param name="list">list of string items to be joined</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static string ToSpaceSeparatedString(this IEnumerable<string> list)
        {
            if (list == null)
            {
                return string.Empty;
            }

            return string.Join(Constants.Characters.SpaceSeparatorCharacter, list);
        }

        /// <summary>
        /// Transform space separated string into array of strings using space character as separator
        /// </summary>
        /// <param name="value">String value to be transformed</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static IEnumerable<string> FromSpaceSeparatedString(this string value)
        {
            value = value.Trim();
            return value.Split(Constants.SpaceSeparatorCharactersArray, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Proxy extension method for IsNullOrWhiteSpace method of <see cref="string"/> object.
        /// </summary>
        /// <param name="value">String value to be checked</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Proxy extension method returinng negative vaule of IsNullOrWhiteSpace method of <see cref="string"/> object.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool IsNotNullOrWhiteSpace(this string value) => !string.IsNullOrWhiteSpace(value);


        public static string Obfuscate(this string value)
        {
            var last4Chars = "****";

            if (value.IsNotNullOrWhiteSpace() && value.Length > 4)
            {
                last4Chars = value.Substring(value.Length - 4);
            }

            return "****" + last4Chars;
        }

        public static List<string> ParseScopesString(this string scopes)
        {
            if (scopes.IsNullOrWhiteSpace())
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

