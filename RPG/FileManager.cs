using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class FileManager
    {
        string path;
        public FileManager()
        {
            path = System.IO.Path.GetFullPath(@"Enemy.cs");
            Console.WriteLine(path);
        }
    }
}
