using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Cs5700Hw1.Model;

namespace Cs5700Hw1.Serialization
{
    internal class XmlDeSerializer : DeSerializer
    {
        public XmlDeSerializer(FileInfo fileInfo) : base(fileInfo)
        {
        }

        public override List<Person> DeSerialize()
        {
            var serializer = new DataContractSerializer(typeof(List<Person>), new[] { typeof(Person), typeof(Adult), typeof(Child) });
            using (var reader = new StreamReader(FileInfo.FileName))
            {
                return serializer.ReadObject(reader.BaseStream) as List<Person>;
            }
        }
    }
}
