using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CDirectory
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<CDirectory> Directories { get; set; }
        public List<FileLeaf> Files { get; set; }

        public CDirectory(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
    public class FileLeaf
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public FileLeaf(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
