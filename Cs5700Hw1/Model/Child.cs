using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw1.Model
{
    [DataContract]
    internal class Child : Person
    {
        [DataMember]
        public string NewbornScreeningNumber { get; set; }
        [DataMember]
        public string IsPartOfMultipleBirth { get; set; }   //T/F
        [DataMember]
        public int? BirthOrder { get; set; }
        [DataMember]
        public string BirthCountry { get; set; }
        [DataMember]
        public string MotherFirstName { get; set; }
        [DataMember]
        public string MotherMiddleName { get; set; }
        [DataMember]
        public string MotherLastName { get; set; }
    }
}
