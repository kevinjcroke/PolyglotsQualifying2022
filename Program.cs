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
            var contribCount = int.Parse(first[0]);
            var projCount = int.Parse(first[1]);
            int currentLine = 1;
            var contributors = new List<Contributor>();

            for (int x = 0; x < contribCount; x++)
            {
                var userLine = lines[currentLine].Split(' ');
                var username = userLine[0];
                var userSkillCount = int.Parse(userLine[1]);
                currentLine++;

                var contributor = new Contributor();
                contributor.name = username;

                for (int i = 0; i < userSkillCount; i++)
                {
                    var skillLine = lines[currentLine].Split(' ');
                    contributor.skills.Add(skillLine[0], int.Parse(skillLine[1]));
                    currentLine++;
                }
            }

            for (int x = 0; x < projCount; x++)
            {

            }



            IStrategy strategy;
            //var result = strategy.Solve();

            await File.WriteAllTextAsync($"Results/{string.Format(textFileFormat, "out")}", result);
        }
    }
}
