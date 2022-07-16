namespace Domain.Models.MsToDo
{
    public class MsToDoTaskList
    {
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public string WellKnownName { get; set; }

        public bool IsOwner { get; set; }

        public bool IsShared { get; set; }

        public Uri Link => new Uri($"https://to-do.live.com/tasks/{Id}");

    }
}
