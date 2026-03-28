using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TaskManagementModels;

namespace TaskManagementDataService
{
    public class TaskJsonData
    {
            private List<Tasks> tasks = new List<Tasks>();
            private string _jsonFileName;

            public TaskJsonData()
            {
                _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/TaskManagementJson.json";

                EnsureJsonFileExists();
                LoadFromJson();
            }
            private void EnsureJsonFileExists()
            {
                if (!File.Exists(_jsonFileName))
                {
                    File.WriteAllText(_jsonFileName, "[]");
                }
            }
            private void LoadFromJson()
            {
                string content = File.ReadAllText(_jsonFileName);

                if (string.IsNullOrWhiteSpace(content)) content = "[]";

                tasks = JsonSerializer.Deserialize<List<Tasks>>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    ?? new List<Tasks>();
            }
            private void SaveToJson()
            {
                var json = JsonSerializer.Serialize(tasks,
                    new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(_jsonFileName, json);
            }
            public List<Tasks> GetAll()
            {
                LoadFromJson();
                return tasks;
            }

            public void SaveAll(List<Tasks> updatedTasks)
            {
                tasks = updatedTasks;
                SaveToJson();
            }
        }
    }
