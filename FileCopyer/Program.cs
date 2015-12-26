using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FileCopyer
{
    class Program
    {

        static void Main(string[] args)
        {
            string sourcePath = ConfigurationManager.AppSettings["sourcePath"];
            string destPath = ConfigurationManager.AppSettings["destPath"];

            try
            {
                FileCopyer copyer = new FileCopyer();
                copyer.SourcePath = sourcePath;
                copyer.DestPath = destPath;
                copyer.OutPuter = new ConsoleOutputer();
                copyer.AddIgnoreFile("Web.config");
                copyer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("---ok----");
            Console.ReadKey();
        }
    }
}
