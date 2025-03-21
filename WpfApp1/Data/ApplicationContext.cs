using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls.Ribbon;
using WpfApp1.Model;

namespace WpfApp1.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> DataUsers { get; set; }

        public ApplicationContext()
        {
            if (Database.EnsureCreated() == true)
            {
                DataUsers.Load();
                DataUsers.AddRange(_users);
                this.SaveChanges();
            }
            else
            {
                DataUsers.Load();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Users.db");
        }

        private static List<User> _users = new List<User>()
        {
            new()
            {
                Name = "Test_2",
                Email = "qwe_2@mail.ru",
                Password = "password_2",
                IsValid = false,
            },
            new()
            {
                Name = "Test_1",
                Email = "qwe_1@mail.ru",
                Password = "password_1",
                IsValid = true,
            },
            new()
            {
                Name = "Test_4",
                Email = "qwe_4@mail.ru",
                Password = "password_4",
                IsValid = true,
            },
            new()
            {
                Name = "Test_3",
                Email = "qwe_3@mail.ru",
                Password = "password_3",
                IsValid = false,
            },
        };
    }
}
