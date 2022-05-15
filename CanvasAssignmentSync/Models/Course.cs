using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanvasAssignmentSync.Models
{
    public class Course : IComparable<Course>
    {
        [Required]
        public string Name { get; set; }

        public bool ShouldSync { get; set; } = false;

        [Required]
        public int ID { get; set; }

        [JsonPropertyName("start_at")]
        public DateTime StartAt { get; set; }
        //

        public int CompareTo(Course other)
        {
            return other.StartAt.CompareTo(StartAt);
        }


        public override string ToString()
        {
            return string.Format($"Name: {Name} Id: {ID} Sync active: {ShouldSync}");
        }
    }
}
