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
        private ApplicationContext _context;
        public ObservableCollection<User> Users { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            _context = new ApplicationContext();
            //ListViewUsers.ItemsSource
            Users = _context.DataUsers.Local.ToObservableCollection();
            ListViewRole.ItemsSource = _context.DataRole.Local.ToObservableCollection();
        }

        private void Add_User_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow();

            createUserWindow.ShowDialog();

            if(createUserWindow.DialogResult == true)
            {
                _context.DataUsers.Add(createUserWindow.NewUser);
                _context.SaveChanges();
            }
        }

        private void Remove_User_Click(object sender, RoutedEventArgs e)
        {
            if(ListViewUsers.SelectedIndex != -1)
            {
                _context.DataUsers.Remove((User)ListViewUsers.SelectedItem);
                _context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Пользователь не выбран");
            }
        }

        private void Edit_user_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)ListViewUsers.SelectedItem;
            EditUser editUser = new EditUser(selectedUser);

            editUser.ShowDialog();

            if(editUser.DialogResult == true)
            {
                selectedUser.Email = editUser.NewUser.Email;
                selectedUser.Name = editUser.NewUser.Name;
                selectedUser.IsValid = editUser.NewUser.IsValid;

                _context.Entry(selectedUser).State = EntityState.Modified;
                //_context.Update(selectedUser);
                _context.SaveChanges();
                //ListViewUsers.Items.Refresh();
            }
            else
            {

            }
        }

        private void Add_Role_to_User_Click(object sender, RoutedEventArgs e)
        {
            User addRole = ((User)ListViewUsers.SelectedItem);
            
            addRole.Role = (Role)ListViewRole.SelectedItem;
            
            _context.Entry(addRole).State = EntityState.Modified;
            //_context.Update(selectedUser);
            _context.SaveChanges();
            ListViewUsers.Items.Refresh();
        }
    }
}