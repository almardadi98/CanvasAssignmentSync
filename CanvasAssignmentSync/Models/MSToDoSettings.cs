using System.ComponentModel.DataAnnotations;

namespace CanvasAssignmentSync.Models
{
    public class MSToDoSettings
    {
        [Required]
        [Display(Name ="Client Id")]
        public string ClientId { get; set; }

        [Required]
        [Display(Name = "Client Secret")]
        public string ClientSecret { get; set; }

    }
}
