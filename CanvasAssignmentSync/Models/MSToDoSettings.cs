using System.ComponentModel.DataAnnotations;

namespace CanvasAssignmentSync.Models
{
    public class MSToDoSettings
    {
        [Required]
        public string? ClientId { get; set; }

        [Required]
        public string? ClientSecret { get; set; }

    }
}
