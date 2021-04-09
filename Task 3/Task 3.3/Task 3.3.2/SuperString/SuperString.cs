using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuperString
{
    public static class SuperString
    {
        public static TextType GetTextType(this string text)
        {
            if(char.IsDigit(text[0]))
            {
                if (text.All(c => char.IsDigit(c)))
                    return TextType.Number;
            }
            else if(IsEnglishLetter(text[0]))
            {
                if (text.All(c => IsEnglishLetter(c)))
                    return TextType.English;
            }
            else if (IsRussianLetter(text[0]))
            {
                if (text.All(c => IsRussianLetter(c)))
                    return TextType.Russian;
            }

            return TextType.Mixed;
        }

        private static bool IsRussianLetter(char letter)
        {
            var ch = char.ToUpper(letter);
            return (ch >= 'А' && ch <= 'Я') || ch == 'Ё';
        }

        private static bool IsEnglishLetter(char letter)
        {
            var ch = char.ToUpper(letter);
            return ch >= 'A' && ch <= 'Z';
        }
    }
}
