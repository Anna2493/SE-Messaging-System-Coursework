using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SaveMentionsList
    {
        public void SaveMention(string mention)
        {
            string folderPath = @"E:\ELM outputs\Twitter_Mention_List";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);

            }

            string fileName = "MentionList.csv";
            string filePath = folderPath + "\\" + fileName;

            using (StreamWriter outputFile = new StreamWriter(filePath, true))
                outputFile.WriteLine(mention);
        }
    }
}
