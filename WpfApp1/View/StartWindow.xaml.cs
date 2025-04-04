using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.View.Auto;

namespace WpfApp1.View
{
    public partial class StartWindow : Window
    {
        private ApplicationContext context { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public Item SelectesViewItem { get; set; }
        public StartWindow()
        {
            AutUser autUser = new AutUser();

            autUser.ShowDialog();

            if(autUser.DialogResult == false)
            {
                Close();
            }

            InitializeComponent();

            if(Cooke.User.Role.Name != "admin")
            {
                buttonRemove.IsEnabled = false;
            }

            context = new ApplicationContext();
            DataContext = this;

            Items = context.Items.Local.ToObservableCollection();

        }

        private void Add_New_Item_Click(object sender, RoutedEventArgs e)
        {
            AddNewItem addNewItem = new AddNewItem();

            addNewItem.ShowDialog();

            if (addNewItem.DialogResult == true)
            {
                context.Items.Add(addNewItem.NewItem);
                context.SaveChanges();
            }
        }
        private void Binding_User_To_Item_Click(object sender, RoutedEventArgs e)
        {
            if(SelectesViewItem != null)
            {
                BindingUserToItem userToItem = new BindingUserToItem(context.Users.ToList());

                userToItem.ShowDialog();

                if (userToItem.DialogResult == true)
                {
                    SelectesViewItem.Client = userToItem.SelectUser;
                    context.Items.Update(SelectesViewItem);
                    context.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("не выбран инвентарь");
            }
        }
        private void Remove_Item_Click(object sender, RoutedEventArgs e)
        {
            if(Cooke.User.Role.Name != "admin")
            {
                MessageBox.Show("не достаточно прав доступа");
                return;
            }
            if(SelectesViewItem != null)
            {
                context.Remove(SelectesViewItem);
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("не выбран удаляемый объект");
            }
        }
    }
}
