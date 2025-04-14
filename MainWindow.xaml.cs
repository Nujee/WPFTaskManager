using System.Windows;
using TaskManager.Services;
using TaskManager.ViewModels;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TaskListViewModel(new TaskService());
        }
    }
}
