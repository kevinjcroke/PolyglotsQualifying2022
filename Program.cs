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

            for (int i = 1; i < lines.Length - 1; i += 2)
            {
            }

            IStrategy strategy;
            var result = strategy.Solve();

            await File.WriteAllTextAsync($"Results/{string.Format(textFileFormat, "out")}", result);
        }
    }
}
