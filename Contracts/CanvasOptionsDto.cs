
namespace Contracts
{
    public class CanvasOptionsDto
    {
        public const string Canvas = "Canvas";

        public int Id { get; set; }

        public string? OwnerId { get; set; }

        public Uri? ApiUri { get; set; }

        public string? ApiKey { get; set; } = string.Empty;

        public List<CourseDto>? CourseSyncBlacklist { get; set; }

    }
}
