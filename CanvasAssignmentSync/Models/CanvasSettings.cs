using System.ComponentModel.DataAnnotations;

namespace CanvasAssignmentSync.Models
{
    public class CanvasSettings
    {
        [Required]
        [Url]
        [Display(Name = "API URI")]
        public string APIURI { get; set; }

        [Required]
        [Display(Name = "API Key")]
        public string APIKey { get; set; }

    }
}
