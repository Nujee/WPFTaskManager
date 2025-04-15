using System.Windows.Input;
using TaskManager.Helpers;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    public sealed class TaskListViewModel : ViewModelBase
    {
        private readonly ITaskService _taskService;

        public string NewTaskTitle { get; set; }

        public ICommand AddTaskCommand { get; }

        public ICommand RemoveTaskCommand { get; }

        public TaskListViewModel(ITaskService taskService)
        {
            _taskService = taskService;

            AddTaskCommand = new RelayCommand(AddTask);
            RemoveTaskCommand = new RelayCommand<TaskModel>(RemoveTask);
        }

        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTitle))
            {
                var task = new TaskModel { Title = NewTaskTitle };
                _taskService.AddTask(task);
                NewTaskTitle = string.Empty;
                OnPropertyChanged(nameof(NewTaskTitle));

                _taskService.SaveTasks();
            }
        }

        private void RemoveTask(TaskModel task)
        {
            _taskService.RemoveTask(task);
            _taskService.SaveTasks();
        }
    }
}
