using System.Windows;
using WpfApp1.Data;

namespace WpfApp1.View.Auto
{
    public partial class AutUser : Window
    {
        ApplicationContext context;
        public AutUser()
        {
            InitializeComponent();
            context = new ApplicationContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(BoxName.Text) & !string.IsNullOrEmpty(BoxPass.Text))
            {
                var user = context.Users.FirstOrDefault(q => q.Email == BoxName.Text & q.Password == BoxPass.Text);
                if (user != null)
                {
                    Cooke.User = user;
                    DialogResult = true;
                    return;
                }
                else
                {
                    MessageBox.Show("Логин или паровь не верны");
                }
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            RegUser regUser = new RegUser();

            regUser.ShowDialog();

            if(regUser.DialogResult == true)
            {
                regUser.NewUser.Role = context.Roles.FirstOrDefault( q => q.Name == "user");
                context.Users.Add(regUser.NewUser);
                context.SaveChanges();
            }
        }
    }
}
