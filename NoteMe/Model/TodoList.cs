using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteMe.Model
{
    class TodoList : INotifyPropertyChanged
    {
        // KONSTRUKTOR
        public TodoList()
        {

        }

        // TASKS
        private ObservableCollection<TodoItem> _tasks = new ObservableCollection<TodoItem>();
        public ObservableCollection<TodoItem> Tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                if (_tasks != value)
                {
                    _tasks = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tasks)));
                }
            }
        }

        // TASKNAME
        private string _taskName;
        public string TaskName { get; set; }

        // CREATETASK COMMAND
        public ICommand CreateTaskCommand { get { return new CreateTaskCommand(); } }

        // INOTIFYPROPERTYCHANGED-EVENT
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
