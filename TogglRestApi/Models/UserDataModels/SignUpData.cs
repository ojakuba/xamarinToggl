namespace TogglRestApi.Models
{
    public class SignUpData
    {
        public SignupUser user { get; set; }

        public SignUpData() { }
        public SignUpData(SignupUser user) {
            this.user = user;
        }
        public SignUpData(string email, string password)
        {
            this.user = new SignupUser(email,password);
        }

        public class SignupUser
        {
            public string email { get; set; }
            public string password { get; set; }

            public SignupUser(string email, string password)
            {
                this.email = email;
                this.password = password;
            }
        }
    }
}
