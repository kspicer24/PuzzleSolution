using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RedRoverPuzzle.Helpers;

namespace RedRoverPuzzle.Models
{
    public class TypeData
    {
        private string id;
        private string name;
        private string customFieldTitle;
        private string[] customFields;
        private string typeName;
        private readonly SubstringHelper substringHelper = new SubstringHelper();

        public TypeData(string data)
        {
            // extract type and values in parentheses
            var splitData = substringHelper.SplitTitle(data);
            var typeData = splitData[1];
            typeName = splitData[0];

            // extract custom fields
            var customFieldData = substringHelper.ExtractSubtype(typeData);

            // remove customfields values from typedata
            typeData = typeData.Remove(typeData.IndexOf(customFieldData), customFieldData.Length);
            typeData = typeData.Trim();
            var splitValues = typeData.Split(",");

            // assign values
            id = splitValues[0].Trim();
            name = splitValues[1].Trim();

            var splitFieldData = substringHelper.SplitTitle(customFieldData);
            customFieldTitle = splitFieldData[0];
            customFields = splitFieldData[1].Split(",");
        }

        public string Print(int printOption)
        {
            return printOption switch
            {
                1 => $"- {typeName}\n" +
                        $"  - {id}\n" +
                        $"  - {name}\n" +
                        $"  - {customFieldTitle}\n" +
                        $"{PrintCustomFields()}",
                2 => $"- {typeName}\n" +
                        $"  - {customFieldTitle}\n" +
                        $"{PrintCustomFields()}" +
                        $"  - {id}\n" +
                        $"  - {name}\n",
                _ => throw new ArgumentException("Invalid Print Option Given"),
            };
        }

        public string PrintCustomFields()
        {
            var printString = "";
            foreach (var cf in customFields)
            {
                printString += $"    - {cf.Trim()}\n";
            }

            return printString;
        }
    }
}
