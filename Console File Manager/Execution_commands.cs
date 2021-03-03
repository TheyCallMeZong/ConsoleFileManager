namespace Console_File_Manager
{
    public class Execution_commands
    {
        public enum Commands
        {
            cd, //change directory (сменить деректорию)
            def, //delete file (удалить файл)
            dld, //delete directory (удаляем директорию)
            move, //move file (переместить файл)
            cf, //create file (создать файл)
            ren, //rename file (переименовать файл
            crd, //create directory (создать директорию)
            read, //прочитать содержимое файла
            write, //записать что нибудь в файл
            help, //данная команда выдает список команд
            exit, //закончить работу
            clear //очистить консоль
        }
    }
}
