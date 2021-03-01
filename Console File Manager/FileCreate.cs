using System;
using static Console_File_Manager.Color;
using static Console_File_Manager.ThreeFIle;

using System.IO;
using System.Text;

namespace Console_File_Manager
{
    class FileCreate
    {
        public static void FileCreator(string path, string path1)
        {
            using (FileStream fs = File.Create(path + path1))
            {
                Yellow();
                Console.WriteLine("Specify the information you want to enter in the file");
                White();
                string information = Console.ReadLine();
                byte[] info = new UTF8Encoding(true).GetBytes(information);
                fs.Write(info, 0, info.Length);
                Console.Clear();
                GetFiles(path); Green();
                Console.WriteLine("File was created"); White();
            }
        }
    }
}
