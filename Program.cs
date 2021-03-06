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
            //await WriteFile("a_an_example.{0}.txt");
            await WriteFile("b_better_start_small.{0}.txt");
            await WriteFile("c_collaboration.{0}.txt");
            await WriteFile("d_dense_schedule.{0}.txt");
            await WriteFile("e_exceptional_skills.{0}.txt");
            await WriteFile("f_find_great_mentors.{0}.txt");
        }

        private static async Task WriteFile(string textFileFormat)
        {
            string[] lines = File.ReadAllLines($"files/{string.Format(textFileFormat, "in")}");

            var first = lines[0].Split(' ');
            var contribCount = int.Parse(first[0]);
            var projCount = int.Parse(first[1]);
            int currentLine = 1;
            var contributors = new List<Contributor>();
            var contributorDictionary = new ContributorDictionary();
            var projects = new List<Project>();

            for (int x = 0; x < contribCount; x++)
            {
                var userLine = lines[currentLine].Split(' ');
                var username = userLine[0];
                var userSkillCount = int.Parse(userLine[1]);
                currentLine++;

                var contributor = new Contributor();
                contributors.Add(contributor);
                contributor.name = username;

                for (int i = 0; i < userSkillCount; i++)
                {
                    var skillLine = lines[currentLine].Split(' ');
                    contributor.skills.Add(skillLine[0], int.Parse(skillLine[1]));
                    currentLine++;
                }
            }

            contributorDictionary.contributors = contributors;

            for (int x = 0; x < projCount; x++)
            {
                var project = new Project();
                projects.Add(project);
                var projLine = lines[currentLine].Split(' ');
                project.name = projLine[0];
                project.duration = int.Parse(projLine[1]);
                project.score = int.Parse(projLine[2]);
                project.bestBefore = int.Parse(projLine[3]);

                var projectContribCount = int.Parse(projLine[4]);
                currentLine++;
                for (int i = 0; i < projectContribCount; i++)
                {
                    var projContribLine = lines[currentLine].Split(' ');
                    project.roles.Add(new Role(projContribLine[0], int.Parse(projContribLine[1])));

                    currentLine++;
                }
            }


            IStrategy strategy = new SimpleStrategy(projects, contributorDictionary);

            var result = strategy.Solve();

            await File.WriteAllTextAsync($"Results/{string.Format(textFileFormat, "out")}", result);
        }
    }
}
