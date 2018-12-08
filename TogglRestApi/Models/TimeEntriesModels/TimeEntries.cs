using System;
using System.Collections.Generic;

namespace TogglRestApi.Models
{
    public class TimeEntries
    {
        public int id { get; set; }

        /// <summary>
        /// The name of your client app
        /// </summary>
        public string created_with { get; set; }
        /// <summary>
        /// Project ID
        /// </summary>
        public int pid { get; set; }
        /// <summary>
        /// Task ID
        /// </summary>
        public int? tid { get; set; }
        public string description { get; set; }
        public IEnumerable<string> tags { get; set; }
        /// <summary>
        ///  Time entry duration in seconds. 
        ///  If the time entry is currently running, the duration attribute contains a negative value, denoting the start of the time entry in seconds since epoch (Jan 1 1970). 
        ///  The correct duration can be calculated as current_time + duration, where current_time is the current time in seconds since epoch.
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// Workspace ID
        /// </summary>
        public int? wid { get; set; }
        /// <summary>
        /// string, required, ISO 8601
        /// </summary>
        public string start { get; set; }
        /// <summary>
        /// string, required, ISO 8601
        /// </summary>
        public string stop { get; set; }

        public TimeEntries() { }

        public TimeEntries(string description, int projectID, DateTime startTask, DateTime stopTask = default(DateTime),
            int? workspaceID = null, int? taskID = null, 
            IEnumerable<string> tagEnumerable = default(IEnumerable<string>))
        {
            created_with = "Snowball";
            this.description = description;
            wid = workspaceID;
            pid = projectID;
            tid = taskID;

            var difference = stopTask == DateTime.MinValue ?
                startTask.Subtract(stopTask) :
                startTask.Subtract(DateTime.Now);

            duration = difference.Seconds;
            start = startTask.ToString("o");

            stop = stopTask == default(DateTime) ? null : stopTask.ToString("o");
            tags = tagEnumerable;
        }
    }
}
