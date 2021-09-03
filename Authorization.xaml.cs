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

namespace CurTRPO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        gr691_baoEntities db;
        public Authorization()
        {
            InitializeComponent();
            db = new gr691_baoEntities();
        }
        private void Auth_Enter(object sender, RoutedEventArgs e)
        {
            var authorization = db.CurTRPO_Accounts.FirstOrDefault(l => l.login == Auth_Login.Text && l.password == Auth_Password.Password);
            AuthCl auth = new AuthCl();
            if (auth.Enter(Auth_Login.Text, Auth_Password.Password) == true)
            {
                switch (authorization.Role_Id)
                {
                    case 1:
                        Hide();
                        new Admin_Home().ShowDialog();
                        Application.Current.Shutdown();
                        break;
                    case 2:
                        Hide();
                        new Disp_Home().ShowDialog();
                        Application.Current.Shutdown();
                        break;
                    case 3:
                        Hide();
                        new Client_Home().ShowDialog();
                        Application.Current.Shutdown();
                        break;
                }
            }
        }
        private void Registration(object sender, RoutedEventArgs e)
        {
            new Registration().ShowDialog();
        }
        private void Acc_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCL = new CheckCl();
            if (checkCL.Acc_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
    }
}
