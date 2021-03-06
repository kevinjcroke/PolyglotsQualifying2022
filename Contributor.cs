using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace polyglots.practice._2022
{
    public class Contributor
    {
        public String name { get; set; }
        public Dictionary<String, int> skills = new Dictionary<String, int>();

        public int GetSkillLevel(String skillName)
        {
            if (skills.ContainsKey(skillName))
            {
                return skills[skillName];
            }
            else
            {
                return 0;
            }
        }

        public void IncreaseSkillLevel(string skillName)
        {
            if (skills.ContainsKey(skillName))
            {
                skills[skillName] = skills[skillName] + 1;
            }
            else
            {
                skills.Add(skillName, 0);
            }
        }

        public override string ToString()
        {
            return $"ContributorName: {name} \r\n {string.Join(Environment.NewLine, skills)}{Environment.NewLine}";
        }
    }
}