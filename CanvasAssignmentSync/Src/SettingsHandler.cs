using System.Text.Json;

namespace CanvasAssignmentSync.Src
{
    public class SettingsHandler<T>
    {
        public T Model { get; set; }
        string Path { get; init; }
        public SettingsHandler(T model, string path)
        {
            Model = model;
            Path = path;
        }

        public void GetSettings()
        {
            string jsonString = File.ReadAllText(Path);
            Model = JsonSerializer.Deserialize<T>(jsonString);
        }

        public void WriteSettingsToFile()
        {

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Model, options);
            File.WriteAllText(Path, jsonString);
        }
    }
}
