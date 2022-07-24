using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models.Canvas
{
    public class Course
    {
        public string? Name { get; init; }

        public int Id { get; init; }

        public string Uuid { get; init; }

        [JsonPropertyName("start_at")]
        public DateTime StartAt { get; init; }

    }
}
