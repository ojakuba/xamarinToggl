using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TogglRestApi.Models;

namespace testXamarin.Models
{
    public class TaskPresentationLayout: INotifyPropertyChanged
    {
        private string _workspace, _project, _description;
        private DateTime _startTime;
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
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged("StartTime");
                    OnPropertyChanged("IsRunning");
                }
            }
        }
        public bool IsRunning
        {
            get
            {
                return _startTime != default(DateTime);
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

        public void Reset()
        {
            WorkspaceName = default(string);
            ProjectName = default(string);
            Description = default(string);
            StartTime = default(DateTime);
        }
    }
}
