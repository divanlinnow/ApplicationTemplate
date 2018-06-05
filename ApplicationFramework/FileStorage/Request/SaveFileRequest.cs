namespace ApplicationFramework.FileStorage.Request
{
    public class SaveFileRequest
    {
        public string Container { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public byte[] Data { get; set; }
    }
}
