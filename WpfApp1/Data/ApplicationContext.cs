using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        public ApplicationContext() 
        {
            if(Database.EnsureCreated() == true)
            {
                //создал
                Users.AddRange(_users);
                Items.AddRange(_items);
                SaveChanges();
                Users.Load();
                Items.Load();
            }
            else
            {
                //она уже была
                Users.Load();
                Items.Load();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Laba6.db");
        }

        private List<User> _users = new()
       {
           new User()
           {
               Id = 1,
               Email = "qwe_1@mail.ru",
               Name = "qwe_1",
               Password = "123"
           },
           new User()
           {
               Id = 2,
               Email = "qwe_2@mail.ru",
               Name = "qwe_2",
               Password = "123"
           },new User()
           {
               Id = 3,
               Email = "qwe_3@mail.ru",
               Name = "qwe_3",
               Password = "123"
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
