using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProjectDashboard
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private Project _currentProject = new Project("");
        private WebPath _selectedWebPath = new WebPath("");
        private FolderPath _selectedFolderPath = new FolderPath("");
        private Software _selectedSoftwarePath = new Software("");
        private Contact _selectedContact = new Contact();
        private TabItem _selectedTabItem = new TabItem();
        private ObservableCollection<Project> _myProjects = new ObservableCollection<Project>();
     
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

        public string ProjectSavePath
        {
            get { return CurrentProject.GetSavePath(); }
            set { CurrentProject.SetSavePath(value); OnPropertyChanged(nameof(ProjectSavePath)); }
        }

        public TabItem SelectedTabItem
        {
            get { return _selectedTabItem; }
            set { _selectedTabItem = value; OnPropertyChanged(nameof(SelectedTabItem)); }
        }

        public ObservableCollection<FolderPath> FolderPaths
        {
            get { return CurrentProject.FolderPaths; }
        }
        public FolderPath SelectedFolderPath
        {
            get { return _selectedFolderPath; }
            set
            {
                _selectedFolderPath = value;
                OnPropertyChanged(nameof(SelectedFolderPath));
            }
        }
        public ObservableCollection<WebPath> WebPaths
        {
            get { return CurrentProject.WebPaths; }
        }
        public WebPath SelectedWebPath
        {
            get { return _selectedWebPath; }
            set { _selectedWebPath = value;
                OnPropertyChanged(nameof(SelectedWebPath));
            }
        }

        public ObservableCollection<Contact> Contacts
        {
            get { return CurrentProject.Contacts; }
        }
        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public ObservableCollection<Software> SoftwarePaths
        {
            get { return CurrentProject.SoftwarePaths; }
        }
        public Software SelectedSoftwarePath
        {
            get { return _selectedSoftwarePath; }
            set
            {
                _selectedSoftwarePath = value;
                OnPropertyChanged(nameof(SelectedSoftwarePath));
            }
        }

        public MainWindowViewModel() { }

        public ObservableCollection<Project> MyProjects
        {
            get
            {
                return _myProjects;
            }
            set
            {
                _myProjects = value;
                OnPropertyChanged(nameof(MyProjects));
            }
        }


        public void SetProject()
        {
            CurrentProject = DefaultProject.CreateDefaultProject();
        }

        public void AddFolder()
        {
            if(FolderPaths != null)
            {
                FolderPaths.Add(new FolderPath("NewPath"));
            }
        }
        public void AddWebpath()
        {
            if (WebPaths != null)
            {
                WebPaths.Add(new WebPath("NewPath"));
            }
        }
        public void AddSoftwarePath()
        {
            if (SoftwarePaths != null)
            {
                SoftwarePaths.Add(new Software("NewPath"));
            }
        }

        public void AddContact()
        {
            if (Contacts != null)
            {
                Contacts.Add(new Contact());
            }
        }

        public bool SaveProject()
        {
            if (CurrentProject != null && !String.IsNullOrEmpty(CurrentProject.Path))
            {
                return FileIO.WriteProjectToFile(CurrentProject);
            }
            return false;
        }

        public bool LoadProject()
        {
            if (CurrentProject != null && !String.IsNullOrEmpty(CurrentProject.Path))
            {
                if(FileIO.ReadProjectFromFile(CurrentProject.Path, out Project readProject))
                {
                    CurrentProject = readProject;
                    return true;
                }
            }
            return false;
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
