using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteMe.Model
{
    // SCHNITTSTELLE: HINZUFÜGEN VON TASKS
    class CreateTaskCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        // METHODE 1: KANN IMMER AUSGEFÜHRT WERDEN
        public bool CanExecute(object parameter)
        {
            return true; 
        }

        // METHODE 2: HINZUFÜGEN VON TASKS
        public void Execute(object parameter)
        {
            if (parameter is TodoList todoList)
            {
                todoList.Tasks.Add(new TodoItem() { TodoItemName = todoList.TaskName, DoneOrNot = false });
            }
        }
    }
}
