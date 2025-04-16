using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> GetTasks();
        void AddTask(TaskModel task);
        void RemoveTask(TaskModel task);
        void LoadTasks();
        void SaveTasks();
        event EventHandler TasksChanged;
    }
}
