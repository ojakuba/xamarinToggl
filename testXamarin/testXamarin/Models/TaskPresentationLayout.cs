using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TogglRestApi.Models;

namespace testXamarin.Models
{
    public class TaskPresentationLayout: INotifyPropertyChanged
    {
        private string _workspace, _project;
        public string WorkspaceName
        {
            get
            {
                return _workspace;
            }
            set
            {
                if (_workspace != value)
                {
                    _workspace = value;
                    OnPropertyChanged("WorkspaceName");
                }
            }
        }
        public string ProjectName {
            get
            {
                return _project;
            }
            set
            {
                if (_project != value)
                {
                    _project = value;
                    OnPropertyChanged("ProjectName");
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

    }
}
