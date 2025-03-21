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
using WpfApp1.Data;
using WpfApp1.Model;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new()
            {
                Name = BoxName.Text,
                Email = BoxEmail.Text,
                Password = BoxPass.Text,
                IsValid = CheckIsValid.IsChecked.Value
            };
            
            using (ApplicationContext _context = new ApplicationContext())
            {
                _context.DataUsers.Add(user);
                _context.SaveChanges();
            }

            DialogResult = true;
        }
    }
}
