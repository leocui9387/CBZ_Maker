using System;
using System.IO;
using System.IO.Compression;

namespace CBZ_Maker
{
    class Program
    {
        static void Main(string[] args)
        {
            String currDir = Directory.GetCurrentDirectory();
            String targetDir = Path.Combine(currDir, Path.Combine(args));

            Console.WriteLine(currDir);
            Console.WriteLine(targetDir);

            DirectoryInfo d = new DirectoryInfo(targetDir);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles(); //Getting Text files

            String outName;
            int counter = 1;
            foreach (FileInfo file in Files)
            {
                
                outName = "000" + counter++;
                File.Move(targetDir + "\\" + file.Name, targetDir + "\\" + outName.Substring(outName.Length - 3) + "." + file.Extension);
                
            }

            ZipFile.CreateFromDirectory(targetDir, ".\\"+ String.Join("",args) + ".cbz");

        }
    }
}
