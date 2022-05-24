using System.ComponentModel.DataAnnotations;

namespace CanvasAssignmentSync.Models
{
    public class MsToDoSettings
    {
        [Required]
        public string? ClientId { get; set; }

        [Required]
        public string? ClientSecret { get; set; }

    }
}
