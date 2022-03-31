using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteMe.Model
{
    class CreateTaskCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; // Kann immer ausgeführt werden
        }

        public void Execute(object parameter)
        {
            if (parameter is TodoList todoList)
            {
                todoList.Tasks.Add(new TodoItem() { TodoItemName = todoList.TaskName, DoneOrNot = false });
            }
        }
    }
}
