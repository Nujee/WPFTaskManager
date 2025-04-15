using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskService
    {
        List<TaskModel> LoadTasks();
        void SaveTasks(List<TaskModel> tasks);
    }
}
