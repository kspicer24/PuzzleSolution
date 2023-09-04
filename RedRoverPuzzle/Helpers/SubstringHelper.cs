using System;
using System.Text.RegularExpressions;

namespace RedRoverPuzzle.Helpers
{
    public class SubstringHelper
    {
        private readonly string titlePattern = @"\w+(\()";

        public SubstringHelper()
        {
        }

        public string StripOuterParentheses(string data)
        {
            return data.Substring(data.IndexOf("(") + 1, data.LastIndexOf(")") - 1);
        }
        public string ExtractSubtype(string data)
        {
            var match = Regex.Match(data, titlePattern);
            var customFieldData = data.Substring(match.Index, data.Length - match.Index - (data.Length - data.LastIndexOf(")") - 1));

            return customFieldData;
        }

        public string[] SplitTitle(string data)
        {
            var title = data.Substring(0, data.IndexOf("("));
            var content = data.Substring(data.IndexOf("("), data.Length - data.IndexOf("("));

            return new string[2] { title, StripOuterParentheses(content) };
        }
    }
}
