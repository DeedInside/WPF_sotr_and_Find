using System.Windows;
using WpfApp1.Data;

namespace WpfApp1.View.Auto
{
    /// <summary>
    /// Логика взаимодействия для RegUser.xaml
    /// </summary>
    public partial class RegUser : Window
    {
        public User NewUser;
        public RegUser()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(BoxName.Text) & !string.IsNullOrEmpty(BoxPass.Text) & !string.IsNullOrEmpty(BoxEmail.Text))
            {
                NewUser = new User()
                {
                    Name = BoxName.Text,
                    Password = BoxPass.Text,
                    Email = BoxEmail.Text,
                };
                DialogResult = true;
                return;
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            return;
        }
    }
}
