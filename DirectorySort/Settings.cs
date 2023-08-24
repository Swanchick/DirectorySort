using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;

namespace DirectorySort
{
    public struct SettingSerialize
    {
        public string Path { get; set; }
        public Dictionary<string, string> Extensions { get; set; }

        public bool firstRun;
    }


    internal class Settings
    {
        public static SettingSerialize LoadSettings()
        {
            string path = Directory.GetCurrentDirectory() + "\\Settings.json";

            if (!File.Exists(path))
            {
                SettingSerialize settings = new SettingSerialize
                {
                    Path = "D:\\Download\\",
                    Extensions = new Dictionary<string, string>
                    {
                        ["txt"] = "Text"
                    }
                };

                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(settings, options);

                File.WriteAllText(path, jsonString);
                
                settings.firstRun = true;

                return settings;
            }

            string settingsJson = File.ReadAllText(path);

            return JsonSerializer.Deserialize<SettingSerialize>(settingsJson);
        }
    }
}
