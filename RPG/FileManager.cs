using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace RPG
{
    public class FileManager
    {
        string path;
        public FileManager()
        {
            path = System.IO.Path.GetFullPath(@"Program.cs");
            path = System.IO.Path.GetDirectoryName(path);
            path += "\\Data";
        }

        public FileStream openFile(string path)
        {
            string filePath = this.path;
            filePath += "\\" + path;
            FileStream f = File.Open(filePath, FileMode.OpenOrCreate);
            return f;
        }

        public string readFile(FileStream file)
        {
            string fileContents;
            using (StreamReader reader = new StreamReader(file))
            {
                fileContents = reader.ReadToEnd();
            }
            return fileContents;
        }
    }
}
