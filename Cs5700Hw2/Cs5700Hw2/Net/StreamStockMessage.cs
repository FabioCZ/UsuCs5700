using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw2.Model;

namespace Cs5700Hw2.Net
{
    public class StreamStockMessage
    {
        public List<string> Tickers { get; private set; }

        public int TickerCount => Tickers?.Count ?? 0;

        public StreamStockMessage(List<Company> companies)
        {
            Tickers = companies?.Select(e => e.TickerName).ToList();
        }

        public byte[] ToBytes()
        {
            var bytes = new List<byte>();
            var networkBytesCount = IPAddress.HostToNetworkOrder(Convert.ToInt16(TickerCount));
            bytes.AddRange(BitConverter.GetBytes(networkBytesCount));
            if (Tickers == null || Tickers.Count == 0)
            {
                return bytes.ToArray();
            }

            foreach (var t in Tickers)
            {
                bytes.AddRange(Encoding.ASCII.GetBytes(t.PadRight(6)));
            }
            return bytes.ToArray();
        }

        public byte[] EmptyMessage()
        {
            var bytes = new List<byte>();
            var networkBytesCount = IPAddress.HostToNetworkOrder(Convert.ToInt16(0));
            bytes.AddRange(BitConverter.GetBytes(networkBytesCount));
            return bytes.ToArray();
        }
    }
}
