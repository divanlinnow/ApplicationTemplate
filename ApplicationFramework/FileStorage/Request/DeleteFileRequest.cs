namespace ApplicationFramework.FileStorage.Request
{
    public class DeleteFileRequest
    {
        public string Container { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }
    }
}
