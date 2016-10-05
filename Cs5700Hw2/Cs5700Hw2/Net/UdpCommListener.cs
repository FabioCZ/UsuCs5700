﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System.Threading;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Cs5700Hw2.Model;

namespace Cs5700Hw2.Net
{
    public class UdpCommListener : ICommListener
    {
        private readonly int TimeOutMS = 1000;
        private readonly IPEndPoint LocalEP = new IPEndPoint(IPAddress.Any, 0);

        private UdpClient udpClient;

#if AWSDEBUG
        private IPEndPoint simulatorEndpoint = new IPEndPoint(IPAddress.Parse("TODO"),12099);
#else
        private IPEndPoint simulatorEndpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12099);

#endif
        public bool IsRunning { get; private set; }
        public Portfolio Portfolio { get; set; }

        public async void Init()
        {
            udpClient = new UdpClient(LocalEP);
            var startMessage = new StreamStockMessage(Portfolio.WatchedCompanies.Cast<Company>().ToList());
            var startMessageBytes = startMessage.ToBytes();
            try
            {
                await udpClient.SendAsync(startMessageBytes, startMessageBytes.Length, simulatorEndpoint);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                await new MessageDialog("There was a problem communicating with the Simulator").ShowAsync();
                return;
            }
            IsRunning = true;
            ThreadPool.RunAsync(Run);
        }

        public void Destroy()
        {
            IsRunning = false;
            udpClient?.Dispose();
        }

        public event CommEventArgs OnDataReceived;

        private async void Run(IAsyncAction operation)
        {
            if (Portfolio == null) return;

            while (IsRunning)
            {
                try
                {
                    TickerMessage message;
                    var receivedBytes = await ReceiveBytes(TimeOutMS);
                    message = new TickerMessage(receivedBytes.Buffer);
                    OnDataReceived?.Invoke(this, message);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw e;
                }
            }
        }

        private async Task<UdpReceiveResult> ReceiveBytes(int timeout)
        {
            udpClient.Client.ReceiveTimeout = timeout;
            try
            {
                return await udpClient.ReceiveAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                await new MessageDialog("There was a problem communicating with the Simulator").ShowAsync();
                return new UdpReceiveResult(); //can't return null looks like
            }
        }

    }
}