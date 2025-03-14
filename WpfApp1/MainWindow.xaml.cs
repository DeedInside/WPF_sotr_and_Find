using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using WpfApp1.Data;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        ApplicationContext _context;
        public MainWindow()
        {
            InitializeComponent();
            
            _context = new ApplicationContext();
            
            ListViewUser.ItemsSource = _context.Users;
        }

        private void TextBox_select_to_Name_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string value = ((TextBox)sender).Text;

            string select = ComboBoxFind.Text;

            if (value == "")
            {
                ListViewUser.ItemsSource = _context.Users;
            }
            else
            {
                switch (select)
                {
                    case "Name":
                        ListViewUser.ItemsSource = _context.Users.Where(q => q.Name.ToLower().Contains(value.ToLower()));
                        break;
                    case "Email":
                        ListViewUser.ItemsSource = _context.Users.Where(q => q.Email.ToLower().Contains(value.ToLower()));
                        break;
                    case "Valid":
                        ListViewUser.ItemsSource = _context.Users.Where(q => q.IsValid.ToString().ToLower() == value.ToLower());
                        break;
                }
            }
        }

        private void ComboBoxFind_Selected(object sender, RoutedEventArgs e)
        {
            TextBoxFind.Text = "";
            if(ListViewUser != null)
            {
                ListViewUser.ItemsSource = _context.Users;
            }
        }

        private void ComboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewUser == null)
            {
                return;
            }
            //string select = ((ComboBox)sender).SelectedItem as ; //ComboBoxFind.Text; //((ComboBox)sender).Text;
            string select = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            switch (select)
            {
                case "Name":
                    ListViewUser.ItemsSource = _context.Users.OrderBy(q => q.Name);
                    break;
                case "Email":
                    ListViewUser.ItemsSource = _context.Users.OrderBy(q => q.Email);
                    break;
                case "Valid":
                    ListViewUser.ItemsSource = _context.Users.OrderBy(q => q.IsValid);
                    break;
            }
        }
    }
}