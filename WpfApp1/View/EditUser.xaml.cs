using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public User NewUser { get; set; }

        public EditUser(User user)
        {
            InitializeComponent();
            BoxEmail.Text = user.Email;
            BoxName.Text = user.Name;
            CheckIsValid.IsChecked = user.IsValid;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewUser = new()
            {
                Name = BoxName.Text,
                Email = BoxEmail.Text,
                IsValid = CheckIsValid.IsChecked.Value
            };

            DialogResult = true;
        }
    }
}
