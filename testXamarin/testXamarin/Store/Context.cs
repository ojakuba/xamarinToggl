using System.Collections.Generic;
using testXamarin.Models;
using TogglRestApi;
using TogglRestApi.Models;

namespace testXamarin.Store
{
    public static class Context
    {
        public static RestApi RestApi { get; set; }
        public static TaskPresentationLayout ActualRunningTask { get; set; }
        public static List<WorkspaceToggl> Workspaces { get; set; }
        public static List<ProjectToggl> Projects { get; set; }

        public static async void ReloadProjects()
        {
          //  Projects = RestApi.
        }

        public static async void ReloadWorkspaces()
        {
            Workspaces = await RestApi.GetWorkspaces();
        }
    }
}
