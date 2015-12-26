using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopyer
{
    public interface IOutput
    {
        void Write(string msg);
    }
}
