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
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        private bool isEdut;
        private Worker editUser;
        public AdminMenu()
        {
            InitializeComponent();
            cmbRole.ItemsSource = Ent.context.Role.ToList();
            cmbRole.DisplayMemberPath = "Rolename";
            cmbRole.SelectedIndex = 2;
            cmdGender.ItemsSource = Ent.context.Gender.ToList();
            cmdGender.DisplayMemberPath = "Gendername";
            cmdGender.SelectedIndex = 1;
            isEdut = false;
        }

        public AdminMenu(Worker user)
        {
            InitializeComponent();
            cmbRole.ItemsSource = Ent.context.Role.ToList();
            cmbRole.DisplayMemberPath = "Rolename";
            cmbRole.SelectedIndex = 2;
            cmdGender.ItemsSource = Ent.context.Gender.ToList();
            cmdGender.DisplayMemberPath = "Gendername";
            cmdGender.SelectedIndex = 1;
            TB_FName.Text = user.FirstName;
            TB_lName.Text = user.LastName;
            TB_MName.Text = user.MiddleName;
            cmdGender.SelectedIndex = user.GenderId;
            cmbRole.SelectedIndex = user.RoleId;
            TB_Login.Text = user.Login;
            TB_Passsword.Password = user.Password;
            TB_Dateofbirth.DisplayDate = user.Dateofbirth;
            editUser = user;
            isEdut = true;
        }
        private void Btn_Change_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isEdut == false)
                {
                    Worker userd = new Worker();
                    userd.LastName = TB_lName.Text;
                    userd.FirstName = TB_FName.Text;
                    if (!string.IsNullOrWhiteSpace(TB_MName.Text))
                    {
                        userd.MiddleName = TB_MName.Text;
                    }
                    userd.RoleId = cmbRole.SelectedIndex + 1;
                    userd.GenderId = cmdGender.SelectedIndex + 1;
                    userd.Dateofbirth = TB_Dateofbirth.DisplayDate;
                    userd.Login = TB_Login.Text;
                    userd.Password = TB_Passsword.Password;
                    Ent.context.Worker.Add(userd);
                    Ent.context.SaveChanges();
                    MessageBox.Show("Пользователь добавлен");
                    Close();
                }
                else
                {
                    editUser.LastName = TB_lName.Text;
                    editUser.FirstName = TB_FName.Text;
                    editUser.MiddleName = TB_MName.Text;
                    editUser.RoleId = cmbRole.SelectedIndex + 1;
                    editUser.GenderId = cmdGender.SelectedIndex + 1;
                    editUser.Login = TB_Login.Text;
                    editUser.Password = TB_Passsword.Password;
                    editUser.Dateofbirth = TB_Dateofbirth.DisplayDate;
                    var resMess = MessageBox.Show("Подтвердить действие", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resMess == MessageBoxResult.Yes)
                    {
                        Ent.context.SaveChanges();
                        MessageBox.Show("Пользователь изменен");
                        Close();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Непроизвольная ошибка базы данных");
            }
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
