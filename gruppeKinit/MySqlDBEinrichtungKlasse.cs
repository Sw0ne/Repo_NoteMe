using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace gruppeKinit
{
    class MySqlDBEinrichtungKlasse
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string username;
        private string password;

        // KONSTRUKTOR
        public MySqlDBEinrichtungKlasse()
        {
            Initialize();
        }

        // WERTE FÜR DB FESTLEGEN (INKL. BENUTZEREINGABE VON USERNAME UND PASSWORT)
        private void Initialize()
        {
            server = "localhost";
            database = "gruppeK";

            Console.WriteLine("Admin: ");
            username = Console.ReadLine();

            Console.WriteLine("PW: ");
            password = Console.ReadLine(); //statt console readline sternchen - keine ausgabe von dem was eingetippt wurde - https://stackoverflow.com/questions/3404421/password-masking-console-application

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";"; // evtl teil mit database weglassen

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
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        Console.WriteLine(ex.Message);
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
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

                Console.WriteLine("Jap, hat funktioniert");

            }
            catch (Exception ex)
            {
                // Fehler-Mitteilung
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
