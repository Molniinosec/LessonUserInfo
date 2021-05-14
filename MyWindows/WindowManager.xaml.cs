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
    /// Логика взаимодействия для WindowManager.xaml
    /// </summary>
    public partial class WindowManager : Window
    {
        public WindowManager()
        {
            InitializeComponent();
            Lvinfo.ItemsSource = Ent.context.Worker.ToList();
            txtHello.Text = $"Здравствуйте, {UserData.worker.LastName} {UserData.worker.FirstName} {UserData.worker.MiddleName}";
        }
    }
}
