using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Diagnostics;
using System.IO;
using System.Collections.ObjectModel;

namespace ProjectDashboard
{

    // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process?view=net-7.0
    // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-7-0
    public class Rootobject
    {
        public Project Project { get; set; }
    }
    /// <summary>
    /// Holding information about a 
    /// </summary>
    public class Project : ILaunchable
    {
        public string Label { get; set; } = "";
        public ObservableCollection<WebPath> WebPaths { get; set; } = new ObservableCollection<WebPath>();
        public ObservableCollection<FolderPath> FolderPaths { get; set; } = new ObservableCollection<FolderPath>();
        public ObservableCollection<Software> SoftwarePaths { get; set; } = new ObservableCollection<Software>();
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public string Path { get; set; } = "";

        public bool Launch()
        {
            try
            {
                Process.Start(Path);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }


    public class FolderPath : ILaunchable
    {
        public string Label { get; set; } = "";
        public string Path { get; set; } = "";

        public bool Launch()
        {
            try
            {
                Process.Start(Path);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }

    public class Software : ILaunchable
    {
        public string Path { get; set; } = "";
        public string Label { get; set; } = "";
        public Software(string path)
        {
            Path = path;
        }

        public bool Launch()
        {
            try
            {
                Process.Start(Path);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }

    public class WebPath : ILaunchable
    {
        public string Path { get; set; } = "";
        public string Label { get; set; } = "";
        public WebPath(string path)
        {
            Path = path;
        }

        public bool Launch()
        {
            try
            {
                Process.Start(Path);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }

    }

    public interface ILaunchable
    {
        string Path { get; set; }
        string Label { get; set; }
        bool Launch();
    }


}
