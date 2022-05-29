using System.Text.Json.Serialization;

namespace CanvasAssignmentSync.Models
{
    public class Assignment
    {
        public int Id { get; init; }
        public string? Name { get; init; }

        [JsonPropertyName("course_id")]
        public int CourseId { get; init; }

        [JsonPropertyName("due_at")]
        public DateTime? DueAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; init; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("unlock_at")]
        public DateTime? UnlockAt { get; set; }

        [JsonPropertyName("lock_at")]
        public DateTime? LockAt { get; set; }

        public string? Description { get; set; }

        [JsonPropertyName("html_url")]
        public Uri? HTMLURL { get; init; }

        //public int CompareTo(Assignment other)
        //{
        //    return other.CreatedAt.CompareTo(CreatedAt);
        //}
    }
}
