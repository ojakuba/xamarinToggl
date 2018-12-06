using System.Collections.Generic;

namespace TogglRestApi.Models
{
    public class UserDataToggl
    {
        public string id { get; set; }
        public string api_token { get; set; }
        public int default_wid { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }

        public string jquery_timeofday_format { get; set; }
        public string jquery_date_format { get; set; }
        public string timeofday_format { get; set; }
        public string date_format { get; set; }
        public bool store_start_and_stop_time { get; set; }
        public int beginning_of_week { get; set; }
        public string language { get; set; }


        public string image_url { get; set; }
        public bool sidebar_piechart { get; set; }
        public string at { get; set; }
        public string created_at { get; set; }
        public int retention { get; set; }
        public bool record_timeline { get; set; }
        public bool render_timeline { get; set; }
        public bool timeline_enabled { get; set; }
        public bool timeline_experiment { get; set; }
        public NewBlogPost new_blog_post { get; set; }

        public bool should_upgrade { get; set; }
        public bool achievements_enabled { get; set; }
        public string timezone { get; set; }
        public bool openid_enabled { get; set; }
        public bool send_product_emails { get; set; }
        public bool send_weekly_report { get; set; }
        public bool send_timer_notifications { get; set; }

        public string last_blog_entry { get; set; }

        public IEnumerable<WorkspaceToggl> workspaces { get; set; }
        public IEnumerable<TagToggl> tags { get; set; }
        public string duration_format { get; set; }

        public class NewBlogPost
        {
            public string title { get; set; }
            public string url { get; set; }
            public string category { get; set; }
            public string pub_date { get; set; }
        }
    }
}
