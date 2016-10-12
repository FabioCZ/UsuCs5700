using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw2.Model
{
    public class TimestampedMetric<T>
    {
        public DateTime Timestamp { get; private set; }
        public T Metric { get; private set; }

        public TimestampedMetric(DateTime timestamp, T metric)
        {
            Timestamp = timestamp;
            Metric = metric;
        }
    }
}
