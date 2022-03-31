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
        private ObservableCollection<TodoItem> _Tasks = new ObservableCollection<TodoItem>();
        public ObservableCollection<TodoItem> Tasks
        {
            get
            {
                return _Tasks;
            }
            set
            {
                if (_Tasks != value)
                {
                    _Tasks = value;
                    NotifyPropertyChanged(nameof(Tasks));
                }
            }
        }
        public string TaskName { get; set; }
        public ICommand CreateTaskCommand { get { return new CreateTaskCommand(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        // Updated TodoListe
        private void NotifyPropertyChanged(String propertyName)
        {
            // Wenn PropertyChanged nicht null ist, wird invoke gecalled
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
