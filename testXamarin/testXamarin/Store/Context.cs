using System.Collections.Generic;
using testXamarin.Models;
using TogglRestApi;
using TogglRestApi.Models;

namespace testXamarin.Store
{
    public static class Context
    {
        public static RestApi RestApi { get; set; }
        public static UserDataToggl UserData { get; set; }
        public static TaskPresentationLayout SelectedTaskData { get; set; }
        public static List<WorkspaceToggl> Workspaces { get; set; }
        public static List<ProjectToggl> Projects { get; set; }
        public static List<TimeEntries> TimeEntries { get; set; }

        public static async void UpdateProjects()
        {
            Projects = await RestApi.GetWorkspaceProjects(UserData.default_wid);
        }

        public static async void UpdateWorkspaces()
        {
            Workspaces = await RestApi.GetWorkspaces();
        }

        public static async void UpdateTimeEntries()
        {
            TimeEntries = await RestApi.GetAllTimeEntries();
        }

        
    }
}
