using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace testXamarin.Models
{
    public class UserPresentationData : INotifyPropertyChanged
    {
        private string _fullname, _email;

        public string FullName {
            get
            {
                return _fullname;
            }
            set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Update(string fullname = default(string), string email = default(string))
        {
            FullName = fullname;
            Email = email;
        }
    }
}
