using System.Collections.ObjectModel;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    public sealed class TaskListViewModel
    {
        public ObservableCollection<TaskModel> Tasks { get; }

        public TaskListViewModel(ITaskService taskService)
        {
            Tasks = new ObservableCollection<TaskModel>(taskService.GetTasks());
        }
    }
}
