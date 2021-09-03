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
    /// Логика взаимодействия для Client_Home.xaml
    /// </summary>
    public partial class Client_Home : Window
    {
        gr691_baoEntities db;
        public Client_Home()
        {
            InitializeComponent();
            Start_Cb.SelectedItem = UserText;
            db = new gr691_baoEntities();
        }
        //Ограничения на ввод символов (начало)
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
        private void Ship_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCL = new CheckCl();
            if (checkCL.Ship_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Time_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCL = new CheckCl();
            if (checkCL.Time_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Coord_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCL = new CheckCl();
            if (checkCL.Coord_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void RusName_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCL = new CheckCl();
            if (checkCL.RusName_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        //Ограничения на ввод символов (конец)

        //Вкладка расписание (начало)
        private void Shed_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string SS = Shed_search.Text;

            if (Shed_date.SelectedDate != null)
            {
                if (Shed_search.Text == null)
                {
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.Where(w => w.date == Shed_date.SelectedDate).ToList();
                    db = new gr691_baoEntities();
                    return;
                }
                else
                {
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.Where(w =>
                                             w.date == Shed_date.SelectedDate && w.CurTRPO_Users.last_name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Users.first_name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Users.middle_name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Ships.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Ships.CurTRPO_Ship_Type.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Ports.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Ports1.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Ports2.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Ports3.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Status.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.departure_time.ToString().Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.arrival_time.ToString().Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.price.ToString().Contains(SS)
                                          ).ToList();
                    db = new gr691_baoEntities();
                    return;
                }
            }
            else if (Shed_date.SelectedDate == null)
            {
                if (Shed_search.Text == "")
                {
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                    db = new gr691_baoEntities();
                    return;
                }
                else
                {
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.Where(w =>
                                             w.CurTRPO_Users.last_name.Contains(SS)
                                          || w.CurTRPO_Users.first_name.Contains(SS)
                                          || w.CurTRPO_Users.middle_name.Contains(SS)
                                          || w.CurTRPO_Ships.name.Contains(SS)
                                          || w.CurTRPO_Ships.CurTRPO_Ship_Type.name.Contains(SS)
                                          || w.CurTRPO_Ports.name.Contains(SS)
                                          || w.CurTRPO_Ports1.name.Contains(SS)
                                          || w.CurTRPO_Ports2.name.Contains(SS)
                                          || w.CurTRPO_Ports3.name.Contains(SS)
                                          || w.CurTRPO_Status.name.Contains(SS)
                                          || w.departure_time.ToString().Contains(SS)
                                          || w.arrival_time.ToString().Contains(SS)
                                          || w.price.ToString().Contains(SS)
                                          ).ToList();
                    db = new gr691_baoEntities();
                    return;
                }
            }
        }
        private void Shed_Sale(object sender, RoutedEventArgs e)
        {
            SaleCl sale = new SaleCl();
            CurTRPO_Shedule curTRPO_Shedule = ShedGrid.SelectedItem as CurTRPO_Shedule;

            if (ShedGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Поездки", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Shedule.Where(i => i.Id == curTRPO_Shedule.Id).FirstOrDefault();
            if (sale.AddClient(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0", Shed_client_seats.Text) == true)
            {
                Shed_client_seats.Clear();
                db = new gr691_baoEntities();
                ShedGrid.ItemsSource = db.CurTRPO_Shedule.Where(i => i.CurTRPO_Status.Id != 1 && i.price != null).ToList();
                SaleGrid.ItemsSource = db.CurTRPO_Trips.Where(i => i.User_Id == AuthCl.global_user).ToList();
            }
        }
        //Вкладка поездки (конец)

        //Вкладка покупки (начало)
        private void Sale_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string SS = Sale_search.Text;

            if (Sale_date.SelectedDate != null)
            {
                if (Sale_search.Text == "")
                {
                    SaleGrid.ItemsSource = db.CurTRPO_Trips.Where(w => w.CurTRPO_Shedule.date == Sale_date.SelectedDate).ToList();
                    db = new gr691_baoEntities();
                    return;
                }
                else
                {
                    SaleGrid.ItemsSource = db.CurTRPO_Trips.Where(w =>
                                             w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.CurTRPO_Users.last_name.Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.CurTRPO_Users.first_name.Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.CurTRPO_Users.middle_name.Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.CurTRPO_Shedule.CurTRPO_Ships.name.Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.CurTRPO_Shedule.CurTRPO_Ports.name.Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.CurTRPO_Shedule.CurTRPO_Ports1.name.Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.CurTRPO_Shedule.CurTRPO_Ports2.name.Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.CurTRPO_Shedule.CurTRPO_Ports3.name.Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.CurTRPO_Shedule.CurTRPO_Status.name.Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.CurTRPO_Shedule.departure_time.ToString().Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.CurTRPO_Shedule.arrival_time.ToString().Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.number_of_tickets.ToString().Contains(SS)
                                          || w.CurTRPO_Shedule.date == Sale_date.SelectedDate && w.total_price.ToString().Contains(SS)
                                          ).ToList();
                    db = new gr691_baoEntities();
                    return;
                }
            }
            else if (Sale_date.SelectedDate == null)
            {
                if (Sale_search.Text == "")
                {
                    SaleGrid.ItemsSource = db.CurTRPO_Trips.ToList();
                    db = new gr691_baoEntities();
                    return;
                }
                else
                {
                    SaleGrid.ItemsSource = db.CurTRPO_Trips.Where(w =>
                                             w.CurTRPO_Users.last_name.Contains(SS)
                                          || w.CurTRPO_Users.first_name.Contains(SS)
                                          || w.CurTRPO_Users.middle_name.Contains(SS)
                                          || w.CurTRPO_Shedule.CurTRPO_Ships.name.Contains(SS)
                                          || w.CurTRPO_Shedule.CurTRPO_Ports.name.Contains(SS)
                                          || w.CurTRPO_Shedule.CurTRPO_Ports1.name.Contains(SS)
                                          || w.CurTRPO_Shedule.CurTRPO_Ports2.name.Contains(SS)
                                          || w.CurTRPO_Shedule.CurTRPO_Ports3.name.Contains(SS)
                                          || w.CurTRPO_Shedule.CurTRPO_Status.name.Contains(SS)
                                          || w.CurTRPO_Shedule.departure_time.ToString().Contains(SS)
                                          || w.CurTRPO_Shedule.arrival_time.ToString().Contains(SS)
                                          || w.number_of_tickets.ToString().Contains(SS)
                                          || w.total_price.ToString().Contains(SS)
                                          ).ToList();
                    db = new gr691_baoEntities();
                    return;
                }
            }
        }
        //Вкладка покупки (конец)

        //Угловой комбобокс (начало)
        private void Exit_Window(object sender, RoutedEventArgs e)
        {
            Hide();
            new Authorization().ShowDialog();
            Application.Current.Shutdown();
        }
        //Угловой комбобокс (конец)

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var us = db.CurTRPO_Users.Where(i => i.Id == AuthCl.global_user).FirstOrDefault();
            UserText.Text = us.last_name + " " + us.first_name + " " + us.middle_name;

            ShedGrid.ItemsSource = db.CurTRPO_Shedule.Where(i => i.CurTRPO_Status.Id != 1 && i.price != null).ToList();
            SaleGrid.ItemsSource = db.CurTRPO_Trips.Where(i => i.User_Id == AuthCl.global_user).ToList();

            db = new gr691_baoEntities();
        }
    }
}
