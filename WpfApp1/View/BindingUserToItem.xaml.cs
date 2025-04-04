using System.Windows;
using WpfApp1.Data;

namespace WpfApp1.View
{
    public partial class BindingUserToItem : Window
    {
        private ApplicationContext context;
        public List<User> Users { get; set; }
        public User SelectUser { get; set; }
        public BindingUserToItem()
        {
            InitializeComponent();
            DataContext = this;
            context = new ApplicationContext();
            Users = context.Users.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(SelectUser != null)
            { 
                DialogResult = true;
                return;
            }
            else
            {
                MessageBox.Show("Пользователь не выбран");
            }
        }

        private void Cloce_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
