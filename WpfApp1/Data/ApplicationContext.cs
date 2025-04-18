using Microsoft.EntityFrameworkCore;
using WpfApp1.Model;

namespace WpfApp1.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        public ApplicationContext() 
        {
            if(Database.EnsureCreated() == true)
            {
                //создал
                Roles.AddRange(_roles);
                //Users.AddRange(_users);
                Items.AddRange(_items);
                SaveChanges();
                Roles.Load();
                Users.Load();
                Items.Load();
            }
            else
            {
                //она уже была
                Roles.Load();
                Users.Load();
                Items.Load();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Laba6.db");
        }

        private List<Role> _roles = new()
        {
            new Role()
            {
                Id = 1,
                Name = "admin",
            },
            new Role()
            {
                Id = 2,
                Name = "user",
            }
        };

        private List<User> _users = new()
       {
           new User()
           {
               Id = 1,
               Email = "qwe_1@mail.ru",
               Name = "qwe_1",
               Password = "123",
               Role = new Role()
               {
                    Id = 2,
                    Name = "user",
               }
           },
           new User()
           {
               Id = 2,
               Email = "qwe_2@mail.ru",
               Name = "qwe_2",
               Password = "123",
               Role = new Role()
                {
                    Id = 2,
                    Name = "user",
                }
           },
            new User()
           {
               Id = 3,
               Email = "qwe_3@mail.ru",
               Name = "qwe_3",
               Password = "123",
               Role = new Role()
                {
                    Id = 2,
                    Name = "user",
                }
           },
            new User()
           {
               Id = 4,
               Email = "123",
               Name = "123",
               Password = "123",
               Role = new Role()
                {
                    Id = 1,
                    Name = "admin",
                }
           }
       };
        private List<Item> _items = new()
        {
            new Item()
            {
                Id = 1,
                Description = "Description",
                Discount = 10,
                IsValid = true,
                Name = "Item_1",
                Price = 1200.70,
                Size = 34,
            },
            new Item()
            {
                Id = 2,
                Description = "Description",
                IsValid = true,
                Name = "Item_2",
                Price = 4300.70,
                Size = 12,
            }
        };
    }
}
