namespace TogglRestApi.Models
{
    public class TimeEntryPostData
    {
        public TimeEntries time_entry { get; set; }

        public TimeEntryPostData()
        {

        }

        public TimeEntryPostData(TimeEntries timeEntries)
        {
            time_entry = timeEntries;
        }

        public TimeEntryPostData(Models.StartTimeEntry timeEntry)
        {
            time_entry = new TimeEntries()
            {
                pid = timeEntry.pid,
                decsription = timeEntry.description,
                tags = timeEntry.tags,
                created_with = timeEntry.created_with
            };
        }
    }
}
