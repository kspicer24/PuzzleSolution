using System;
using System.Text.RegularExpressions;
using RedRoverPuzzle.Models;

namespace RedRoverPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringData = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
            var dataStruct = new InputData(stringData);

            Console.WriteLine(dataStruct.Print(1));

            Console.WriteLine("\n\n----------------------------------------------\n\n");

            Console.WriteLine(dataStruct.Print(2));
        }
    }
}
