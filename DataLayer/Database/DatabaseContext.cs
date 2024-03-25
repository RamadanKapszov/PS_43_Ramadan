using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder,databaseFile);
            optionsBuilder.UseSqlite($"Data Source ={databasePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e=>e.Id).ValueGeneratedOnAdd();

            //Create users
            var user = new DatabaseUser()
            {
                Id = 1,
                Name = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };
            var user2 = new DatabaseUser()
            {
                Id = 2,
                Name = "Marrie Curie",
                Password = "12345",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(20)
            };
            var user3 = new DatabaseUser()
            {
                Id = 3,
                Name = "Lebron James",
                Password = "123456",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(15)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user) ;
            modelBuilder.Entity<DatabaseUser>().HasData(user2) ;
            modelBuilder.Entity<DatabaseUser>().HasData(user3) ;
        }
    }
}
