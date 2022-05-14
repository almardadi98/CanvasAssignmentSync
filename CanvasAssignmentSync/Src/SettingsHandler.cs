using CanvasAssignmentSync.Models;
using System;
using System.IO;
using System.Text.Json;

namespace CanvasAssignmentSync.Src
{
    public class SettingsHandler<T>
    {
        T Model { get; set; }
        string Path { get; init; }
        public SettingsHandler(T model, string path)
        {
            Model = model;
            Path = path;
        }

        public T? GetSettings()
        {
            string jsonString = File.ReadAllText(Path);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public void WriteSettingsToFile()
        {

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Model, options);
            File.WriteAllText(Path, jsonString);
        }
    }
}
