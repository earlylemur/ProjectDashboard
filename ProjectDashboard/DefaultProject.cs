using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectDashboard
{
    public static class DefaultProject
    {
        public static Project CreateDefaultProject()
        {
            var project = new Project();
            project.Label = "DefaultProject";
            project.Path = "C:\\Users\\Public\\Documents\\Projects\\ProjectA";

            project.WebPaths = new ObservableCollection<WebPath>() 
            {
                new WebPath("https:\\\\stackoverflow.com"),
                new WebPath("https:\\\\github.com\\olemfyen\\ProjectDashboard")
            };

            project.SoftwarePaths = new ObservableCollection<Software>()
            {
                new Software("C:\\Users\\Admin\\AppData\\Roaming\\Spotify\\Spotify.exe")
            };
            

            return project;
        }
    }
}
