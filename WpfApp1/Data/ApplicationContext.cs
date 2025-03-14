using WpfApp1.Model;

namespace WpfApp1.Data
{
    public class ApplicationContext
    {
        private static List<User> _users = new List<User>()
        {
            new()
            {
                Id = 2,
                Name = "Test_2",
                Email = "qwe_2@mail.ru",
                Password = "password_2",
                IsValid = false,
            },
            new()
            {
                Id = 1,
                Name = "Test_1",
                Email = "qwe_1@mail.ru",
                Password = "password_1",
                IsValid = true,
            },
            new()
            {
                Id = 4,
                Name = "Test_4",
                Email = "qwe_4@mail.ru",
                Password = "password_4",
                IsValid = true,
            },
            new()
            {
                Id = 3,
                Name = "Test_3",
                Email = "qwe_3@mail.ru",
                Password = "password_3",
                IsValid = false,
            },
        };
    
        public List<User> Users { set { _users = value; } get { return _users; } }
    }
}
