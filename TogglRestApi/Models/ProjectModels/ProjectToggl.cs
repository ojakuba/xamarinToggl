namespace TogglRestApi.Models
{
    public class ProjectToggl
    {
        public int id { get; set; }
        public int? wid { get; set; }
        public int? cid { get; set; }
        public string name { get; set; }
        public bool billable { get; set; }
        public bool is_private { get; set; }
        public bool active { get; set; }
        public string at { get; set; }
        public int? template_id { get; set; }
        public string color { get; set; }
    }
}
