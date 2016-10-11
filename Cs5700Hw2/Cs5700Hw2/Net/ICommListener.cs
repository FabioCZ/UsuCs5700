using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Cs5700Hw2.Model;

namespace Cs5700Hw2.Net
{
    public delegate void CommEventArgs(object sender, WatchedCompany message);

    public interface ICommListener
    {
        Portfolio Portfolio { get; set; }
        bool IsRunning { get; }
        void Init(CoreDispatcher dispatcher);
        void Destroy();
        event CommEventArgs OnDataReceived;
    }
}