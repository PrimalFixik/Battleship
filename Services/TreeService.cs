using Core;
using Ionic.Zip;
using Interfaces;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Services
{    
    public class TreeService : ITreeService
    {
        public static IPAddress ipAddress = IPAddress.Parse("192.168.1.12");
        public static TCPFileSender sender = new TCPFileSender(ipAddress, 11111);
        public static TCPFileReciever reciever = new TCPFileReciever(ipAddress, 11111);

        private readonly string root = string.Concat(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 10), "\\root");
        private HierarchyTree _tree = new HierarchyTree();

        public void GetArchive(string path)
        {
            ZipFile zip = new ZipFile();
            if (string.IsNullOrEmpty(path))
            {
                path = @"D:\Battleship\TCPServer\root\";
                zip.AddDirectory(path);
                path = path + "root.zip";
                zip.Save(path);
                Send(path);
            }
            else
            {
                zip.AddDirectory(path);
                path = path + ".zip";
                zip.Save(path);
            }
        }

        public FileInfo Send(string path)
        {
            return sender.sendFile(path);
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