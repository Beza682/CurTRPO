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

namespace CurTRPO
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        gr691_baoEntities db;
        public Registration()
        {
            InitializeComponent();
            db = new gr691_baoEntities();
        }
        private void Reg_Buttom(object sender, RoutedEventArgs e)
        {
            RegCl reg = new RegCl();
            if (reg.Add(Reg_last_Name.Text, Reg_First_Name.Text, Reg_Mid_Name.Text, Reg_Phone.Text, Reg_Login.Text, Reg_Password.Password) == true)
            {
                Reg_last_Name.Clear();
                Reg_First_Name.Clear();
                Reg_Mid_Name.Clear();
                Reg_Login.Clear();
                Reg_Password.Clear();
                db = new gr691_baoEntities();
                Close();
            }
        }
        private void Acc_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCL = new CheckCl();
            if (checkCL.Acc_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Num_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCL = new CheckCl();
            if (checkCL.Num_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Cyr_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCL = new CheckCl();
            if (checkCL.Cyr_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
    }
}