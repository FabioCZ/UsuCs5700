using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw1.Matcher
{
    interface IMatchResultWriter
    {
        void WriteResult(List<Match> matches);
    }
}
