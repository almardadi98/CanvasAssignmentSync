using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanvasAssignmentSync.Models
{
    public class Course
    {
        [Required]
        public string Name { get; init; } = null!;

        public bool ShouldSync { get; set; } = false;

        [Required]
        public int Id { get; init; }

        [JsonPropertyName("start_at")]
        public DateTime StartAt { get; init; }



        public override string ToString()
        {
            return string.Format($"Name: {Name} Id: {Id} Sync active: {ShouldSync}");
        }
    }
}
