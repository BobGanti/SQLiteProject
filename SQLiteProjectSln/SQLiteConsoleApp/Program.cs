using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbName = "AlbumsDb";
            string tableName = "Albums";
            string columns = "Id INTEGER PRIMARY KEY UNIQUE, Firstname VARCHAR(50) NOT NULL, Lastname VARCHAR(50) NOT NULL, Age INT, Phone VARCHAR(50), Email VARCHAR(50)";

            DatabasAccesse db = new DatabasAccesse(dbName);
            Console.WriteLine(db.TableExists(tableName));
            Console.ReadKey();
            //if (db.CreateTable(tableName, columns));
           // Console.WriteLine("The table {0} already exists", tableName);

            //string stm = "INSERT INTO " + tableName + " (FirstName, LastName, Age, Phone, Email) VALUES ('Michaeal', 'Jackson', 50, '1234567890', 'michael@yahoo.com')";
            //db.InsertData( "INSERT INTO " + tableName + " (Title, Artist) VALUES ('Offside', 'Jamie Fox')");

            // Udate
            string updateQ = "UPDATE " + tableName + " SET Title = 'Oliver Twist', Artist = 'Charles Dickens' WHERE Id == 17";
            //db.UpdateData(updateQ);

            // ReadAll
            string query = "SELECT * FROM " + tableName;
            //db.ReadAll(query);
        }
    }
}
