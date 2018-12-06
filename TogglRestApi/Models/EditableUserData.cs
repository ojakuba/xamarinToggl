using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRestApi.Models
{
    public class EditableUserData
    {
        public string email { get; set; }
        public string fullname { get; set; }
        public bool send_product_emails { get; set; }
        public bool send_weekly_report { get; set; }
        public bool send_timer_notifications { get; set; }
        public bool store_start_and_stop_time { get; set; }
        public int beginning_of_week { get; set; }
        public string timezone { get; set; }
        public string timeofday_format { get; set; }
        public string date_format { get; set; }
    }
}
