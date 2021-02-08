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
            if(db.CreateTable(tableName, columns));
            Console.WriteLine("The table {0} already exists", tableName);

            //string stm = "INSERT INTO " + tableName + " (FirstName, LastName, Age, Phone, Email) VALUES ('Michaeal', 'Jackson', 50, '1234567890', 'michael@yahoo.com')";
            //db.InsertData( "INSERT INTO " + tableName + " (Title, Artist) VALUES ('Offside', 'Jamie Fox')");

            // Udate
            string updateQ = "UPDATE " + tableName + " SET Title = 'Oliver Twist', Artist = 'Charles Dickens' WHERE Id == 17";
            db.UpdateData(updateQ);

            // ReadAll
            string query = "SELECT * FROM " + tableName;
            db.ReadAll(query);

            // Insert into database
            //string insertQ = "INSERT INTO Albums ('Title', 'Artist') VALUES ('Growing U', 'Leb Nti')";
            //db.InsertData(insertQ);

            //string createQ = "CREATE TABLE [IF NOT EXISTS].Family ('Id integer PRIMARY KEY', 'Firstname text', 'Lastname text', 'Age integer') [WITHOUT ROWID];";
            //  db.CreateTable(createQ);

            // Read from database
            //string query = "SELECT * FROM Albums";
            //SQLiteCommand command = new SQLiteCommand(query, db.conn);
            //db.OpenConnection();

            //SQLiteDataReader result = command.ExecuteReader();
            //if (result.HasRows)
            //{
            //    while (result.Read())
            //    {
            //        Console.WriteLine("Album: {0} Artist: {1}", result[1], result[2]);
            //    }
            //}
            //db.CloseConnection();

            //Console.ReadKey();
        }
    }
}
