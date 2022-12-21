using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjectDashboard;
using System.Diagnostics;
using System.IO;

namespace ProjectDashBoardTests
{
    [TestClass]
    public class LauncherTests
    {
        [TestMethod]
        public void LaunchProject()
        {
            var project = DefaultProject.CreateDefaultProject();
            Assert.IsTrue(project.Launch());
            
        }
        [TestMethod]
        public void LaunchWeb()
        {
            var project = DefaultProject.CreateDefaultProject();
            Assert.IsTrue(project.WebPaths[0].Launch());

        }

        [TestMethod]
        public void LaunchSoftware()
        {
            var project = DefaultProject.CreateDefaultProject();
            Assert.IsTrue(project.SoftwarePaths[0].Launch());

        }

        [TestMethod]
        public void FindSoftwareExe()
        {
            var path = "C:\\Users\\1990olfy\\AppData\\Roaming\\Spotify\\Spotify.exe";
            Assert.IsTrue(File.Exists(path));
        }
    }
}
