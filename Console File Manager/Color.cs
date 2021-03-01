using System;

namespace Console_File_Manager
{
    class Color
    {
        /// <summary>
        /// изменяем цвет текста в консоли
        /// </summary>
        public static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void White()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        } 
        public static void Yellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}
