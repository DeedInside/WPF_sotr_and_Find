using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.Model;
using WpfApp1.View;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (ApplicationContext _context = new ApplicationContext())
            {
                ListViewUsers.ItemsSource = _context.DataUsers.Local.ToObservableCollection();
            }
        }

        private void Add_User__Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow();

            createUserWindow.ShowDialog();

            if(createUserWindow.DialogResult == true)
            {
                ListViewUsers.Items.Refresh();
            }
        }
    }
}