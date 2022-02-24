using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace polyglots.practice._2022
{
    class Program
    {

        static async Task Main(string[] args)
        {
            await WriteFile("a_an_example.{0}.txt");
            // await WriteFile("b_basic.{0}.txt");
            // await WriteFile("c_coarse.{0}.txt");
            // await WriteFile("d_difficult.{0}.txt");
            // await WriteFile("e_elaborate.{0}.txt");
        }

        private static async Task WriteFile(string textFileFormat)
        {
            string[] lines = File.ReadAllLines($"files/{string.Format(textFileFormat, "in")}");

            var first = lines[0].Split(' ');
            var contribCount = first[0];
            var projCount = first[1];
            int currentLine = 1;
            var contributors = new List<Contributor>();

            for (int x = 0; x < contribCount; x++)
            {
                contributors
            }

            IStrategy strategy;
            //var result = strategy.Solve();

            await File.WriteAllTextAsync($"Results/{string.Format(textFileFormat, "out")}", result);
        }
    }
}
