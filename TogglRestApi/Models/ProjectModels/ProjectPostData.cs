using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRestApi.Models.ProjectModels
{
    public class ProjectPostData
    {
        public ProjectToggl project { get; set; }

        public ProjectPostData() { }
        public ProjectPostData(ProjectToggl projectToggl)
        {
            project = projectToggl;
        }
    }
}
