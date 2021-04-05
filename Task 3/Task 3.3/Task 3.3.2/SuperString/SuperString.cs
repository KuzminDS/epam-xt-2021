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
            if (text.All(c => char.IsDigit(c)))
                return TextType.Number;

            if (text.All(c => char.IsLetter(c)))
            {
                if (Regex.IsMatch(text, @"^[а-яА-ЯЁё]*$"))
                    return TextType.Russian;
                if (Regex.IsMatch(text, @"^[a-zA-Z]*$"))
                    return TextType.English;
            }

            return TextType.Mixed;
        }
    }
}
