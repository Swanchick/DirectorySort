using System;
using System.IO;



namespace DirectorySort
{
    class DirectorySort
    {
        private static string path = "D:\\Download\\";

        private static void Main(string[] args)
        {
            DirectoryChecker();
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
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string fileName = Utils.GetFileNameFromPath(file);
            }
        }
    }


}
