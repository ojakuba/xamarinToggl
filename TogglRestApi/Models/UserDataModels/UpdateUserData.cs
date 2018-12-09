using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRestApi.Models.UserDataModels
{
    public class UpdateUserData
    {
        public UserData user { get; set; }

        public UpdateUserData(string fullname, string email)
        {
            user = new UserData()
            {
                fullname = fullname,
                email = email
            };
        }

        public  class UserData
        {
            public string fullname { get; set; }
            public string email { get; set; }
        }


    }
}
