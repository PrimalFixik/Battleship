using Core;
using System;
using System.IO;
using Directory = Core.Directory;
using File = Core.File;

namespace TCPServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Component fileSystem = new Directory("File system");
            Component diskC = new Directory("Disk C");

            Component pngFile = new File("12345.png");
            Component docxFile = new File("Document.docx");
            
            diskC.Add(pngFile);
            diskC.Add(docxFile);
            fileSystem.Add(diskC);
            
            fileSystem.Print();
            Console.WriteLine();
            
            diskC.Remove(pngFile);
            
            Component docsFolder = new Directory("Documents");
            Component txtFile = new File("readme.txt");
            Component csFile = new File("Program.cs");
            docsFolder.Add(txtFile);
            docsFolder.Add(csFile);
            diskC.Add(docsFolder);

            fileSystem.Print();

            DirectoryInfo dir = new DirectoryInfo(@"D:\3rdlab");
            foreach (var item in dir.GetDirectories())
            {
                Console.WriteLine(item.Name);
            }
            foreach (var item in dir.GetFiles())
            {
                Console.WriteLine(item.Name);
            }
            Console.Read();
        }
    }
}
