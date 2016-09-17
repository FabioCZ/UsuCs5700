using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Cs5700Hw1.Model;

namespace Cs5700Hw1.Serialization
{
    public class JsonDeSerializer : DeSerializer
    {
        public JsonDeSerializer(FileInfo fileInfo) : base(fileInfo)
        {
        }

        public override List<Person> DeSerialize()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Person>),
                new[] {typeof(Person), typeof(Adult), typeof(Child)});
            using (var reader = new StreamReader(FileInfo.FileName))
            {
                try
                {
                    return serializer.ReadObject(reader.BaseStream) as List<Person>;
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error reading in file {FileInfo.FileName}");
                    throw e;
                }
            }
        }
    }
}