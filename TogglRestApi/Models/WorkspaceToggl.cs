namespace TogglRestApi.Models
{
    public class WorkspaceToggl
    {
        public int id { get; set; }
        public string name { get; set; }
        public int profile { get; set; }
        public bool premium { get; set; }
        public bool admin { get; set; }
        public int default_hourly_rate { get; set; }
        public string default_currency { get; set; }
        public bool only_admins_may_create_projects { get; set; }
        public bool only_admins_see_billable_rates { get; set; }
        public bool only_admins_see_team_dashboard { get; set; }
        public bool projects_billable_by_default { get; set; }
        public int rounding { get; set; }
        public int rounding_minutes { get; set; }
        public string api_token { get; set; }
        public string at { get; set; }
        public bool ical_enabled { get; set; }

    }
}
