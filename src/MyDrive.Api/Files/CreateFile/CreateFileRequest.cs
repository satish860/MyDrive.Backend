namespace MyDrive.Api.Files.CreateFile
{
    public class CreateFileRequest
    {
        public string Name { get; set; }

        public long Size { get; set; }

        public string Type { get; set; }
    }
}
