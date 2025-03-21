using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WpfApp1.Model
{
    /// <summary>
    /// my user
    /// </summary>
    public class User: INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        private string email;
        public string Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }
        private string password;
        public string Password { get { return password; } set { password = value; OnPropertyChanged(nameof(Password)); } }
        private bool isValid;
        public bool IsValid { get { return isValid; } set { isValid = value; OnPropertyChanged(nameof(IsValid)); } }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public override string ToString()
        {
            if(Role == null)
            {
                return $"{Name} - {Email} - {IsValid}";
            }
            return $"{Name} - {Email} - {IsValid} - {Role.Id} - {Role.Name}";
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
