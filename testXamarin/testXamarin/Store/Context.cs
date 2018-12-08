using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
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
        public static TimeEntries RunningTask { get; set; }

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

        public static async Task UpdateRunningTask()
        {
            UpdateWorkspaces();
            UpdateProjects();
            RunningTask = (await RestApi.GetCurrentTimeEntries()).data;
            if(RunningTask == default(TimeEntries))
            {
                SelectedTaskData = new TaskPresentationLayout();
                return;
            }
            var startTime = DateTime.Parse(RunningTask.start, null, DateTimeStyles.RoundtripKind);
            var projectName = RunningTask.pid ==0 ? default(string) : Projects.FirstOrDefault(p => p.id == RunningTask.pid).name;

            SelectedTaskData = new TaskPresentationLayout()
            {
                Description = RunningTask.description,
                ProjectName = projectName,
                WorkspaceName = Workspaces.FirstOrDefault(w => w.id == RunningTask.wid).name,
                StartTime = startTime
            };
        }
    }
}
