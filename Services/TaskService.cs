using System.IO;
using System.Text.Json;
using TaskManager.Models;

namespace TaskManager.Services
{
    public sealed class TaskService : ITaskService
    {
        private const string FilePath = "tasks.json";

        public List<TaskModel> LoadTasks()
        {
            if (File.Exists(FilePath))
                return JsonSerializer.Deserialize<List<TaskModel>>(File.ReadAllText(FilePath));
            return [];
        }

        public void SaveTasks(List<TaskModel> tasks)
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(tasks));
        }
    }
}
