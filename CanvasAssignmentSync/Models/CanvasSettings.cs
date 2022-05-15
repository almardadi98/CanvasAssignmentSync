using System.ComponentModel.DataAnnotations;

namespace CanvasAssignmentSync.Models
{
    public class CanvasSettings
    {
        [Required]
        [Url]
        public string? APIURI { get; set; }

        [Required]
        public string? APIKey { get; set; }

    }
}
