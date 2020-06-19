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

            Console.WriteLine("Received Arguments: ");
            var arguments = args
                .Select(argument => argument.Split('='))
                .Where(split => split.Length == 2)
                .ToDictionary(split => split[0], split => split[1]);
            Console.WriteLine(JsonSerializer.Serialize(arguments));
            Console.ReadKey();
        }
    }
}
