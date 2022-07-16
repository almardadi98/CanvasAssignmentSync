namespace Persistence.Settings
{
    public class MsToDoOptions
    {
        public const string MsToDo = "MsToDo";

        public string? TenantId { get; set; } = string.Empty;

        public string? ClientId { get; set; } = string.Empty;

        public string? ClientSecret { get; set; } = string.Empty;

        public List<string>? Scopes { get; set; }

    }
}
