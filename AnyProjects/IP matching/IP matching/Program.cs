using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace IP_matching
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length <=0)
            {
                Console.WriteLine("The application is launched from a batch file");
                Console.ReadKey();
                Process.GetCurrentProcess().Kill();
            }

            string pathBannedList = $"{Directory.GetCurrentDirectory()}//Banned list.txt";
            ExistFile(pathBannedList);

            if (!VerifyArgs(args[0]))
            {
                Console.WriteLine("Incorrect ip input");
            }
            else
            {
                Matching(pathBannedList, args[0]);
            }
        }

            public static void ExistFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("No file with banned addresses found");
            }
        }

        public static bool VerifyArgs(string args)
        {
            string regex = @"^((25[0-5]|2[0-4][0-9]|[1]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[1]?[0-9][0-9]?)$";
            return Regex.IsMatch(args, regex);
        }

        public static void Matching(string path, string args)
        {
            bool access = true;

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == args)
                    {
                        Console.WriteLine("Access disallowed");
                        access = !access;
                    }
                }
            }
            if(access) Console.WriteLine("Access allowed");
        }
    }
}
