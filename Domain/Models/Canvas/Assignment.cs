using System.Text.Json.Serialization;

namespace Domain.Models.Canvas
{
    public class Assignment
    {
        public string Id { get; init; }

        public string Uuid { get; init; }

        public string CourseId { get; init; }

        public string? Name { get; init; }


        public DateTime? DueAt { get; set; }

        public DateTime CreatedAt { get; init; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? UnlockAt { get; set; }

        public DateTime? LockAt { get; set; }

        public string? Description { get; set; }

        public Uri? HTMLURL { get; init; }

    }
}
