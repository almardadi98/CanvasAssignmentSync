using CanvasAssignmentSync.Models;
using System;
using System.IO;
using System.Text.Json;

namespace CanvasAssignmentSync.Src
{
    public class SettingsHandler<T>
    {
        T Model { get; set; }
        public SettingsHandler(T model)
        {
            Model = model;
        }
        public void WriteSettingsToFile()
        {

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Model, options);
            File.WriteAllText($"./Conf/canvas_settings.json", jsonString);
        }
    }
}
