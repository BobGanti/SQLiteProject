using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SQLiteConsoleApp
{
    class DatabasAccesse
    {
        public readonly SQLiteConnection conn;

        public DatabasAccesse()
        {}

        public DatabasAccesse(string name)
        {
            string cs = ConfigurationManager.ConnectionStrings[name].ConnectionString; ;
            conn = new SQLiteConnection(cs);

            string dbName = cs.Split('=')[1];

            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
            }
        }

        public bool CreateTable(string tableName, string columns)
        {
            string stm = "CREATE TABLE " + tableName + " ("+columns+")";

            OpenConnection();

            SQLiteCommand command = new SQLiteCommand(stm, conn);
            try
            {
                command.ExecuteNonQuery();

                CloseConnection();
                return true;
            }
            catch (Exception)
            {
                CloseConnection();
                return false;
            }

        }

        public void InsertData(string stm)
        {
            OpenConnection();

            SQLiteCommand command = new SQLiteCommand(stm, conn);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        //Read from database
        public void ReadAll(string stm)
        {
            SQLiteCommand command = new SQLiteCommand(stm, conn);
            OpenConnection();

            SQLiteDataReader result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Console.WriteLine("Album: {0} Artist: {1} {2}", result[0], result[1], result[2]);
                }

            }
            else 
            { 
                Console.WriteLine("Table is Empty"); 
            }

            CloseConnection();        

            Console.ReadKey();
        }
        
        public void UpdateData(string stm)
        {
            OpenConnection();

            SQLiteCommand command = new SQLiteCommand(stm, conn);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        //tableExists
        public bool TableExists(string tableName)
        {
            bool exists;
            OpenConnection();

            try
            {
                var command = new SQLiteCommand(
                  "SELECT CASE WHEN EXISTS((SELECT * FROM Information_schema.Tables WHERE Table_name = '" + tableName + "')) then 1 else 0 end", conn);

                exists = (int)command.ExecuteScalar() == 1;
            }
            catch
            {
                try
                {
                    exists = true;
                    var cmdOthers = new SQLiteCommand("select 1 from " + tableName + " where 1 = 0", conn);
                    cmdOthers.ExecuteNonQuery();
                }
                catch
                {
                    exists = false;
                }
            }
            CloseConnection();
            return exists;
        }

        public void OpenConnection()
        {
            if(conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        public void CloseConnection()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }
    }
}
