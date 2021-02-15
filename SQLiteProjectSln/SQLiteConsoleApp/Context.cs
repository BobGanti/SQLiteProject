using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteConsoleApp
{
    class Context : DbContext
    {
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var sqliteConnectionInitializer = new SQLiteConnection(GetConnectionString("AppDb"));

        //}
        public Context()
        {

        }
        public Context(string name)
        {
            GetConnectionString(name);
        }
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<NameCores> NameCoress { get; set; }


    }
}
