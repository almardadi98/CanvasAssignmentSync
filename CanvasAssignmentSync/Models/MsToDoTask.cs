using System.Dynamic;

namespace CanvasAssignmentSync.Models
{
    public class MsToDoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool ReminderIsOn { get; set; }
        public bool IsImportant { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueAt { get; set; }

    }

    public enum ContentType
    {
        Text,
        Html
    }


    public class Body
    {
        public string Content { get; set; }

        public ContentType ContentType { get; set; }
    }
}
