using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace NoteMe.Model
{
    // Klasse ist für Verbindungsaufbau zu Datenbank (Nach Erstellung) gedacht

    class DatabaseConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string username;
        private string password;

        // KONSTRUKTOR
        public DatabaseConnection()
        {
            Initialize();
        }

        // WERTE FÜR DB FESTLEGEN (INKL. BENUTZEREINGABE VON USERNAME UND PASSWORT)
        private void Initialize()
        {
            server = "localhost";
            database = "gruppeK";

            // Database hier mit eingefügt, weil sie zu diesem Zeitpunkt schon existiert (nach Init)
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";"; // evtl teil mit database weglassen

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
                // MySqlCommand-Objekt
                MySqlCommand command = new MySqlCommand(query, connection);

                // Ausführen des MySqlCommands
                command.ExecuteNonQuery();

                Console.WriteLine("Query erfolgreich!");

            }
            catch (Exception ex)
            {
                // Fehler-Mitteilung
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

    }
}
