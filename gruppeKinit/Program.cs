using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace gruppeKinit
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbErstellung = @"    CREATE SCHEMA IF NOT EXISTS `gruppeK` DEFAULT CHARACTER SET utf8;
                                        USE `gruppeK` ;


                                        DROP TABLE IF EXISTS `gruppeK`.`Users` ;

                                        CREATE TABLE IF NOT EXISTS `gruppeK`.`Users` 
                                        (
                                        `idUsers` INT NOT NULL,
                                        `vorname` VARCHAR(45) NULL,
                                        `nachname` VARCHAR(45) NULL,
                                        `username` VARCHAR(45) NULL,
                                        PRIMARY KEY(`idUsers`)
                                        )
                                        ENGINE = InnoDB;


                                        DROP TABLE IF EXISTS `gruppeK`.`TodoItems` ;

                                        CREATE TABLE IF NOT EXISTS `gruppeK`.`TodoItems` 
                                        (
                                        `idTodoItems` INT NOT NULL,
                                        `TodoItemContent` VARCHAR(100) NULL,
                                        `DoneOrNot` BIT(2) NULL,
                                        PRIMARY KEY(`idTodoItems`)
                                        )
                                        ENGINE = InnoDB;


                                        DROP TABLE IF EXISTS `gruppeK`.`DailyNotes` ;

                                        CREATE TABLE IF NOT EXISTS `gruppeK`.`DailyNotes` 
                                        (
                                        `idDailyNotes` INT NOT NULL,
                                        `NoteContent` VARCHAR(255) NULL,
                                        PRIMARY KEY(`idDailyNotes`)
                                        )
                                        ENGINE = InnoDB;


                                        DROP TABLE IF EXISTS `gruppeK`.`Moods` ;

                                        CREATE TABLE IF NOT EXISTS `gruppeK`.`Moods` 
                                        (
                                        `idMoods` INT NOT NULL,
                                        `Mood` TINYINT(10) NULL,
                                        PRIMARY KEY(`idMoods`)
                                        )
                                        ENGINE = InnoDB;


                                        DROP TABLE IF EXISTS `gruppeK`.`DiaryEntry` ;

                                        CREATE TABLE IF NOT EXISTS `gruppeK`.`DiaryEntry` 
                                        (
                                        `idDiaryEntry` INT NOT NULL,
                                        `idUsers` INT NULL,
                                        `idMoods` INT NULL,
                                        `idTodoItems` INT NULL,
                                        `idDailyNotes` INT NULL,
                                        PRIMARY KEY(`idDiaryEntry`),
                                        INDEX `idUsers_idx` (`idUsers` ASC) VISIBLE,
                                        INDEX `idMoods_idx` (`idMoods` ASC) VISIBLE,
                                        INDEX `idTodoItems_idx` (`idTodoItems` ASC) VISIBLE,
                                        INDEX `idDailyNotes_idx` (`idDailyNotes` ASC) VISIBLE,
                                        CONSTRAINT `idUsers`
                                            FOREIGN KEY(`idUsers`)
                                            REFERENCES `gruppeK`.`Users` (`idUsers`)
                                            ON DELETE NO ACTION
                                            ON UPDATE NO ACTION,
                                        CONSTRAINT `idMoods`
                                            FOREIGN KEY(`idMoods`)
                                            REFERENCES `gruppeK`.`Moods` (`idMoods`)
                                            ON DELETE NO ACTION
                                            ON UPDATE NO ACTION,
                                        CONSTRAINT `idTodoItems`
                                            FOREIGN KEY(`idTodoItems`)
                                            REFERENCES `gruppeK`.`TodoItems` (`idTodoItems`)
                                            ON DELETE NO ACTION
                                            ON UPDATE NO ACTION,
                                        CONSTRAINT `idDailyNotes`
                                            FOREIGN KEY(`idDailyNotes`)
                                            REFERENCES `gruppeK`.`DailyNotes` (`idDailyNotes`)
                                            ON DELETE NO ACTION
                                            ON UPDATE NO ACTION
                                            )
                                            ENGINE = InnoDB;

                                        SET SQL_MODE = '';
                                        DROP USER IF EXISTS root;
                                        SET SQL_MODE = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';
                                        
                                        CREATE USER 'root' IDENTIFIED BY '****';

                                        GRANT SELECT, INSERT, TRIGGER, UPDATE, DELETE ON TABLE `gruppeK`.*TO 'root';
                                        GRANT SELECT, INSERT, TRIGGER ON TABLE `gruppeK`.*TO 'root';
                                        GRANT ALL ON `gruppeK`.*TO 'root';
                                        GRANT EXECUTE ON ROUTINE `gruppeK`.*TO 'root';
                                        GRANT SELECT ON TABLE `gruppeK`.*TO 'root';"
            ;

            MySqlDBEinrichtungKlasse test1 = new MySqlDBEinrichtungKlasse();
            Console.ReadLine();

            test1.OpenConnection();
        }
    }
}
