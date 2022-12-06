using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ProjectDashboard
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private Project _currentProject = new Project();
        public Project CurrentProject 
        {
            get { return _currentProject; }
            set { 
                _currentProject = value; 
                OnPropertyChanged(nameof(CurrentProject));
                OnPropertyChanged(nameof(FolderPaths));
                OnPropertyChanged(nameof(WebPaths));
                OnPropertyChanged(nameof(Contacts));
                OnPropertyChanged(nameof(SoftwarePaths));
            } 
        }

        public ObservableCollection<FolderPath> FolderPaths
        {
            get { return CurrentProject.FolderPaths; }
        }

        public ObservableCollection<WebPath> WebPaths
        {
            get { return CurrentProject.WebPaths; }
        }

        public ObservableCollection<Contact> Contacts
        {
            get { return CurrentProject.Contacts; }
        }

        public ObservableCollection<Software> SoftwarePaths
        {
            get { return CurrentProject.SoftwarePaths; }
        }

        public MainWindowViewModel() { }


        public void SetProject()
        {
            CurrentProject = DefaultProject.CreateDefaultProject();
        }
 
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
