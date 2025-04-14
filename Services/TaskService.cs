using TaskManager.Models;

namespace TaskManager.Services
{
    public sealed class TaskService : ITaskService
    {
        private readonly List<TaskModel> _tasks = [];

        public List<TaskModel> GetTasks() => _tasks;

        public void AddTask(TaskModel task) => _tasks.Add(task);
    }
}
