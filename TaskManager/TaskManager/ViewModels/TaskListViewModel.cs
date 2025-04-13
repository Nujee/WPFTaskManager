using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManager.Helpers;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    public sealed class TaskListViewModel : ViewModelBase
    {
        private readonly ITaskService _taskService;

        public ObservableCollection<TaskModel> Tasks { get; }

        public string NewTaskTitle { get; set; }

        public ICommand AddTaskCommand { get; }

        public ICommand RemoveTaskCommand { get; }

        public TaskListViewModel(ITaskService taskService)
        {
            _taskService = taskService;
            Tasks = new ObservableCollection<TaskModel>(taskService.GetTasks());

            AddTaskCommand = new RelayCommand(AddTask);
            RemoveTaskCommand = new RelayCommand<TaskModel>(RemoveTask);
        }

        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTitle))
            {
                var task = new TaskModel { Title = NewTaskTitle };
                Tasks.Add(task);
                NewTaskTitle = string.Empty;
                OnPropertyChanged(nameof(NewTaskTitle));
            }
        }

        private void RemoveTask(TaskModel task)
        {
            if (Tasks.Contains(task))
                Tasks.Remove(task);
        }
    }
}
