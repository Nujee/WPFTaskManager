using System.IO;
using System.Text.Json;
using TaskManager.Models;

namespace TaskManager.Services
{
    public sealed class TaskService : ITaskService
    {
        private const string FilePath = "tasks.json";

        private readonly List<TaskModel> _tasks = [];

        public List<TaskModel> GetTasks()
        {
            if (File.Exists(FilePath))
                return JsonSerializer.Deserialize<List<TaskModel>>(File.ReadAllText(FilePath));
            return [];
        }

        public void AddTask(TaskModel task) => _tasks.Add(task);

        public void RemoveTask(TaskModel task) => _tasks.Remove(task);

        public void SaveTasks(IEnumerable<TaskModel> tasks)
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(tasks));
        }
    }
}
