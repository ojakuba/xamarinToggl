using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRestApi.Models.ProjectModels
{
    public class ProjectPostData
    {
        public ProjectPostDataData project { get; set; }

        public ProjectPostData(string name, int wid)
        {
            project = new ProjectPostDataData()
            {
                name = name,
                wid = wid
            };
        }

        public class ProjectPostDataData
        {
            public int wid { get; set; }
            public string name { get; set; }
        }
    }
}
