using System.Collections.Generic;

namespace Cs5700Hw1.Match
{
    internal interface IMatchResultWriter
    {
        void WriteResult(List<Match> matches);
    }
}