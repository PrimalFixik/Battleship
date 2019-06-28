using System.Collections.Generic;
using System.Windows.Forms;

namespace Core
{
    public class HierarchyTree
    {
        public List<string> Directories { get; set; }

        public List<string> Files { get; set; }

        public HierarchyTree()
        {
            Directories = new List<string>();
            Files = new List<string>();
        }
    }
}