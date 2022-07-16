using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models.Canvas
{
    public class Course
    {
        public string? Name { get; init; }

        public string Id { get; init; }

        public string Uuid { get; init; }

        public DateTime StartAt { get; init; }

    }
}
