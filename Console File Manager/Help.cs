using static Console_File_Manager.Execution_commands;
using System;

namespace Console_File_Manager
{
    class Help
    {
        /// <summary>
        /// При вызове метода Assistant у нас будут высвечиваться списки команд
        /// </summary>
        public static void Assistant()
        {
            Console.WriteLine("list of commands: ");
            Console.WriteLine(Commands.cd + " - change directory");
            Console.WriteLine(Commands.cf + " - create file");
            Console.WriteLine(Commands.crd + " - create directory");
            Console.WriteLine(Commands.read + " - read text in file");
            Console.WriteLine(Commands.write + " - write text in file");
            Console.WriteLine(Commands.def + " - delete file");
            Console.WriteLine(Commands.dld + " - delete directory");
            Console.WriteLine(Commands.move + " - move file");
            Console.WriteLine(Commands.exit + " - exit");
            Console.WriteLine(Commands.clear + " - clear the console");
        }
    }
}
