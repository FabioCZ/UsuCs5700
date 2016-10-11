using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using static System.Net.IPAddress;

namespace Cs5700Hw2.Net
{
    public class TickerMessage
    {
        public string TickerName { get; private set; }
        public DateTime? Timestamp { get; private set; }
        public int OpeningPrice { get; private set; }
        public int PrevClosingPrice { get; private set; }
        public int CurrPrice { get; private set; }
        public int BidPrice { get; private set; }
        public int AskPrice { get; private set; }
        public int CurrVolume { get; private set; }
        public int AvgTenDayVolume { get; private set; }

        public TickerMessage(byte[] bytes)
        {
            Decode(bytes);
        }

        private void Decode(byte[] bytes)
        {
            if (bytes == null || bytes.Length != 42) return;

            var reader = new BinaryReader(new MemoryStream(bytes));
            TickerName = Encoding.ASCII.GetString(reader.ReadBytes(6)).Trim();
            Timestamp = new DateTime(NetworkToHostOrder(reader.ReadInt64()));
            OpeningPrice = NetworkToHostOrder(reader.ReadInt32());
            PrevClosingPrice = NetworkToHostOrder(reader.ReadInt32());
            CurrPrice = NetworkToHostOrder(reader.ReadInt32());
            BidPrice = NetworkToHostOrder(reader.ReadInt32());
            AskPrice = NetworkToHostOrder(reader.ReadInt32());
            CurrVolume = NetworkToHostOrder(reader.ReadInt32());
            AvgTenDayVolume = NetworkToHostOrder(reader.ReadInt32());
        }

        public static TickerMessage Empty
        {
            get
            {
                var msg = new TickerMessage(null)
                {
                    TickerName = "N/A",
                    Timestamp = DateTime.FromFileTime(0),
                    OpeningPrice = 0,
                    PrevClosingPrice = 0,
                    CurrPrice = 0,
                    BidPrice = 0,
                    AskPrice = 0,
                    CurrVolume = 0,
                    AvgTenDayVolume = 0
                };
                return msg;
            }
        }
    }
}
