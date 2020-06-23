using System;
using System.Linq;
using System.Text.Json;

namespace YourAppName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Launch App!");
            Console.WriteLine();
            Console.WriteLine("Received Arguments: ");
            var arguments = args
                .Select(argument => argument.Split('='))
                .Where(split => split.Length == 2)
                .ToDictionary(split => split[0], split => split[1]);
            Console.WriteLine(JsonSerializer.Serialize(arguments));
            Console.WriteLine();
            Console.WriteLine("Parsing JSON Data: ");
            args
                .Select(argument => argument.Split('='))
                .Where(split => split.Length == 2)
                .Select(split =>
                {
                    var firstChar = split[1].IndexOf(":") + 1;
                    var str = split[1].Substring(firstChar, split[1].Length - firstChar);
                    return System.Web.HttpUtility.UrlDecode(str, System.Text.Encoding.UTF8);
                })
                .ToList()
                .ForEach(d => Console.WriteLine(d));
            Console.ReadKey();
        }
    }
}
