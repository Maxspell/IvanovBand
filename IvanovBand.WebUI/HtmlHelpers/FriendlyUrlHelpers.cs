using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace IvanovBand.WebUI.HtmlHelpers
{
    public static class FriendlyUrlHelpers
    {
        private static Dictionary<string, string> _seoCharacterTable;

        public static string GetSeoName(string name)
        {
            if (String.IsNullOrEmpty(name))
                return name;
            string okChars = "abcdefghijklmnopqrstuvwxyz1234567890 _-";
            name = name.Trim().ToLower();

            if (_seoCharacterTable == null)
                InitializeSeoCharacterTable();

            var sb = new StringBuilder();
            foreach (char c in name.ToCharArray())
            {
                string c2 = c.ToString();
                if (_seoCharacterTable.ContainsKey(c2))
                    c2 = _seoCharacterTable[c2];

                if (char.IsLetterOrDigit(c) || okChars.Contains(c2))
                {
                    sb.Append(c2);
                }
            }
            string name2 = sb.ToString();
            name2 = name2.Replace(" ", "-");
            while (name2.Contains("--"))
                name2 = name2.Replace("--", "-");
            while (name2.Contains("__"))
                name2 = name2.Replace("__", "_");
            return name2;
        }

        private static void InitializeSeoCharacterTable()
        {
            if (_seoCharacterTable == null)
            {
                _seoCharacterTable = new Dictionary<string, string>();
                _seoCharacterTable.Add("а", "a");
                _seoCharacterTable.Add("б", "b");
                _seoCharacterTable.Add("в", "v");
                _seoCharacterTable.Add("г", "g");
                _seoCharacterTable.Add("д", "d");
                _seoCharacterTable.Add("е", "e");
                _seoCharacterTable.Add("ё", "yo");
                _seoCharacterTable.Add("ж", "zh");
                _seoCharacterTable.Add("з", "z");
                _seoCharacterTable.Add("и", "i");
                _seoCharacterTable.Add("й", "j");
                _seoCharacterTable.Add("к", "k");
                _seoCharacterTable.Add("л", "l");
                _seoCharacterTable.Add("м", "m");
                _seoCharacterTable.Add("н", "n");
                _seoCharacterTable.Add("о", "o");
                _seoCharacterTable.Add("п", "p");
                _seoCharacterTable.Add("р", "r");
                _seoCharacterTable.Add("с", "s");
                _seoCharacterTable.Add("т", "t");
                _seoCharacterTable.Add("у", "u");
                _seoCharacterTable.Add("ф", "f");
                _seoCharacterTable.Add("х", "h");
                _seoCharacterTable.Add("ц", "c");
                _seoCharacterTable.Add("ч", "ch");
                _seoCharacterTable.Add("ш", "sh");
                _seoCharacterTable.Add("щ", "sch");
                _seoCharacterTable.Add("ъ", "j");
                _seoCharacterTable.Add("ы", "i");
                _seoCharacterTable.Add("ь", "j");
                _seoCharacterTable.Add("э", "e");
                _seoCharacterTable.Add("ю", "yu");
                _seoCharacterTable.Add("я", "ya");
                _seoCharacterTable.Add("А", "A");
                _seoCharacterTable.Add("Б", "B");
                _seoCharacterTable.Add("В", "V");
                _seoCharacterTable.Add("Г", "G");
                _seoCharacterTable.Add("Д", "D");
                _seoCharacterTable.Add("Е", "E");
                _seoCharacterTable.Add("Ё", "Yo");
                _seoCharacterTable.Add("Ж", "Zh");
                _seoCharacterTable.Add("З", "Z");
                _seoCharacterTable.Add("И", "I");
                _seoCharacterTable.Add("Й", "J");
                _seoCharacterTable.Add("К", "K");
                _seoCharacterTable.Add("Л", "L");
                _seoCharacterTable.Add("М", "M");
                _seoCharacterTable.Add("Н", "N");
                _seoCharacterTable.Add("О", "O");
                _seoCharacterTable.Add("П", "P");
                _seoCharacterTable.Add("Р", "R");
                _seoCharacterTable.Add("С", "S");
                _seoCharacterTable.Add("Т", "T");
                _seoCharacterTable.Add("У", "U");
                _seoCharacterTable.Add("Ф", "F");
                _seoCharacterTable.Add("Х", "H");
                _seoCharacterTable.Add("Ц", "C");
                _seoCharacterTable.Add("Ч", "Ch");
                _seoCharacterTable.Add("Ш", "Sh");
                _seoCharacterTable.Add("Щ", "Sch");
                _seoCharacterTable.Add("Ъ", "J");
                _seoCharacterTable.Add("Ы", "I");
                _seoCharacterTable.Add("Ь", "J");
                _seoCharacterTable.Add("Э", "E");
                _seoCharacterTable.Add("Ю", "Yu");
                _seoCharacterTable.Add("Я", "Ya");
                _seoCharacterTable.Add("«", "");
                _seoCharacterTable.Add("»", "");
                _seoCharacterTable.Add("—", "-");
            }
        }
    }
}