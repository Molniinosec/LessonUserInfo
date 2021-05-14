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
    /// Логика взаимодействия для WindowUser.xaml
    /// </summary>
    public partial class WindowUser : Window
    {
        public WindowUser()
        {
            InitializeComponent();
            txtHello.Text = $"{UserData.worker.UserId} {UserData.worker.LastName} {UserData.worker.FirstName} {UserData.worker.MiddleName} {UserData.worker.Gender.Gendername} {UserData.worker.Role.Rolename}  {UserData.worker.Dateofbirth} {UserData.worker.Login} {UserData.worker.Password}";
            
        }
    }
}
