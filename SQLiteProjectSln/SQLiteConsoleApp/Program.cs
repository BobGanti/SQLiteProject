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
            //Console.WriteLine(db.TableExists(tableName));
            
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

            NameCores ns = new NameCores
            {
                Name = "Judith",
                Scores = 15
            };

            Employee emp = new Employee
            {
                Firstname = "Paddy",
                Lastname = "Allen",
                Age = 65
            };
            AddEmployee(emp);

            GetEmployee(1);
            var dbemp = GetEmployee(1);
            Console.WriteLine(dbemp.Firstname);
            Console.ReadLine();


            Member m = new Member
            {
                Firstname = "Bob",
                Lastname = "Nti",
                Age = 75,
                Phone = "12345678"
            };

            AddMember(m);
            var dbm = GetMember(1);

            Console.WriteLine(dbm.Firstname);
            Console.ReadLine();
        }

        public static void AddEmployee(Employee emp)
        {
            var _context = new Context("Employee");
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }

        public static void AddMember(Member p)
        {
            var _context = new Context("Member");
            _context.Members.Add(p);
            _context.SaveChanges();
        }

        public static Member GetMember(int id)
        {
            Member member;
            using(Context _context = new Context("Member"))
            {
                member = _context.Members.Find(id);
            }
            return member;
        }

        public static Employee GetEmployee(int id)
        {

            Employee emp;
            using (Context db = new Context("Employee"))
            {
                emp = db.Employees.Find(id);

            }
            return emp;
        }

    }
}
