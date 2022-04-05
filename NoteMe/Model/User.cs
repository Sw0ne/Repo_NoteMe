using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoteMe.Model
{
    class User : INotifyPropertyChanged
    {
        // KONSTRUKTOR
        public User()
        {

        }

        // VORNAME
        private string _vorname;
        public string Vorname
        {
            get
            {
                return _vorname;
            }
            set
            {
                if (_vorname != value)
                {
                    _vorname = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vorname)));
                }
            }
        }

        // NACHNAME
        private string _nachname;
        public string Nachname
        {
            get
            {
                return _nachname;
            }
            set
            {
                if (_nachname != value)
                {
                    _nachname = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nachname)));
                }
            }
        }

        // ID_USER
        private int _idUser;
        public int IdUser { get; set; }


        // METHODE 1: SAVE USER
        internal void Save()
        {
            var data = new Dictionary<string, object>
            {
                // Key , Value
                {"@Vorname", Vorname },
                {"@Nachname", Nachname }
            };

            DatabaseConnection.Instance.Write("INSERT INTO users (vorname,nachname) VALUES (@Vorname,@Nachname)", data);
        }

        // METHODE 2: LOAD USER
        internal void Load()
        {
            var data = DatabaseConnection.Instance.Read("SELECT * FROM users;"); // zb diary entry select * from diary entry where diarydate

            if (data.Count == 0)
            {
                return;
            }

            Vorname = data["vorname"];
            Nachname = data["nachname"];

            var idString = data["idUser"];
            IdUser = int.Parse(idString);
        }

        // METHODE 3: GET ID_USER
        //internal void GetUserId()
        //{
        //    var data = DatabaseConnection.Instance.Read("SELECT idUser FROM users;");

        //    if (data.Count == 0)
        //    {
        //        return;
        //    }

        //var idString = data["idUser"];
        //IdUser = int.Parse(idString);
        //}

        // INOTIFYPROPERTYCHANGED-EVENT
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
