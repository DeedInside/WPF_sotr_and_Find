using System.Windows;
using WpfApp1.Data;

namespace WpfApp1.View
{
    public partial class AddNewItem : Window
    {
        public Item NewItem { get; set; }
        public AddNewItem()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(boxName.Text) && !string.IsNullOrEmpty(boxDescription.Text) 
                && !string.IsNullOrEmpty(boxSize.Text) && !string.IsNullOrEmpty(boxPrice.Text))// проверка пустых полей
            {
                NewItem = new()
                {
                    Client = null,
                    Description = boxDescription.Text,
                    Discount = null,
                    IsValid = true,
                    Name = boxName.Text,
                    Price = Convert.ToDouble(boxPrice.Text),
                    Size = Convert.ToInt32(boxSize.Text)
                };
                DialogResult = true;
                return;
            }
            else
            {
                MessageBox.Show("не все поля заполнены");
            }
        }

        private void Cloce_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
