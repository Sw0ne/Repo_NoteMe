using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMe.Model
{
    // WIRD DIESE KLASSE ÜBERHAUPT BENÖTIGT?????
    class TodoItem
    {
        // KONSTRUKTOR
        public TodoItem()
        {

        }

        // ID_TODOITEM
        private int _idTodoItem;
        public int IdTodoItem { get; set; }

        // TODOITEM NAME
        private string _todoItemName;
        public string TodoItemName { get; set; } // Früher vor Umbenennen: TodoItemContent (Muss noch in DB umbenannt werden)

        // DONE OR NOT
        private bool _doneOrNot;
        public bool DoneOrNot { get; set; }

        // ID_DIARYENTRY
        private int _idDiaryEntry;
        public int IdDiaryEntry { get; set; }

    }
}
