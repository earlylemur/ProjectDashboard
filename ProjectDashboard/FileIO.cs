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

        internal static bool ReadProjectFromFile(Project inputProject, out Project outputProject)
        {
            outputProject = new Project("Attempt to read");
            if (inputProject == null) return false;
            

            var result = "";

            try
            {
                result = File.ReadAllText(inputProject.GetSavePath());
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
    }
}
