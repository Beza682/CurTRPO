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
    /// Логика взаимодействия для Status.xaml
    /// </summary>
    public partial class Status : Window
    {
        gr691_baoEntities db;
        public Status()
        {
            InitializeComponent();
            db = new gr691_baoEntities();
        }
        private void Cyr_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCL = new CheckCl();
            if (checkCL.Cyr_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Status_Add(object sender, RoutedEventArgs e)
        {
            StatusCl status = new StatusCl();
            if (status.Add(Status_Name.Text) == true)
            {
                Status_Name.Clear();
                db = new gr691_baoEntities();
                StatGrid.ItemsSource = db.CurTRPO_Status.ToList();
            }
        }

        private void Status_Update(object sender, RoutedEventArgs e)
        {
            StatusCl status = new StatusCl();
            db = new gr691_baoEntities();
            CurTRPO_Status curTRPO_Status = StatGrid.SelectedItem as CurTRPO_Status;

            if (StatGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Status.Where(i => i.Id == curTRPO_Status.Id).FirstOrDefault();
            if (status.Update(curTRPO_Status != null ? curTRPO_Status.Id.ToString() : "0", Status_Name.Text) == true)
            {
                Status_Name.Clear();
                db = new gr691_baoEntities();
                StatGrid.ItemsSource = db.CurTRPO_Status.ToList();
            }
        }

        private void Status_Delete(object sender, RoutedEventArgs e)
        {
            StatusCl status = new StatusCl();
            CurTRPO_Status curTRPO_Status = StatGrid.SelectedItem as CurTRPO_Status;

            if (StatGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Status.Where(i => i.Id == curTRPO_Status.Id).FirstOrDefault();
            status.Delete(curTRPO_Status != null ? curTRPO_Status.Id.ToString() : "0");
            db = new gr691_baoEntities();
            StatGrid.ItemsSource = db.CurTRPO_Status.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_baoEntities();
            StatGrid.ItemsSource = db.CurTRPO_Status.ToList();
        }
    }
}
