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


namespace LessonUserInfo.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>


    public partial class WindowAdmin : Window
    {
        private List<Role> roles = new List<Role>();

        private List<Worker> userlist = new List<Worker>();
        public WindowAdmin()
        {
            InitializeComponent();
            Lvinfo.ItemsSource = Ent.context.Worker.ToList();
            txtHello.Text = $"Здравствуйте, {UserData.worker.LastName} {UserData.worker.FirstName} {UserData.worker.MiddleName}";
            roles = Ent.context.Role.ToList();
            roles.Insert(0, new Role { Rolename = "Все роли" });
            cmrole.ItemsSource = roles;
            cmrole.DisplayMemberPath = "Rolename";
            cmrole.SelectedIndex = 0;

        }

        private void Filter()
        {
            userlist = Ent.context.Worker.ToList();
            if (cmrole.SelectedIndex != 0)
            {
                userlist = userlist.Where(i => i.RoleId == cmrole.SelectedIndex).ToList();
            }
            userlist = userlist.Where(i => i.LastName.Contains(txtsearch.Text) || i.FirstName.Contains(txtsearch.Text) || i.MiddleName.Contains(txtsearch.Text)).ToList();

            Lvinfo.ItemsSource = userlist;
        }
        private void Btndelete_Click(object sender, RoutedEventArgs e)
        {
            var resMess = MessageBox.Show("Удалить пользователя", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resMess == MessageBoxResult.Yes)
            {
                if (Lvinfo.SelectedItem is Worker user)
                {
                    Ent.context.Worker.Remove(user);
                    Ent.context.SaveChanges();
                    Lvinfo.ItemsSource = Ent.context.Worker.ToList();
                }
            }
     
        }

        private void Btnadd_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminmenu = new AdminMenu();
            Hide();
            adminmenu.ShowDialog();
            Lvinfo.ItemsSource = Ent.context.Worker.ToList();
            Show();
        }

        private void Btnсрфтпу_Click(object sender, RoutedEventArgs e)
        {
            if(Lvinfo.SelectedItem is Worker user)
            {
                AdminMenu adminMenu = new AdminMenu(user);
                Hide();
                adminMenu.ShowDialog();
                Lvinfo.ItemsSource = Ent.context.Worker.ToList();
                Show();
            }
        }

        private void cmrole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
