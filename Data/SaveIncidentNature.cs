using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Data
{
    public class SaveIncidentNature
    {
        public void SaveNature(string nature)
        {
            string folderPath = @"E:\ELM outputs\Significant_Incident_Report_Nature_List";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);

            }

            string fileName = "NatureList.csv";
            string filePath = folderPath + "\\" + fileName;

            using (StreamWriter outputFile = new StreamWriter(filePath, true))
                outputFile.WriteLine(nature);

        }
    }
}
