using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NoteMe.Model
{
    class User
    {
        // Fields
        private int _idUser;
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        // Konstruktor
        public User()
        {

        }

        // Properties
        public int IdUser
        {
            get
            {
                return _idUser;
            }
            set
            {
                _idUser = value;
            }
        }

        internal void Save()
        {
            DatabaseConnection.Instance.Write($"INSERT INTO user (vorname,nachname) VALUES ({Vorname},{Nachname});");
            // Erste Version: DatabaseConnection.Instance.Write("INSERT INTO user (vorname,nachname) VALUES ($,$)", Vorname, Nachname);
        }

        internal void ShowDataVorname()
        {
            DatabaseConnection.Instance.Execute($"SELECT vorname FROM user;");
        }

        internal void ShowDataNachname()
        {
            DatabaseConnection.Instance.Execute($"SELECT nachname FROM user;");
        }
    }
}
