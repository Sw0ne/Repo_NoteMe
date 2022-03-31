using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMe.Model
{
    class TodoItem
    {
        // Konstruktor
        public TodoItem()
        {

        }

        // Fields
        private int _idTodoItem;
        private int _idDiaryEntry;

        //private string _todoItemName;
        //private bool _doneOrNot;

        // Properties
        public int IdTodoItem
        {
            get
            {
                return _idTodoItem;
            }
            set
            {
                _idTodoItem = value;
            }
        }

        public string TodoItemName { get; set; } // Früher vor Umbenennen: TodoItemContent (Muss noch in DB umbenannt werden)
        //{
        //    get
        //    {
        //        return _todoItemName;
        //    }
        //    set
        //    {
        //        _todoItemName = value;
        //    }
        //}

        public bool DoneOrNot { get; set; }
        //{
        //    get
        //    {
        //        return _doneOrNot;
        //    }
        //    set
        //    {
        //        _doneOrNot = value;
        //    }
        //}

        public int IdDiaryEntry
        {
            get
            {
                return _idDiaryEntry;
            }
            set
            {
                _idDiaryEntry = value;
            }
        }
    }
}
