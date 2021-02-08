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
            Database db = new Database();
            
            // Insert into database
            //string query = "INSERT INTO Albums ('Title', 'Artist') VALUES (@Title, @Artist)";
            //SQLiteCommand command = new SQLiteCommand(query, db.conn);
            //db.OpenConnection();
            //command.Parameters.AddWithValue("@Title", "Brown Pizza");
            //command.Parameters.AddWithValue("@Artist", "Nick Gp,ez");

            //var rows = command.ExecuteNonQuery();
            //db.CloseConnection();

            //Console.WriteLine("Number of Insertions: {0}", rows);
            //Console.ReadKey();


            // Read from database
            string query = "SELECT * FROM Albums";
            SQLiteCommand command = new SQLiteCommand(query, db.conn);
            db.OpenConnection();

            SQLiteDataReader result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Console.WriteLine("Album: {0} Artist: {1}", result[1], result[2]);
                }
            }
            db.CloseConnection();

            Console.ReadKey();
        }
    }
}
