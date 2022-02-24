using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace polyglots.practice._2022
{
    public class SimpleStrategy : IStrategy
    {
        List<Project> projects;
        ContributorDictionary contributors;

        int currentDate = 0;

        public SimpleStrategy(List<Project> projects, ContributorDictionary contributors)
        {
            this.projects = projects;
            this.contributors = contributors;
        }

        public string Solve()
        {
            var (nextProject, nextContributors) = NextProject();
            var projectPlan = new List<(Project, List<Contributor>)>();
            while (nextProject != null)
            {
                projectPlan.Add((nextProject, nextContributors));
                currentDate += nextProject.duration;
                (nextProject, nextContributors) = NextProject();
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(projectPlan.Count().ToString());
            foreach (var (thisProject, thisTeam) in projectPlan)
            {
                sb.AppendLine(thisProject.name);
                sb.AppendLine(string.Join(' ', thisTeam.Select(p => p.name)));
            }
            return sb.ToString();
        }

        private (Project, List<Contributor>) NextProject()
        {
            Project nextProject = null;
            List<Contributor> nextContributors = null;
            foreach (Project project in projects)
            {
                var projectContributors = project.teamComplete(contributors);
                if (projectContributors != null && project.canCompleteBestBefore(currentDate))
                {
                    if (nextProject == null)
                    {
                        nextProject = project;
                        nextContributors = projectContributors;
                    }
                    else if (nextProject != null && project.pointsByDay > nextProject.pointsByDay)
                    {
                        nextProject = project;
                        nextContributors = projectContributors;
                    }
                }
            }
            if (nextProject != null)
                projects.Remove(nextProject);

            return (nextProject, nextContributors);
        }


    }
}