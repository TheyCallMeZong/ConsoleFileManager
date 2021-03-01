using System;
using System.IO;
using static Console_File_Manager.Color;

namespace Console_File_Manager
{
    /// <summary>
    /// При помощи данного класса мы будем выводить все директории и файлы по заданному пути
    /// А если мы находимся на диске С, то не будем выводить файлы, т.к. 
    /// 1) Это лишнее простронатсво 
    /// 2) Будет обидно если кто-то по ошибке их удалит
    /// </summary>
    public class ThreeFIle
    {
        public static void GetFiles(string path)
        {
            #region переменные которые понадобятся
            string c = @"C:\";
            string c1 = @"C:\\";
            string d = @"D:\";
            string d1 = @"D:\\";
            string level = "|___";
            int l = 0;
            #endregion
            Green();
            Console.WriteLine("Path: " + path);
            White();
            Console.WriteLine("Directories:");
            
            foreach (var e in Directory.GetDirectories(path)) 
            {
                l++;
                Console.WriteLine(level + " +" + e.Remove(0, path.Length));
            }

            if (!path.Equals(c) && !d.Equals(path) && !path.Equals(c1) && !d1.Equals(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                int b = 2;
                Console.SetCursorPosition(60, 1);
                Console.WriteLine("Files:");
                var g = directoryInfo.GetFiles();
                foreach (FileInfo e in g)
                {
                    Console.SetCursorPosition(60, b);
                    Console.Write(level + "-" + e.ToString().Remove(0, path.Length));
                    Yellow();
                    Console.WriteLine(" Size: " + e.Length + " bytes");
                    White();
                    b++;
                }
                Console.SetCursorPosition(0, l + 2);
            }
        }
    }
}

