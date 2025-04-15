using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskService
    {
        List<TaskModel> GetTasks();
        void AddTask(TaskModel task);
        void RemoveTask(TaskModel task);
        void SaveTasks();
    }
}
