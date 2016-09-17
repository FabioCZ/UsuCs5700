using System.Runtime.Serialization;

namespace Cs5700Hw1.Model
{
    [DataContract]
    public abstract class Person
    {
        [DataMember]
        public int ObjectId { get; set; }

        [DataMember]
        public string StateFileNumber { get; set; }

        [DataMember]
        public string SocialSecurityNumber { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public int? BirthYear { get; set; }

        [DataMember]
        public int? BirthMonth { get; set; }

        [DataMember]
        public int? BirthDay { get; set; }

        [DataMember]
        public string Gender { get; set; } //M/F

        protected bool Equals(Person other)
        {
            return ObjectId == other.ObjectId;
        }

        public override bool Equals(object obj)
        {
            return Equals((Person) obj);
        }


        public override int GetHashCode()
        {
            return ObjectId;
        }
    }
}