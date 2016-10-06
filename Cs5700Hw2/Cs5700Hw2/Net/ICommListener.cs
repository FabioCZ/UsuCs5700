using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw2.Model;

namespace Cs5700Hw2.Net
{
    public delegate void CommEventArgs(object sender, TickerMessage message);

    public interface ICommListener
    {
        Portfolio Portfolio { get; set; }
        bool IsRunning { get; }
        void Init();
        void Destroy();
        event CommEventArgs OnDataReceived;
    }
}