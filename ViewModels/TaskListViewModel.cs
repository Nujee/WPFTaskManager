using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using TaskManager.Helpers;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    public sealed class TaskListViewModel : ViewModelBase, IDisposable
    {
        private readonly ITaskService _taskService;
        private string _newTaskTitle;

        public ObservableCollection<TaskModel> Tasks { get; } = [];
        public string NewTaskTitle
        {
            get => _newTaskTitle;
            set
            {
                _newTaskTitle = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddTaskCommand { get; }
        public ICommand RemoveTaskCommand { get; }

        public TaskListViewModel(ITaskService taskService)
        {
            Debug.WriteLine("TaskListVewModel is created");
            _taskService = taskService;
            _taskService.LoadTasks();

            Tasks = [.. _taskService.GetTasks()];

            AddTaskCommand = new RelayCommand(AddTask);
            RemoveTaskCommand = new RelayCommand<TaskModel>(RemoveTask);

            _taskService.TasksChanged += OnTasksChanged;
        }

        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTitle))
            {
                var task = new TaskModel { Title = NewTaskTitle };
                _taskService.AddTask(task);
                NewTaskTitle = string.Empty;
            }
        }

        private void RemoveTask(TaskModel task) => _taskService.RemoveTask(task);

        private void OnTasksChanged(object sender, EventArgs e)
        {
            Tasks.Clear();
            foreach (var task in _taskService.GetTasks())
            {
                Tasks.Add(task);
            }
        }

        public void Dispose() =>_taskService.TasksChanged -= OnTasksChanged;
    }
}
