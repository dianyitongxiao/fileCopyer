using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopyer
{
    public class ConsoleOutputer : IOutput
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
