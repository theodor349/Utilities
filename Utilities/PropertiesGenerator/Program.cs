using System;
using System.IO;
using System.Linq;

namespace PropertiesGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = args[0];
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                var middle = lines[i].Split(" ").Aggregate((x, y) => Char.ToUpper(x[0]) + x.Substring(1).ToLower() + Char.ToUpper(y[0]) + y.Substring(1).ToLower());
                lines[i] = "public " + middle + " { get; set;}";
            }
            File.WriteAllLines(filePath.Split(".").FirstOrDefault() + "Output." + filePath.Split(".").LastOrDefault(), lines);
        }
    }
}
