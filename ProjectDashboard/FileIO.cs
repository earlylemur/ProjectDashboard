using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectDashboard
{
    internal static class FileIO
    {
        internal static bool WriteToFile(Project inputProject) 
        {
            if (inputProject == null) return false;

            File.WriteAllText(inputProject.GetSavePath(), inputProject.SerializeToJson());
           
            return true;
        }
    }
}
