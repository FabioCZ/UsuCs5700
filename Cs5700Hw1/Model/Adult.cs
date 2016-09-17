using System.Runtime.Serialization;

namespace Cs5700Hw1.Model
{
    [DataContract]
    public class Adult : Person
    {
        [DataMember]
        public string Phone1 { get; set; }

        [DataMember]
        public string Phone2 { get; set; }
    }
}