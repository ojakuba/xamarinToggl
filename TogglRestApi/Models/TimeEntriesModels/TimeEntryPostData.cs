namespace TogglRestApi.Models
{
    public class StartTimeEntryPostData
    {
        public StartTimeEntry time_entry { get; set; }

        public StartTimeEntryPostData()
        {

        }

        public StartTimeEntryPostData(Models.StartTimeEntry timeEntry)
        {
            time_entry = timeEntry;
        }
    }
}
