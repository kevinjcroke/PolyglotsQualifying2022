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
            var nextProject = NextProject();
            List<Project> projectPlan = new List<Project>();
            while (nextProject != null)
            {
                projectPlan.Add(nextProject);
                currentDate += nextProject.duration;
                nextProject = NextProject();
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(projectPlan.Count().ToString());
            foreach (var thisProject in projectPlan)
            {
                sb.AppendLine(thisProject.name);
                var team = thisProject.teamComplete(contributors);
                sb.AppendLine(string.Join(' ', team.Select(p => p.name)));
            }
            return sb.ToString();
        }

        private Project NextProject()
        {
            Project nextProject = null;
            foreach (Project project in projects)
            {
                if (project.canComplete(contributors) && project.canCompleteBestBefore(currentDate))
                {
                    if (nextProject == null)
                    {
                        nextProject = project;
                    }
                    else if (nextProject != null && project.pointsByDay > nextProject.pointsByDay)
                    {
                        nextProject = project;
                    }
                }
            }
            if (nextProject != null)
                projects.Remove(nextProject);

            return nextProject;
        }


    }
}