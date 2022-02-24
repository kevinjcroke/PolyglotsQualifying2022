using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace polyglots.practice._2022
{
    public class ContributorDictionary
    {
        public List<Contributor> contributors { get; set; } = new List<Contributor>();

        public Contributor GetHighestSkillContributor(String skillName)
        {
            Contributor highestContributor=null;

            foreach (var contributor in contributors)
            {
                if (highestContributor == null)
                {
                    highestContributor = contributor;
                }
                else
                {
                    if (contributor.GetSkillLevel(skillName) > highestContributor.GetSkillLevel(skillName))
                    {
                        highestContributor = contributor;
                    }
                }
            }

            return highestContributor;
        }
    }
}
