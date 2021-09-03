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
    /// Логика взаимодействия для Ship_Type.xaml
    /// </summary>
    public partial class Ship_Type : Window
    {
        gr691_baoEntities db;
        public Ship_Type()
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
        private void Ship_Type_Add(object sender, RoutedEventArgs e)
        {
            ShipTypeCl type = new ShipTypeCl();
            if (type.Add(Ship_Type_Name.Text) == true)
            {
                Ship_Type_Name.Clear();
                db = new gr691_baoEntities();
                ShipTypeGrid.ItemsSource = db.CurTRPO_Ship_Type.ToList();
            }
        }

        private void Ship_Type_Update(object sender, RoutedEventArgs e)
        {
            ShipTypeCl type = new ShipTypeCl();
            db = new gr691_baoEntities();
            CurTRPO_Ship_Type curTRPO_Ship_Type = ShipTypeGrid.SelectedItem as CurTRPO_Ship_Type;

            if (ShipTypeGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Роли", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Ship_Type.Where(i => i.Id == curTRPO_Ship_Type.Id).FirstOrDefault();
            if (type.Update(curTRPO_Ship_Type != null ? curTRPO_Ship_Type.Id.ToString() : "0", Ship_Type_Name.Text) == true)
            {
                Ship_Type_Name.Clear();
                db = new gr691_baoEntities();
                ShipTypeGrid.ItemsSource = db.CurTRPO_Ship_Type.ToList();
            }

        }

        private void Ship_Type_Delete(object sender, RoutedEventArgs e)
        {
            ShipTypeCl type = new ShipTypeCl();
            CurTRPO_Ship_Type curTRPO_Ship_Type = ShipTypeGrid.SelectedItem as CurTRPO_Ship_Type;

            if (ShipTypeGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Роли", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Ship_Type.Where(i => i.Id == curTRPO_Ship_Type.Id).FirstOrDefault();
            type.Delete(curTRPO_Ship_Type != null ? curTRPO_Ship_Type.Id.ToString() : "0");
            db = new gr691_baoEntities();
            ShipTypeGrid.ItemsSource = db.CurTRPO_Ship_Type.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_baoEntities();
            ShipTypeGrid.ItemsSource = db.CurTRPO_Ship_Type.ToList();
        }
    }
}
