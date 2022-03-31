using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql.Data.Types;

namespace NoteMe.Model
{
    // Klasse ist für Verbindungsaufbau zu Datenbank (Nach Erstellung) gedacht

    class DatabaseConnection
    {
        private MySqlConnection connection;

        private static DatabaseConnection _instance;

        // KONSTRUKTOR
        public  DatabaseConnection()
        {
            Initialize();
        }

        public static DatabaseConnection Instance
        {
            get
            {
                // Diese Version ist nicht Thread-Safe, aber das ist in dieser Applikation OK.
                if (_instance == null)
                {
                    _instance = new DatabaseConnection();
                }
                return _instance;
            }
        }

        internal void Write(string query, params object[] args)
        {
            throw new NotImplementedException();
        }

        // WERTE FÜR DB FESTLEGEN (INKL. BENUTZEREINGABE VON USERNAME UND PASSWORT)
        public void Initialize()
        {
            string connectionString = "SERVER=localhost;DATABASE=gruppeK;USERNAME=gruppeKadmin;PASSWORD=passwort;";

            connection = new MySqlConnection(connectionString);
        }

        // VERBINDUNG HERSTELLEN / ÖFFNEN
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                // Die zwei häufigsten Fehler beim Herstellen einer Connection zum Server
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact administrator!");
                        Console.WriteLine(ex.Message);
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again!");
                        break;
                }
                return false;
            }
        }

        // VERBINDUNG SCHLIESSEN
        public bool CloseConnection()

        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        internal void Execute(string query)
        {
            try
            {
                // Reader
                MySqlDataReader MyReader;

                // MySqlCommand-Objekt
                MySqlCommand command = new MySqlCommand(query, connection);

                // Ausführen des MySqlCommands
                MyReader = command.ExecuteReader();

            }
            catch (Exception ex)
            {
                // Fehler-Mitteilung
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        internal void ExecuteScalar(string query)
        {
            try
            {
                // MySqlCommand-Objekt
                MySqlCommand command = new MySqlCommand(query, connection);

                // Ausführen des MySqlCommands
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // Fehler-Mitteilung
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

    }
}
