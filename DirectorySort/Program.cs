using System;
using System.IO;

namespace DirectorySort
{
    class DirectorySort
    {
        private static SettingSerialize settings;

        private static void Main(string[] args)
        {
            SettingSerialize s = Settings.LoadSettings();

            if (s.firstRun)
            {
                Console.WriteLine($"Your Settings.json file was successfully created on \"{Directory.GetCurrentDirectory()}\".");
                
                Console.ReadKey();
                return;
            }

            if (!Directory.Exists(s.Path))
            {
                Console.WriteLine("Wrong path to directory");

                Console.ReadKey();
                return;
            }

            settings = s;

            Console.WriteLine("Directory sorter has been started successfully!");

            Update();
        }

        private static void Update()
        {
            while (true)
            {
                DirectoryChecker();

                Thread.Sleep(1000);
            }
        }

        private static void DirectoryChecker()
        {
            string[] files = Directory.GetFiles(settings.Path);

            foreach (string file in files)
            {
                string fileName = Utils.GetFileNameFromPath(file);
                string fileExtension = Utils.GetExtension(fileName);

                if (settings.Extensions.ContainsKey(fileExtension))
                {
                    MoveFile(fileName, settings.Extensions[fileExtension]);
                }
            }
        }

        private static void MoveFile(string fileName, string dirName)
        {
            string pathFile = settings.Path + fileName;
            string finalPath = settings.Path + dirName;

            if (!Directory.Exists(finalPath))
            {
                Directory.CreateDirectory(finalPath);
            }

            string finalPathFile = finalPath + "\\" + fileName;
            if (File.Exists(finalPathFile))
            {
                File.Delete(finalPathFile);
            }

            File.Move(pathFile, finalPathFile);
        }
    }
}
