using System.ComponentModel.DataAnnotations;

namespace CanvasAssignmentSync.Models
{
    public class Course
    {
        [Required]
        public string Name { get; set; }

        public bool ShouldSync { get; set; } = false;

        [Required]
        public int ID { get; set; }

        public override string ToString()
        {
            return string.Format($"Name: {Name} Id: {ID} Sync active: {ShouldSync}");
        }
    }
}
