using System;
using System.Collections.Generic;
using System.Linq;

namespace polyglots.practice._2022
{
    public class SimpleStrategy : IStrategy
    {
        List<Project> projects;
        ContributorDictionary contributors;

        public SimpleStrategy( List<Project> projects, ContributorDictionary contributors )
        {
            this.projects = projects;
            this.contributors = contributors;
        }

        private Project nextProject() {
            Project nextProject;
            foreach ( Project project in projects ) {
                if ( project.canComplete( contributors ) && project.canCompleteBestBefore() ) {
                    if ( nextProject == null ) {
                        nextProject = project
                    } elseif ( nextProject != null && project.pointsByDay > nextProject.pointsByDay ) {
                        nextProject = project;
                    }
                }
            }

            return nextProject;
        }

        
    }
}