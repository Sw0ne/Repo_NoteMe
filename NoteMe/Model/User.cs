﻿using System;
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
        // Konstruktor
        public User()
        {

        }

        // Fields & Properties

        // VORNAME
        private string _Vorname;
        public string Vorname
        {
            get
            {
                return _Vorname;
            }
            set
            {
                if (_Vorname != value)
                {
                    _Vorname = value;
                    OnPropertyChanged();
                }
            }
        }

        // ID_USER
        private int _idUser;
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

        // NACHNAME
        private string _Nachname;
        public string Nachname
        {
            get
            {
                return _Nachname;
            }
            set
            {
                if (_Nachname != value)
                {
                    _Nachname = value;
                    OnPropertyChanged();
                }
            }
        }

        // METHODEN
        internal void Save()
        {
            var data = new Dictionary<string, string>
            {
                {"@Vorname", Vorname },
                {"@Nachname", Nachname }
                // Key , Value
            };

            DatabaseConnection.Instance.Write("INSERT INTO users (vorname,nachname) VALUES (@Vorname,@Nachname)", data);
        }

        internal void Load()
        {
            var data = DatabaseConnection.Instance.Read("SELECT * FROM users;");

            if (data.Count == 0)
            {
                return;
            }

            Vorname = data["vorname"];
            Nachname = data["nachname"];
        }


        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
