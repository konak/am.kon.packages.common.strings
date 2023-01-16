using System;
namespace am.kon.packages.common.strings
{
	public static class Constants
	{
		public static class Characters
		{
            public const char SpaceSeparatorCharacter = ' ';
            public const char SlashCharacter = '/';
            public const char BackSlashCharacter = '\\';
            public const char TildeCharacter = '~';
            public const char QuestionCharacter = '?';
            public const char AmpersantCharacter = '&';
            public const char EqualCharacter = '=';
            public const char SharpCharacter = '#';
        }

        public static class Strings
        {
            public const string SpaceSeparatorString = " ";
            public const string SlashString = "/";
        }

        public static readonly char[] SpaceSeparatorCharactersArray = new char[] { Characters.SpaceSeparatorCharacter };
		public static readonly string[] SpaceSeparatorStringsArray = new string[] { Strings.SpaceSeparatorString };
    }
}

