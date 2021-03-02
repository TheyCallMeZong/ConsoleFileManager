using System;
using static Console_File_Manager.ClearConsole;
using static Console_File_Manager.ThreeFIle;
using static Console_File_Manager.Help;
using static Console_File_Manager.Color;
using System.Threading;
using System.IO;
using System.Text;

namespace Console_File_Manager
{
    class Program
    {
        static void Main()
        {
            #region
            Console.SetWindowSize(180, 45);
            Assistant();
            Console.Write("Click any button to get started");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(400);
            }
            Console.ReadKey();
            Clear();
            string path = null;
            Drives.GetDrives();
            bool b = true;
            CommandAndPath commandAndPath = new CommandAndPath();
            #endregion
            while (b)
            {
                #region
                //Здесь будем производить все команды
                //А когда пользовтель захочет закончить работу, то при помощи команды exit мы выходим из цикла
                //Переменной b мы присвоим false и закончим
                #endregion
                #region 
                Console.Write("$ ");
                string command = Console.ReadLine(); //пользователь вводит командную строку (она будет состоять из дейсвтия и пути или только из действия)
                string mainCommand, path1 = null;
                (mainCommand, path1) = commandAndPath.Search(command);
                #endregion
                switch (mainCommand)
                {
                    #region Name is "cd"
                    case "cd":
                        if (Directory.Exists(path1))
                        //в данном случае пользователь может сам указать полный путь
                        {
                            Clear();
                            path = path1 + @"\";
                            GetFiles(path);
                        }
                        else if (Directory.Exists(path + path1 + @"\") && !string.IsNullOrEmpty(path1))
                        //в данном случае мы переходим на новый 
                        //уровень без указания полного имени каталога
                        {
                            Clear();
                            path += path1 + @"\";
                            GetFiles(path);
                        }
                        else if (string.IsNullOrEmpty(path1)) //если пользователь ввел cd, то мы возвращаемся в предыдущюю папку 
                        {
                            try
                            {
                                var e = Directory.GetParent(path);
                                Clear();
                                path = e.ToString();
                                GetFiles(path + @"\");
                            }
                            catch { Drives.GetDrives(); }

                        }
                        //а если пользователь написал команду cd и неизвестную комбинацию
                        //то мы его предупредим, что такой директории не существует
                        else { Red(); Console.WriteLine("Directory not found"); White(); } 
                        break;
                    #endregion
                    #region Name is "dld"
                    case "dld":
                        if (string.IsNullOrEmpty(path1))
                            Console.WriteLine("Specify directory");
                        else
                        {
                            if (Directory.Exists(path + path1))
                            {
                                Red();
                                Console.WriteLine($"Are you sure you want to delete {path1}?");
                                White();
                                string s = Console.ReadLine();
                                if (s.Equals("yes"))
                                {
                                    try
                                    {
                                        var directory = new DirectoryInfo(path + path1);
                                        var fi = directory.GetFiles();
                                        foreach (var f in fi)
                                        {
                                            f.Delete();
                                        }
                                        Directory.Delete(path + path1 + @"\", true);
                                    }
                                    catch (Exception) {Console.WriteLine("Access error");}
                                }
                                else
                                    continue;
                                Clear();
                                GetFiles(path);
                                Green();
                                Console.WriteLine("Directoty was deleted");
                                White();
                            }
                            else Console.WriteLine("Directory not found");
                        }
                        break;
                    #endregion
                    #region Name id "def"
                    case "def":
                        if (string.IsNullOrEmpty(path1))
                            Console.WriteLine("Specify file");
                        else
                        {
                            if (File.Exists(path + path1))
                            {
                                Red();
                                Console.WriteLine($"Are you sure you want to delete {path1}?");
                                White();
                                string s = Console.ReadLine();
                                if (s.Equals("yes")) File.Delete(path + path1);
                                else
                                    continue;
                                Clear();
                                GetFiles(path);
                                Green();
                                Console.WriteLine("File was deleted");
                                White();
                            }
                            else { Red(); Console.WriteLine("File not found"); White(); }
                        }
                        break;
                    #endregion
                    #region Name is move
                    case "move":
                        string[] vs = path1.Split(' '); //помимо команды и файла, нам еще передается путь, куда нужно переместить файл
                        path1 = vs[0];
                        string pathFrom = vs[1]; //директория в которую мы будем перемещать файл
                        if (File.Exists(path + path1))
                        {
                            if (File.Exists(pathFrom + @"\" + path1))
                            {
                                Console.WriteLine("A file with this name exists. Overwrite a file?");
                                string answer = Console.ReadLine();
                                if (answer.Equals("yes"))
                                    File.Delete(pathFrom + @"\" + path1);
                                else
                                    continue;
                            }
                            try { File.Move(path + path1, pathFrom + @"\" + path1); Clear(); GetFiles(path); Green(); Console.WriteLine("File moved"); White(); }
                            catch (AccessViolationException) { Console.WriteLine("Access error"); }
                        }
                        else
                            Console.WriteLine("File not found");
                        break;
                    #endregion
                    #region Name is cf
                    case "cf":
                        try
                        {
                            //в данном методе path1 будет выступать не как путь, а как название файла
                            if (!(path == null))
                                FileCreate.FileCreator(path, path1);
                        }
                        catch { Red(); Console.WriteLine("Access error"); White(); }
                        break;
                    #endregion
                    #region Name is crd
                    case "crd":
                        try
                        {
                            if (!Directory.Exists(path + path1))
                            {
                                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                                directoryInfo.Create();
                                directoryInfo.CreateSubdirectory(path1);
                                Clear();
                                GetFiles(path);
                                Green();
                                Console.WriteLine("Directory was created");
                                White();
                            }
                            else
                                Console.WriteLine("Directory with this name exists");
                        }
                        catch { Red(); Console.WriteLine("Access error"); White(); }
                        break;
                    #endregion
                    #region Name is read
                    case "read":
                        if (File.Exists(path + path1))
                            using (StreamReader sr = File.OpenText(path + path1))
                            {
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                    Console.Write(s);
                                Console.WriteLine();
                            }
                        else { Red(); Console.WriteLine("File not found"); White(); }
                    break;
                    #endregion
                    #region Name is write
                    case "write":
                        if (File.Exists(path + path1))
                        {
                            Yellow();
                            Console.WriteLine("Specify the information you want to enter in the file");
                            White();
                            var filetext = Console.ReadLine();
                            File.AppendAllText(path + path1, "\n" + filetext);

                        }
                        else //если же файла нет, то мы создаем и заносим информацию
                            FileCreate.FileCreator(path, path1);
                        break;
                    #endregion
                    #region Name is ren
                    case "ren":
                        if (File.Exists(path + path1))
                        {
                            Console.WriteLine($"What do you want to name the file {path1}?");
                            string rename = Console.ReadLine();
                            if (rename != path1)
                            {
                                string[] text = File.ReadAllLines(path + path1);
                                File.Create(rename);
                                File.Delete(path + path1);
                                File.AppendAllLines(path + rename, text);
                                Clear();
                                GetFiles(path);
                                Green();
                                Console.WriteLine("File was renamed");
                                White();
                            }
                            else { Console.WriteLine("You can`t also name a file"); }
                        }
                        else
                            Console.WriteLine("File not found");
                        break;
                    #endregion
                    #region Реализованные команды
                    case "help":
                        Assistant();
                        break;
                    case "exit":
                        b = false;
                        break;
                    case "clear":
                        Clear();
                        try { GetFiles(path); }
                        catch { Drives.GetDrives(); }
                        break;
                    default:
                        Red();
                        Console.WriteLine($"command {command} not found");
                        White();
                        break;
                        #endregion
                }

            }
        }
    }
}
