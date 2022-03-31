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
            OpenConnection();
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

        internal void Write(string query, Dictionary<string, string> data)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);

            foreach (var entry in data)
            {
                cmd.Parameters.AddWithValue(entry.Key, entry.Value);
            }

            cmd.ExecuteNonQuery();
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

        internal Dictionary<string, string> Read(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            var data = new Dictionary<string, string>();
            while (reader.Read()) // Zeilenaufruf
            {
                for (var column = 0; column < reader.FieldCount; column++) //Spalten
                {
                    data[reader.GetName(column)] = reader.GetString(column);
                }
            }

            return data;
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

    }
}
