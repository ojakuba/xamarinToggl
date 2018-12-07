using System;
using System.Collections.Generic;
using System.Text;
using TogglRestApi.Models;

namespace testXamarin.Models
{
    public class TaskPresentationLayout: TimeEntries
    {
        public string WorkspaceName { get; set; }
        public string ProjectName { get; set; }
    }
}
