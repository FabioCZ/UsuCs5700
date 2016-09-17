namespace Cs5700Hw1.Serialization
{
    public class FileInfo
    {
        public FileInfo(string fileName, FileType fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }

        public string FileName { get; private set; }
        public FileType FileType { get; private set; }
    }
}