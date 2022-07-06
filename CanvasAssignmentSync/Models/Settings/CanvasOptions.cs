using System.ComponentModel.DataAnnotations;

namespace CanvasAssignmentSync.Models
{
    public class CanvasOptions
    {
        public const string Canvas = "Canvas";

        [Url]
        public Uri? ApiUri { get; set; }

        public string? ApiKey { get; set; } = string.Empty;

    }
}
