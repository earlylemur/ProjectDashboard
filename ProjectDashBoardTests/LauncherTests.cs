using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjectDashboard;
using System.Diagnostics;

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
            Assert.IsTrue(project.Webpaths[0].Launch());

        }

        [TestMethod]
        public void LaunchSoftware()
        {
            var project = DefaultProject.CreateDefaultProject();
            Assert.IsTrue(project.SoftwarePaths[0].Launch());

        }
    }
}
