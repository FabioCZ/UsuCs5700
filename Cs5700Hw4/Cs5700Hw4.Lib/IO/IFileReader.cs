using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw4.Lib.Model;

namespace Cs5700Hw4.Lib.IO
{
    public interface IFileReader
    {
        Puzzle Read(string fileName);
    }
}
