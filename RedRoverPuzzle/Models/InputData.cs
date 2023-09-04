using System;
using System.Linq;
using System.Text.RegularExpressions;
using RedRoverPuzzle.Helpers;

namespace RedRoverPuzzle.Models
{
    public class InputData
    {
        private string id;
        private string name;
        private string email;
        private string externalId;
        private TypeData type;
        private readonly SubstringHelper substringHelper = new SubstringHelper();

        public InputData(string data)
        {
            var allData = substringHelper.StripOuterParentheses(data);

            var subtype = substringHelper.ExtractSubtype(allData);

            type = new TypeData(subtype);

            // remove type data and clean remaining
            var remainingData = allData.Remove(allData.IndexOf(subtype), subtype.Length).Split(",").ToList();
            var cleaned = remainingData.Where(v => !string.IsNullOrEmpty(v) && !string.IsNullOrWhiteSpace(v)).ToArray();

            // assign values
            id = cleaned[0].Trim();
            name = cleaned[1].Trim();
            email = cleaned[2].Trim();
            externalId = cleaned[3].Trim();
        }

        public string Print(int printOption)
        {
            return printOption switch
            {
                1 => $"- {id}\n" +
                        $"- {name}\n" +
                        $"- {email}\n" +
                        $"{type.Print(printOption)}" +
                        $"- {externalId}",
                2 => $"- {email}\n" +
                        $"- {externalId}\n" +
                        $"- {id}\n" +
                        $"- {name}\n" +
                        $"{type.Print(printOption)}",
                _ => throw new ArgumentException("Invalid Print Option Given"),
            };
        }
    }
}
