using System.Collections.Generic;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskService
    {
        List<TaskModel> GetTasks();
        void AddTask(TaskModel task);
    }
}
