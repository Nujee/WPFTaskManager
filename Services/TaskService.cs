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
            try
            {
                if (!File.Exists(FilePath))
                    return [];

                string jsonText = File.ReadAllText(FilePath);
                var tasks = JsonSerializer.Deserialize<List<TaskModel>>(jsonText);

                return tasks ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке задач: {ex.Message}");
                return [];
            }
        }

        public void AddTask(TaskModel task) => _tasks.Add(task);

        public void RemoveTask(TaskModel task) => _tasks.Remove(task);

        public void SaveTasks()
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(_tasks));
        }
    }
}
