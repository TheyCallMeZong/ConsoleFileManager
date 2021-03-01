namespace Console_File_Manager
{
    /// <summary>
    /// Данный метод позволит найти команду и установит новый путь, если это команды связанны с путем (cd, mf, getinfo)
    /// </summary>
    class CommandAndPath
    {
        private string path; //путь, который нам передали (его мы достаем)
        private string mainCommand; //основная команда (cd, mf, getinfo)
        /// <summary>
        /// метод, который позволит нам найти путь и команду
        /// </summary>
        /// <param name = "command" > команда пользователя</param>
        /// <returns></returns>
        public (string, string) Search(string command)
        {
            if (string.IsNullOrEmpty(command))
                path = mainCommand = null;
            else if (command.Contains("cd ") || command.Contains("cf "))
            {
                mainCommand = command.Substring(0, 2);
                path = command.Remove(0, 3);
            }
            else if (command.Contains("dld ") || command.Contains("def ") || command.Contains("crd "))
            {
                mainCommand = command.Substring(0, 3);
                path = command.Remove(0, 4);
            }
            else if (command.Contains("read ") || command.Contains("move "))
            {
                path = command.Remove(0,5);
                mainCommand = command.Substring(0, 4);
            }
            else if (command.Contains("write "))
            {
                path = command.Remove(0,6);
                mainCommand = command.Substring(0,5);
            }
            else
            {
                mainCommand = command; //Если комнада не предназначена для работы с файлами, то просто выводим эту команду
                path = null;
            }
            return (mainCommand, path);

        }

    }
}
