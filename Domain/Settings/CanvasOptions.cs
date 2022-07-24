
using Domain.Models.Canvas;

namespace Domain.Settings
{
    public class CanvasOptions
    {
        public const string Canvas = "Canvas";

        public int Id { get; set; }

        public string? OwnerId { get; set; }

        public Uri? ApiUri { get; set; }

        public string? ApiKey { get; set; } = string.Empty;

        public List<Course>? CourseSyncBlacklist { get; set; }

    }
}
