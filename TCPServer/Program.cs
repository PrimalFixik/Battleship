using Core;
using System;
using System.IO;

namespace TCPServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            Client client = new Client();
            
            CFile file = new CFile();
            Console.WriteLine("Client: I get a simple component:");
            client.GetAllChildren(file);

            DirectoryInfo dir = new DirectoryInfo(@"D:\3rdlab");
            Folder directory1 = new Folder();
            directory1.name = dir.Name;

            directory1.Add(new CFile());
            directory1.Add(new CFile());
            Folder directory2 = new Folder();
            directory2.Add(new CFile());
            root.Add(directory1);
            root.Add(directory2);
            Console.WriteLine("Client: Now I've got a composite tree:");
            client.GetAllChildren(root);

            Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
            client.GetAllChildrenWithAdding(root, file);*/

            CDirectory root = new CDirectory("root", @"D:\3rdlab");
            Folder folder = new Folder();
            folder.Print(root);
        }
    }
}
