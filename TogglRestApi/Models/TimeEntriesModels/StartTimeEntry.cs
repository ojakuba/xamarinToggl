using System.Collections.Generic;

namespace TogglRestApi.Models
{
    public class StartTimeEntry
    {
        public string description { get; set; }
        public List<string> tags { get; set; }
        public int pid { get; set; }
        public string created_with { get; set; }
    }
}
