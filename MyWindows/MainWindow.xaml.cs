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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LessonUserInfo.MyWindows;

namespace LessonUserInfo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnlog_Click(object sender, RoutedEventArgs e)
        {
            var user = Ent.context.Worker.ToList().
                Where(i => i.Login == tblog.Text && i.Password == pbpas.Password).FirstOrDefault();
             if (user!=null)
            {
                UserData.worker = user;
                switch (user.RoleId)
                {
                    case 1:
                        WindowAdmin winad = new WindowAdmin();
                        Hide();
                        winad.ShowDialog();
                        Close();
                        
                        break;
                    case 2:
                        WindowUser winuser = new WindowUser();
                        Hide();
                        winuser.ShowDialog();
                        Close();
                        break;
                    case 3:
                        WindowManager winmanager = new WindowManager();
                        Hide();
                        winmanager.ShowDialog();
                        Close();    
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
