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
    /// Логика взаимодействия для Disp_Home.xaml
    /// </summary>
    public partial class Disp_Home : Window
    {
        gr691_baoEntities db;
        public Disp_Home()
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
        private void Shed_Update(object sender, RoutedEventArgs e)
        {
            SheduleCl shedule = new SheduleCl();
            db = new gr691_baoEntities();
            CurTRPO_Shedule curTRPO_Shedule = ShedGrid.SelectedItem as CurTRPO_Shedule;

            if (ShedGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Shedule.Where(i => i.Id == curTRPO_Shedule.Id).FirstOrDefault();
            if (Shed_Status_Cb.SelectedItem == null && Shed_ArrTime.SelectedTime == null)
            {
                MessageBox.Show("Вы не заполнили форму.", "Поездки", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (Shed_Status_Cb.SelectedItem != null && Shed_ArrTime.SelectedTime == null)
            {
                if (shedule.Update1Disp(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0", (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id) == true)
                {
                    Shed_Status_Cb.SelectedIndex = -1;
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                    SaleGrid.ItemsSource = db.CurTRPO_Trips.ToList();
                }
            }
            else if (Shed_Status_Cb.SelectedItem == null && Shed_ArrTime.SelectedTime != null)
            {
                if (shedule.Update2Disp(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0", Shed_ArrTime.Text) == true)
                {
                    Shed_ArrTime.SelectedTime = null;
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                    SaleGrid.ItemsSource = db.CurTRPO_Trips.ToList();
                }
            }
            else if (Shed_Status_Cb.SelectedItem != null && Shed_ArrTime.SelectedTime != null)
            {
                if (shedule.Update3Disp(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0", (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id, Shed_ArrTime.Text) == true)
                {
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_ArrTime.SelectedTime = null;
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                    SaleGrid.ItemsSource = db.CurTRPO_Trips.ToList();
                }
            }
        }
        private void Reg_Window(object sender, RoutedEventArgs e)
        {
            new Registration().ShowDialog();
            Shed_Client_Cb.ItemsSource = db.CurTRPO_Users.ToList();
            var us = db.CurTRPO_Users.Where(i => i.phone_number == RegCl.RegUs).FirstOrDefault();
            Shed_Client_Cb.SelectedItem = us;
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
            if (Shed_Client_Cb.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали клиента.", "Поездки", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Shedule.Where(i => i.Id == curTRPO_Shedule.Id).FirstOrDefault();
            if (sale.Add(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0", (Shed_Client_Cb.SelectedItem as CurTRPO_Users).Id, Shed_client_seats.Text) == true)
            {
                Shed_Client_Cb.SelectedIndex = -1;
                Shed_client_seats.Clear();
                db = new gr691_baoEntities();
                ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                SaleGrid.ItemsSource = db.CurTRPO_Trips.ToList();
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
        private void Sale_Update(object sender, RoutedEventArgs e)
        {
            SaleCl sale = new SaleCl();
            CurTRPO_Trips curTRPO_Trips = SaleGrid.SelectedItem as CurTRPO_Trips;

            if (SaleGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Покупки", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Trips.Where(i => i.Id == curTRPO_Trips.Id).FirstOrDefault();
            if (sale.Update(curTRPO_Trips != null ? curTRPO_Trips.Id.ToString() : "0", Sale_client_seats.Text) == true)
            {
                Sale_client_seats.Clear();
                db = new gr691_baoEntities();
                ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                SaleGrid.ItemsSource = db.CurTRPO_Trips.ToList();
            }
        }

        private void Sale_Delete(object sender, RoutedEventArgs e)
        {
            SaleCl sale = new SaleCl();
            CurTRPO_Trips curTRPO_Trips = SaleGrid.SelectedItem as CurTRPO_Trips;

            if (SaleGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Покупки", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Trips.Where(i => i.Id == curTRPO_Trips.Id).FirstOrDefault();
            sale.Delete(curTRPO_Trips != null ? curTRPO_Trips.Id.ToString() : "0");
            db = new gr691_baoEntities();
            ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
            SaleGrid.ItemsSource = db.CurTRPO_Trips.ToList();
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

            Shed_Client_Cb.ItemsSource = db.CurTRPO_Users.Where(i => i.CurTRPO_Accounts.CurTRPO_Role.Id == 3).ToList();
            Shed_Status_Cb.ItemsSource = db.CurTRPO_Status.ToList();
            ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();

            SaleGrid.ItemsSource = db.CurTRPO_Trips.ToList();

            db = new gr691_baoEntities();
        }
    }
}
