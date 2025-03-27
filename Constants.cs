using System;
namespace am.kon.packages.common.strings
{
	public static class Constants
	{
		public static class Characters
		{
            public const char Space = ' ';
            public const char Slash = '/';
            public const char BackSlash = '\\';
            public const char Tilde = '~';
            public const char Question = '?';
            public const char Ampersant = '&';
            public const char Equal = '=';
            public const char Sharp = '#';
            public const char Dot = '.';
        }

        public static class Strings
        {
            public const string Space = " ";
            public const string Slash = "/";
            public const string UrlSchemeDelimiter = "://";
        }

        public static readonly char[] SpaceSeparatorCharactersArray = new char[] { Characters.Space };
		public static readonly string[] SpaceSeparatorStringsArray = new string[] { Strings.Space };
    }
}

