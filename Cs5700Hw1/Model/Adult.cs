using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw1.Model
{
    [DataContract]
    internal class Adult : Person
    {
        [DataMember]
        public string Phone1 { get; set; }
        [DataMember]
        public string Phone2 { get; set; }
    }
}
