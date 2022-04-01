using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace gruppeKinit
{
    class gruppeKinit
    {
        static void Main(string[] args)
        {
            // Meine selbst erstellte SQL-Logik
            string dbErstellungMeineVersion =
            @"

            DROP DATABASE IF EXISTS `gruppeK`;
            CREATE DATABASE `gruppeK` DEFAULT CHARACTER SET utf8;

            USE `gruppeK`;

            CREATE TABLE IF NOT EXISTS `Users` 
            (
                `idUser`            INT             NOT NULL AUTO_INCREMENT,
                `vorname`           VARCHAR(45)     NOT NULL,
                `nachname`          VARCHAR(45)     NOT NULL,
                PRIMARY KEY (`idUser`)
            )
            ENGINE = InnoDB;


            CREATE TABLE IF NOT EXISTS `DiaryEntries` 
            (
                `idDiaryEntry`      INT             NOT NULL AUTO_INCREMENT,
                `idUser`            INT             NOT NULL,
                `diaryDate`         DATE            NOT NULL,
                PRIMARY KEY (`idDiaryEntry`),
                FOREIGN KEY (`idUser`) REFERENCES `Users` (`idUser`)
            )
            ENGINE = InnoDB;


            CREATE TABLE IF NOT EXISTS `DailyNotes` 
            (
                `idDailyNote`       INT             NOT NULL AUTO_INCREMENT,
                `noteContent`       VARCHAR(255)    NOT NULL,
                `idDiaryEntry`      INT             NOT NULL,
                PRIMARY KEY (`idDailyNote`),
                FOREIGN KEY (`idDiaryEntry`) REFERENCES diaryEntries (`idDiaryEntry`)
            )
            ENGINE = InnoDB;


            CREATE TABLE IF NOT EXISTS `Moods` 
            (
                `idMood`            INT             NOT NULL AUTO_INCREMENT,
                `moodType`          TINYINT(10)     NOT NULL,
                `idDiaryEntry`      INT             NOT NULL,
                PRIMARY KEY (`idMood`),
                FOREIGN KEY (`idDiaryEntry`) REFERENCES `DiaryEntries` (`idDiaryEntry`)
            )
            ENGINE = InnoDB;


            CREATE TABLE IF NOT EXISTS `TodoItems` 
            (
                `idTodoItem`        INT             NOT NULL AUTO_INCREMENT,
                `todoItemContent`   VARCHAR(100)    NOT NULL,
                `doneOrNot`         BIT(2)          NOT NULL,
                `idDiaryEntry`      INT             NOT NULL,
                PRIMARY KEY (`idTodoItem`),
                FOREIGN KEY (`idDiaryEntry`) REFERENCES `DiaryEntries` (`idDiaryEntry`)
            )
            ENGINE = InnoDB;


            DROP USER IF EXISTS gruppeKadmin;
            CREATE USER 'gruppeKadmin' IDENTIFIED BY 'passwort';

            GRANT ALL ON `gruppeK`.* TO 'gruppeKadmin';"
            ;

            MySqlDBEinrichtungKlasse einrichtung = new MySqlDBEinrichtungKlasse();

            einrichtung.OpenConnection();
            einrichtung.Execute(dbErstellungMeineVersion);
            einrichtung.CloseConnection();

            Console.WriteLine("Verbindung wurde hergestellt, SQL-Statement ist durch und Verbindung wurde beendet - Juhuuuu!");
            Console.ReadLine();
        }
    }
}
