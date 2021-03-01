using System;
using System.IO;

namespace Console_File_Manager
{
    class Drives
    {
        public static void GetDrives()
        {
            var drive = DriveInfo.GetDrives();
            foreach (var element in drive)
                Console.WriteLine(element + "\tFree space:" + element.AvailableFreeSpace + " bytes");
        }
    }
}
