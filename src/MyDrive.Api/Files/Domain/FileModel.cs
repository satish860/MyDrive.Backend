using MongoDB.Bson;

namespace MyDrive.Api.Files.Domain
{
    public class FileModel
    {
        public ObjectId Id { get; set; }

        public string? Name { get; set; }

        public long Size { get; set; }

        public string? Type { get; set; }
    }
}
