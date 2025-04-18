using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; } = new Role()
        {
            Id = 2,
            Name = "user",
        };
        public User() { }
        public override string ToString()
        {
            return $"{Id}:{Name}";
        }
    }
}
