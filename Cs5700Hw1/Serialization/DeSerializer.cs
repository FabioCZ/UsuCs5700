using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Cs5700Hw1.Model;

namespace Cs5700Hw1.Serialization
{
    internal abstract class DeSerializer
    {
        protected FileInfo FileInfo;

        protected DeSerializer(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }
        public abstract List<Person> DeSerialize();

        public static DeSerializer CreateFrom(FileInfo fileInfo)
        {
            if (!File.Exists(fileInfo.FileName))
            {
                throw new FileNotFoundException($"File: {fileInfo.FileName} not found");
            }

            switch (fileInfo.FileType)
            {
                case FileType.Json:
                    return new JsonDeSerializer(fileInfo);
                case FileType.Xml:
                    return new XmlDeSerializer(fileInfo);
                default:
                    throw new InvalidEnumArgumentException($"Unexpected enum value {fileInfo.FileType}, valid values are: Json, Xml");
            }
        }
    }
}
