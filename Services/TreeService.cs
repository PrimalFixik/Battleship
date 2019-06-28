using Core;
using Interfaces;
using System;
using System.IO;
using System.Linq;

namespace Services
{
    public class TreeService : ITreeService
    {
        private readonly string root = string.Concat(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 10), "\\root");
        private HierarchyTree _tree = new HierarchyTree();

        public void GetArchive(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                //TODO SEND ROOT-FOLDER ARCHIVE OVER TCP
            }
            else
            {
                //TODO SEND PATH-FOLDER ARCHIVE OVER TCP
            }
        }

        public HierarchyTree GetTree()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(root);
            var tree = new HierarchyTree();
            tree.Files.AddRange(directoryInfo.GetFiles().Select(x => x.FullName));
            tree.Directories.AddRange(directoryInfo.GetDirectories().Select(x => x.FullName));
            return tree;
        }

        public HierarchyTree GetTree(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            var tree = new HierarchyTree();
            if (string.IsNullOrEmpty(directoryInfo.Extension))
            {
                tree.Files.AddRange(directoryInfo.GetFiles().Select(x => x.FullName));
                tree.Directories.AddRange(directoryInfo.GetDirectories().Select(x => x.FullName));
                return tree;
            }
            return null;
        }
    }
}