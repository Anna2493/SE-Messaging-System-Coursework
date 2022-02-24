using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SaveTrendingList
    {
        
        public void SaveHashtag(string hashtag)
        {
            string folderPath = @"E:\ELM outputs\Twitter_Hashtag_List";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);

            }

            string fileName = "HashtagList.csv";
            string filePath = folderPath + "\\" + fileName;

            using (StreamWriter outputFile = new StreamWriter(filePath, true))
                outputFile.WriteLine(hashtag);
        }
       
    }
}
