using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace polyglots.practice._2022
{
    public class Project
    {
        public String name { get; set; }
        public int duration { get; set; }
        public int score { get; set; }
        public int bestBefore { get; set; }
        public List<Role> roles { get; set; } = new List<Role>();

        public double pointsByDay
        {
            get { return score / duration; }
        }

        public bool canComplete(ContributorDictionary contributors)
        {
            List<Contributor> team = new List<Contributor>();
            List<String> coveredSkills = new List<String>();

            foreach (var role in roles)
            {
                foreach (var contributor in contributors.contributors)
                {
                    if (!team.Contains(contributor) && contributor.GetSkillLevel(role.skillName) >= role.skillLevel)
                    {
                        team.Add(contributor);
                        coveredSkills.Add(role.skillName);
                        break;
                    }
                }
            }

            if (coveredSkills.Count() == roles.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Contributor> teamComplete(ContributorDictionary contributors)
        {
            List<Contributor> team = new List<Contributor>();
            List<String> coveredSkills = new List<String>();

            foreach (var role in roles)
            {
                foreach (var contributor in contributors.contributors)
                {
                    if (!team.Contains(contributor) && contributor.GetSkillLevel(role.skillName) >= role.skillLevel)
                    {
                        team.Add(contributor);
                        coveredSkills.Add(role.skillName);
                        break;
                    }
                }
            }

            if (coveredSkills.Count() == roles.Count())
            {
                return team;
            }
            else
            {
                return new List<Contributor>();
            }
        }

        public bool canCompleteBestBefore(int day)
        {
            return day + duration <= bestBefore;
        }
        public override string ToString()
        {
            return $"Project Name: {name} {Environment.NewLine} Duration: {duration}{Environment.NewLine}Score: {score} {Environment.NewLine}BestBefore: {bestBefore}{Environment.NewLine}  {string.Join(Environment.NewLine, roles)}{Environment.NewLine}";
        }
    }
}
