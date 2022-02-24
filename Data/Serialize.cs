using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace Data
{
    public class Serialize
    {
        JsonSerializer serializer = new JsonSerializer();
       
        public void Save(string messageObject)
        {
            string folderPath = @"E:\ELM outputs\Messages";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);

            }

            string fileName;
            string filePath;

            fileName = "Message" + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
            filePath = folderPath + "\\" + fileName;

            using (StreamWriter sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, messageObject);
            }

        }

    }
}
