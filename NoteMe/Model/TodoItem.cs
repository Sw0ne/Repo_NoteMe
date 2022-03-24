using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMe.Model
{
    class TodoItem
    {
        // Fields
        private int _idTodoItem;
        private string _todoItemContent;
        private bool _doneOrNot;
        private int _idDiaryEntry;

        // Konstruktor
        public TodoItem()
        {

        }

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

        public string TodoItemContent
        {
            get
            {
                return _todoItemContent;
            }
            set
            {
                _todoItemContent = value;
            }
        }

        public bool DoneOrNot
        {
            get
            {
                return _doneOrNot;
            }
            set
            {
                _doneOrNot = value;
            }
        }

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
