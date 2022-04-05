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
    // KLASSE FÜR VERBINDUNGSAUFBAU ZUR DATENBANK (NACH ERSTELLUNG DURCH "gruppeKinit")
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

        // INSTANZIIERUNG DER DATABASECONNECTION
        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseConnection();
                }
                return _instance;
            }
        }

        // METHODE 1: INITIIERUNG --> WERTE FÜR DB FESTLEGEN (INKL. BENUTZEREINGABE VON USERNAME UND PASSWORT)
        public void Initialize()
        {
            string connectionString = "SERVER=localhost;DATABASE=gruppeK;USERNAME=gruppeKadmin;PASSWORD=passwort;";

            connection = new MySqlConnection(connectionString);
        }

        // METHODE 2: VERBINDUNG HERSTELLEN
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

        // METHODE 3: VERBINDUNG SCHLIESSEN
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

        // METHODE 4: DATENSÄTZE AUS DATENBANK AUSLESEN
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

            reader.Close();
            return data;
        }


        internal Dictionary<string, string> Read(string query, Dictionary<string, object> data)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);

            foreach (var entry in data)
            {
                cmd.Parameters.AddWithValue(entry.Key, entry.Value);
            }

            MySqlDataReader reader = cmd.ExecuteReader();

            var result = new Dictionary<string, string>();
            while (reader.Read()) // Zeilenaufruf
            {
                for (var column = 0; column < reader.FieldCount; column++) //Spalten
                {
                    result[reader.GetName(column)] = reader.GetString(column);
                }
            }

            reader.Close();
            return result;
        }

        // METHODE 5: IN DATENBANK SCHREIBEN
        internal void Write(string query, Dictionary<string, object> data)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);

            foreach (var entry in data)
            {
                cmd.Parameters.AddWithValue(entry.Key, entry.Value);
            }

            cmd.ExecuteNonQuery();
        }

        // METHODE 6: AUS DATENBANK LÖSCHEN


        // METHODE 7: SQL-BEFEHL AUSFÜHREN
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
