using System.ComponentModel;
using System.IO;
using System.Text.Json;
using TaskManager.Models;

namespace TaskManager.Services
{
    public sealed class TaskService : ITaskService
    {
        private const string FilePath = "tasks.json";

        private List<TaskModel> _tasks = [];
        public event EventHandler TasksChanged;

        public void LoadTasks()
        {
            try
            {
                var json = File.ReadAllText(FilePath);
                _tasks = JsonSerializer.Deserialize<List<TaskModel>>(json) ?? [];
                foreach (var task in _tasks)
                {
                    task.PropertyChanged += OnTaskPropertyChanged;
                }

                NotifyTasksChanged();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load tasks", ex);
            }
        }

        public void SaveTasks()
        {
            try
            {
                File.WriteAllText(FilePath, JsonSerializer.Serialize(_tasks));
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save tasks", ex);
            }
        }

        public IEnumerable<TaskModel> GetTasks() => [.. _tasks];

        public void AddTask(TaskModel task)
        {
            _tasks.Add(task);
            task.PropertyChanged += OnTaskPropertyChanged;

            NotifyTasksChanged();
            SaveTasks();
        }

        public void RemoveTask(TaskModel task)
        {
            task.PropertyChanged -= OnTaskPropertyChanged;
            _tasks.Remove(task);

            NotifyTasksChanged();
            SaveTasks();
        }

        private void OnTaskPropertyChanged(object sender, PropertyChangedEventArgs e) => SaveTasks();

        private void NotifyTasksChanged() => TasksChanged?.Invoke(this, EventArgs.Empty);
    }
}
