using System.Windows;
using WpfApp1.Data;
using WpfApp1.Model;

namespace WpfApp1.View.Admin
{
    public partial class WindowAdminPanel : Window
    {
        private ApplicationContext context;
        public WindowAdminPanel(ApplicationContext context)
        {
            InitializeComponent();
            this.context = context;

            ViewItems.ItemsSource = context.Items.Local.ToObservableCollection();
            ViewUsers.ItemsSource = context.Users.Local.ToObservableCollection();
        }

        private void Remove_User_Click(object sender, RoutedEventArgs e)
        {
            if(ViewUsers.SelectedItem != null)
            {
                context.Users.Remove((User)ViewUsers.SelectedItem);
                context.SaveChanges();
            }
        }
    }
}
