using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Security;

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

            //EINGABE ADMIN NAME
            Console.WriteLine("Admin: ");
            username = Console.ReadLine();

            // EINGABE ADMIN PASSWORT
            Console.WriteLine("PW: ");
            password = string.Empty;
            ConsoleKeyInfo key;

            do // Logik für verdecktes Passwort
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
            }
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();

            // VERBINDUNGSAUFBAU
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

                Console.WriteLine("Datenbank wurde erstellt!");

            }
            catch (Exception ex)
            {
                // Fehler-Mitteilung
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        // Passwort verdecken
        public SecureString GetPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
    }
}
