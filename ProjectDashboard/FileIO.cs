using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ProjectDashboard
{
    internal static class FileIO
    {
        internal static bool WriteProjectToFile(Project inputProject) 
        {
            if (inputProject == null) return false;

            File.WriteAllText(inputProject.GetSavePath(), SerializeProjectToJson(inputProject));
           
            return true;
        }

        internal static bool ReadProjectFromFile(string projectFilePath, out Project outputProject)
        {
            outputProject = new Project("Attempt to read");
            
            var result = "";

            try
            {
                result = File.ReadAllText(projectFilePath);
            }
            catch
            {
                return false;
            }

            outputProject = DeserializeToProject(result);

            return true;
        }

        public static string SerializeProjectToJson(Project inputProject)
        {
            JObject o = (JObject)JToken.FromObject(inputProject);
            return o.ToString();
        }

        public static Project DeserializeToProject(string allText)
        {

            Project readProject =
                JsonConvert.DeserializeObject<Project>(allText);
            return readProject;
        }

        public static bool HandleProjectDefaultLocation(string defaultPath, string defaultProjectFolderName)
        {
            try
            {
                if (!Directory.Exists(Path.Combine(defaultPath, defaultProjectFolderName)))
                {
                    Directory.CreateDirectory(Path.Combine(defaultPath, defaultProjectFolderName));
                }
            } catch
            {
                return false;
            }
            return true;
            
        }

        public static bool GetProjectsFromLocation(string location, out List<Project> savedProjects)
        {
            savedProjects= new List<Project>();
            if(Directory.Exists(location))
            {
                var projectFiles = Directory.GetFiles(location).ToList();
                foreach(var projectFile in projectFiles)
                {
                    if(ReadProjectFromFile(projectFile, out Project readProject))
                    {
                        savedProjects.Add(readProject);
                    }
                }
                return true;
            }
            return false;
        }

    }
}
