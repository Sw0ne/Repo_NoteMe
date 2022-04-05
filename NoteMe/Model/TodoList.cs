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
        public TodoList(int idDiaryEntry)
        {
            IdDiaryEntry = idDiaryEntry;
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

        // ID_DIARYENTRY 
        private int _idDiaryEntry;
        public int IdDiaryEntry { get; set; }

        // CREATETASK COMMAND
        public ICommand CreateTaskCommand { get { return new CreateTaskCommand(); } }

        // METHODE 1: INSERT TODO LIST / SAVE

        // METHODE 2: DELETE TODO LIST

        // METHODE 3: UPDATE TODO LIST

        // METHODE 4: SELECT TODO LIST / LOAD

        // INOTIFYPROPERTYCHANGED-EVENT
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
