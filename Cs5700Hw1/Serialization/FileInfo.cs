using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw1.Serialization
{
    class FileInfo
    {
        public string FileName { get; private set; }
        public FileType FileType { get; private set; }

        public FileInfo(string fileName, FileType fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }
    }
}
