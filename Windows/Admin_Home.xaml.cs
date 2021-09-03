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
    /// Логика взаимодействия для Admin_Home.xaml
    /// </summary>
    public partial class Admin_Home : Window
    {
        gr691_baoEntities db;
        public Admin_Home()
        {
            InitializeComponent();

            Shed_CountStop_Cb.SelectedIndex = 0;
            Shed_Ticket_Cb.SelectedIndex = 0;
            Start_Cb.SelectedItem = UserText;

            Shed_CountStop_Cb.Items.Add("Без остановок");
            Shed_CountStop_Cb.Items.Add("Одна остановка");
            Shed_CountStop_Cb.Items.Add("Две остановки");
            Shed_Ticket_Cb.Items.Add("Билетов нет");
            Shed_Ticket_Cb.Items.Add("Билеты есть");

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
                if (Shed_search.Text == "")
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
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Ports.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Ports1.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Ports2.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Ports3.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.CurTRPO_Status.name.Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.departure_time.ToString().Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.arrival_time.ToString().Contains(SS)
                                          || w.date == Shed_date.SelectedDate && w.price.ToString().Contains(SS)
                                          ).ToList();
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
                                          || w.CurTRPO_Ports.name.Contains(SS)
                                          || w.CurTRPO_Ports1.name.Contains(SS)
                                          || w.CurTRPO_Ports2.name.Contains(SS)
                                          || w.CurTRPO_Ports3.name.Contains(SS)
                                          || w.CurTRPO_Status.name.Contains(SS)
                                          || w.departure_time.ToString().Contains(SS)
                                          || w.arrival_time.ToString().Contains(SS)
                                          || w.price.ToString().Contains(SS)
                                          ).ToList();
                }
            }
        }
        private void Shed_CountStop_Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string choice = (Shed_CountStop_Cb.SelectedValue.ToString());
            if (choice == "Без остановок")
            {
                Shed_FirStop_Cb.Visibility = Visibility.Collapsed;
                Shed_SecStop_Cb.Visibility = Visibility.Collapsed;
                Shed_Size.Height = 448;
            }
            else if (choice == "Одна остановка")
            {
                Shed_FirStop_Cb.Visibility = Visibility.Visible;
                Shed_SecStop_Cb.Visibility = Visibility.Collapsed;
                Shed_Size.Height = 483;
            }
            else if (choice == "Две остановки")
            {
                Shed_FirStop_Cb.Visibility = Visibility.Visible;
                Shed_SecStop_Cb.Visibility = Visibility.Visible;
                Shed_Size.Height = 518;
            }
        }
        private void Shed_Ticket_Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string choice = (Shed_Ticket_Cb.SelectedValue.ToString());
            if (choice == "Билетов нет")
            {
                Shed_Tickets.Visibility = Visibility.Collapsed;
                Shed_Price.Visibility = Visibility.Collapsed;
            }
            else if (choice == "Билеты есть")
            {
                Shed_Tickets.Visibility = Visibility.Visible;
                Shed_Price.Visibility = Visibility.Visible;
            }
        }
        private void Shed_Add(object sender, RoutedEventArgs e)
        {
            SheduleCl shedule = new SheduleCl();
            string stop = (Shed_CountStop_Cb.SelectedValue.ToString());
            string tick = (Shed_Ticket_Cb.SelectedValue.ToString());

            if (Shed_Ship_Cb.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали судно.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (Shed_DepPoint_Cb.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали точку отбытия.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (Shed_ArrPoint_Cb.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали точку прибытия.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (stop == "Без остановок" && tick == "Билетов нет")
            {
                if (shedule.AddS0No((Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id,
                                    (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                     Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
            else if (stop == "Одна остановка" && tick == "Билетов нет")
            {
                if (Shed_FirStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку первой остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (shedule.AddS1No((Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_FirStop_Cb.SelectedItem as CurTRPO_Ports).Id,
                                         (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                          Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_FirStop_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
            else if (stop == "Две остановки" && tick == "Билетов нет")
            {
                if (Shed_FirStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку первой остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (Shed_SecStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку второй остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (shedule.AddS2No((Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_FirStop_Cb.SelectedItem as CurTRPO_Ports).Id,
                                         (Shed_SecStop_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                          Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_FirStop_Cb.SelectedIndex = -1;
                    Shed_SecStop_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
            else if (stop == "Без остановок" && tick == "Билеты есть")
            {
                if (shedule.AddS0Yes((Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id,
                                     (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                      Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text, Shed_Price.Text, Shed_Tickets.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    Shed_Price.Clear();
                    Shed_Tickets.Clear();
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
            else if (stop == "Одна остановка" && tick == "Билеты есть")
            {
                if (Shed_FirStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку первой остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (shedule.AddS1Yes((Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_FirStop_Cb.SelectedItem as CurTRPO_Ports).Id,
                                         (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                          Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text, Shed_Price.Text, Shed_Tickets.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_FirStop_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    Shed_Price.Clear();
                    Shed_Tickets.Clear();
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
            else if (stop == "Две остановки" && tick == "Билеты есть")
            {
                if (Shed_FirStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку первой остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (Shed_SecStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку второй остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (shedule.AddS2Yes((Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_FirStop_Cb.SelectedItem as CurTRPO_Ports).Id,
                                         (Shed_SecStop_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                          Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text, Shed_Price.Text, Shed_Tickets.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_FirStop_Cb.SelectedIndex = -1;
                    Shed_SecStop_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    Shed_Price.Clear();
                    Shed_Tickets.Clear();
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
        }

        private void Shed_Update(object sender, RoutedEventArgs e)
        {
            SheduleCl shedule = new SheduleCl();
            db = new gr691_baoEntities();
            string stop = (Shed_CountStop_Cb.SelectedValue.ToString());
            string tick = (Shed_Ticket_Cb.SelectedValue.ToString());
            CurTRPO_Shedule curTRPO_Shedule = ShedGrid.SelectedItem as CurTRPO_Shedule;

            if (ShedGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Суда", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Shedule.Where(i => i.Id == curTRPO_Shedule.Id).FirstOrDefault();
            if (Shed_Ship_Cb.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали судно.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (Shed_DepPoint_Cb.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали точку отбытия.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (Shed_ArrPoint_Cb.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали точку прибытия.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (stop == "Без остановок" && tick == "Билетов нет")
            {
                if (shedule.UpdateS0No(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0", 
                                    (Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id,
                                    (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                     Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
            else if (stop == "Одна остановка" && tick == "Билетов нет")
            {
                if (Shed_FirStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку первой остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (shedule.UpdateS1No(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0", 
                                         (Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_FirStop_Cb.SelectedItem as CurTRPO_Ports).Id,
                                         (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                          Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_FirStop_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
            else if (stop == "Две остановки" && tick == "Билетов нет")
            {
                if (Shed_FirStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку первой остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (Shed_SecStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку второй остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (shedule.UpdateS2No(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0", 
                                         (Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_FirStop_Cb.SelectedItem as CurTRPO_Ports).Id,
                                         (Shed_SecStop_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                          Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_FirStop_Cb.SelectedIndex = -1;
                    Shed_SecStop_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
            else if (stop == "Без остановок" && tick == "Билеты есть")
            {
                if (shedule.UpdateS0Yes(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0", 
                                     (Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id,
                                     (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                      Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text, Shed_Price.Text, Shed_Tickets.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    Shed_Price.Clear();
                    Shed_Tickets.Clear();
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
            else if (stop == "Одна остановка" && tick == "Билеты есть")
            {
                if (Shed_FirStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку первой остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (shedule.UpdateS1Yes(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0", 
                                         (Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_FirStop_Cb.SelectedItem as CurTRPO_Ports).Id,
                                         (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                          Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text, Shed_Price.Text, Shed_Tickets.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_FirStop_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    Shed_Price.Clear();
                    Shed_Tickets.Clear();
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
            else if (stop == "Две остановки" && tick == "Билеты есть")
            {
                if (Shed_FirStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку первой остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (Shed_SecStop_Cb.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали точку второй остановки.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (shedule.UpdateS2Yes(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0", (Shed_Ship_Cb.SelectedItem as CurTRPO_Ships).Id, (Shed_DepPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_FirStop_Cb.SelectedItem as CurTRPO_Ports).Id,
                                         (Shed_SecStop_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_ArrPoint_Cb.SelectedItem as CurTRPO_Ports).Id, (Shed_Status_Cb.SelectedItem as CurTRPO_Status).Id,
                                          Shed_date.SelectedDate.ToString(), Shed_DepTime.Text, Shed_ArrTime.Text, Shed_Price.Text, Shed_Tickets.Text) == true)
                {
                    Shed_Ship_Cb.SelectedIndex = -1;
                    Shed_DepPoint_Cb.SelectedIndex = -1;
                    Shed_FirStop_Cb.SelectedIndex = -1;
                    Shed_SecStop_Cb.SelectedIndex = -1;
                    Shed_ArrPoint_Cb.SelectedIndex = -1;
                    Shed_Status_Cb.SelectedIndex = -1;
                    Shed_date.SelectedDate = null;
                    Shed_DepTime.SelectedTime = null;
                    Shed_ArrTime.SelectedTime = null;
                    Shed_Price.Clear();
                    Shed_Tickets.Clear();
                    db = new gr691_baoEntities();
                    ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
                }
            }
        }

        private void Shed_Delete(object sender, RoutedEventArgs e)
        {
            SheduleCl shedule = new SheduleCl();
            CurTRPO_Shedule curTRPO_Shedule = ShedGrid.SelectedItem as CurTRPO_Shedule;

            if (ShedGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Суда", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Shedule.Where(i => i.Id == curTRPO_Shedule.Id).FirstOrDefault();
            shedule.Delete(curTRPO_Shedule != null ? curTRPO_Shedule.Id.ToString() : "0");
            db = new gr691_baoEntities();
            ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();
        }
        private void Status_Window(object sender, RoutedEventArgs e)
        {
            new Status().ShowDialog();
            Shed_Status_Cb.ItemsSource = db.CurTRPO_Status.ToList();
        }
        //Вкладка расписание (конец)

        // Вкладка суда (начало)
        private void Ship_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string SS = Port_search.Text;

            if (SS == "")
            {
                ShipGrid.ItemsSource = db.CurTRPO_Ships.ToList();
                db = new gr691_baoEntities();
                return;
            }
            else
            {
                ShipGrid.ItemsSource = db.CurTRPO_Ships.Where(w => w.name.Contains(SS)
                                                              || w.number_of_seats.Contains(SS)
                                                              || w.CurTRPO_Ship_Type.name.Contains(SS)
                                                             ).ToList();
            }
        }
        private void Ship_Type_Window(object sender, RoutedEventArgs e)
        {
            new Ship_Type().ShowDialog();
            Ship_Type_Cb.ItemsSource = db.CurTRPO_Ship_Type.ToList();
        }

        private void Ship_Add(object sender, RoutedEventArgs e)
        {
            ShipCl ship = new ShipCl();
            if (ship.Add(Ship_Name.Text, Ship_NOS.Text, (Ship_Type_Cb.SelectedItem as CurTRPO_Ship_Type).Id) == true)
            {
                Ship_Type_Cb.SelectedIndex = -1;
                Ship_Name.Clear();
                Ship_NOS.Clear();
                db = new gr691_baoEntities();
                ShipGrid.ItemsSource = db.CurTRPO_Ships.ToList();
                Shed_Ship_Cb.ItemsSource = db.CurTRPO_Ships.ToList();
            }
        }

        private void Ship_Update(object sender, RoutedEventArgs e)
        {
            ShipCl ship = new ShipCl();
            db = new gr691_baoEntities();
            CurTRPO_Ships curTRPO_Ships = ShipGrid.SelectedItem as CurTRPO_Ships;

            if (ShipGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Суда", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Ships.Where(i => i.Id == curTRPO_Ships.Id).FirstOrDefault();
            if (ship.Update(curTRPO_Ships != null ? curTRPO_Ships.Id.ToString() : "0", Ship_Name.Text, Ship_NOS.Text, (Ship_Type_Cb.SelectedItem as CurTRPO_Ship_Type).Id) == true)
            {
                Ship_Type_Cb.SelectedIndex = -1;
                Ship_Name.Clear();
                Ship_NOS.Clear();
                db = new gr691_baoEntities();
                ShipGrid.ItemsSource = db.CurTRPO_Ships.ToList();
                Shed_Ship_Cb.ItemsSource = db.CurTRPO_Ships.ToList();
            }
        }

        private void Ship_Delete(object sender, RoutedEventArgs e)
        {
            ShipCl ship = new ShipCl();
            CurTRPO_Ships curTRPO_Ships = ShipGrid.SelectedItem as CurTRPO_Ships;

            if (ShipGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Суда", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Ships.Where(i => i.Id == curTRPO_Ships.Id).FirstOrDefault();
            ship.Delete(curTRPO_Ships != null ? curTRPO_Ships.Id.ToString() : "0");
            db = new gr691_baoEntities();
            ShipGrid.ItemsSource = db.CurTRPO_Ships.ToList();
            Shed_Ship_Cb.ItemsSource = db.CurTRPO_Ships.ToList();
        }
        // Вкладка суда (конец)

        //Вкладка порты (начало)
        private void Port_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string PS = Port_search.Text;

            if (PS == "")
            {
                PortGrid.ItemsSource = db.CurTRPO_Ports.ToList();
                db = new gr691_baoEntities();
                return;
            }
            else
            {
                PortGrid.ItemsSource = db.CurTRPO_Ports.Where(w => w.name.Contains(PS)
                                                              || w.address.Contains(PS)
                                                              || w.phone_number.Contains(PS)
                                                              || w.latitude.Contains(PS)
                                                              || w.longitude.Contains(PS)
                                                             ).ToList();
            }
        }
        private void Port_Add(object sender, RoutedEventArgs e)
        {
            PortCl port = new PortCl();
            if (port.Add(Port_Name.Text, Port_Address.Text, Port_Phone.Text, Port_latitude.Text, Port_longitude.Text) == true)
            {
                Port_Name.Clear();
                Port_Address.Clear();
                Port_Phone.Clear();
                Port_latitude.Clear();
                Port_longitude.Clear();
                db = new gr691_baoEntities();
                PortGrid.ItemsSource = db.CurTRPO_Ports.ToList();
                Shed_DepPoint_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
                Shed_FirStop_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
                Shed_SecStop_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
                Shed_ArrPoint_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
            }
        }
        private void Port_Update(object sender, RoutedEventArgs e)
        {
            PortCl port = new PortCl();
            db = new gr691_baoEntities();
            CurTRPO_Ports curTRPO_Ports = PortGrid.SelectedItem as CurTRPO_Ports;

            if (PortGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Ports.Where(i => i.Id == curTRPO_Ports.Id).FirstOrDefault();
            if (port.Update(curTRPO_Ports != null ? curTRPO_Ports.Id.ToString() : "0", Port_Name.Text, Port_Address.Text, Port_Phone.Text, Port_latitude.Text, Port_longitude.Text) == true)
            {
                Port_Name.Clear();
                Port_Address.Clear();
                Port_Phone.Clear();
                Port_latitude.Clear();
                Port_longitude.Clear();
                db = new gr691_baoEntities();
                PortGrid.ItemsSource = db.CurTRPO_Ports.ToList();
                Shed_DepPoint_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
                Shed_FirStop_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
                Shed_SecStop_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
                Shed_ArrPoint_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
            }
        }
        private void Port_Delete(object sender, RoutedEventArgs e)
        {
            PortCl port = new PortCl();
            CurTRPO_Ports curTRPO_Ports = PortGrid.SelectedItem as CurTRPO_Ports;

            if (PortGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Ports.Where(i => i.Id == curTRPO_Ports.Id).FirstOrDefault();
            port.Delete(curTRPO_Ports != null ? curTRPO_Ports.Id.ToString() : "0");
            db = new gr691_baoEntities();
            PortGrid.ItemsSource = db.CurTRPO_Ports.ToList();
            Shed_DepPoint_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
            Shed_FirStop_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
            Shed_SecStop_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
            Shed_ArrPoint_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
        }
        //Вкладка порты (конец)

        //Вкладка пользователи (начало)
        private void User_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string US = User_search.Text;

            if (US == "")
            {
                UserGrid.ItemsSource = db.CurTRPO_Users.ToList();
                db = new gr691_baoEntities();
                return;
            }
            else
            {
                UserGrid.ItemsSource = db.CurTRPO_Users.Where(w => w.CurTRPO_Accounts.CurTRPO_Role.name.Contains(US)
                                                              || w.last_name.Contains(US)
                                                              || w.first_name.Contains(US)
                                                              || w.middle_name.Contains(US)
                                                              || w.phone_number.Contains(US)
                                                              || w.CurTRPO_Accounts.login.Contains(US)
                                                             ).ToList();
            }
        }
        private void User_Add(object sender, RoutedEventArgs e)
        {
            UserCl UserAcc = new UserCl();
            if (UserAcc.Add(User_Last.Text, User_First.Text, User_Middle.Text, User_Phone.Text, User_Login.Text, User_Password.Password, (User_Role_Cb.SelectedItem as CurTRPO_Role).Id) == true)
            {
                User_Role_Cb.SelectedIndex = -1;
                User_Last.Clear();
                User_Middle.Clear();
                User_First.Clear();
                User_Password.Clear();
                User_Login.Clear();
                User_Password.Clear();
                gr691_baoEntities db = new gr691_baoEntities();
                UserGrid.ItemsSource = db.CurTRPO_Users.ToList();
            }
        }
        private void User_Delete(object sender, RoutedEventArgs e)
        {
            UserCl UserAcc = new UserCl();
            CurTRPO_Users curTRPO_Users = UserGrid.SelectedItem as CurTRPO_Users;
            CurTRPO_Accounts curTRPO_Accounts = new CurTRPO_Accounts();
            db = new gr691_baoEntities();

            if (UserGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Пользователи", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.CurTRPO_Users.Where(i => i.Id == curTRPO_Users.Id).FirstOrDefault();
            UserAcc.Delete(curTRPO_Users != null ? curTRPO_Users.Acc_Id.ToString() : "0");
            UserGrid.ItemsSource = db.CurTRPO_Users.ToList();
        }
        //Вкладка пользователи (конец)

        //Угловой комбобокс (начало)
        private void Disp_Window(object sender, RoutedEventArgs e)
        {
            new Disp_Home().ShowDialog();
        }
        private void Client_Window(object sender, RoutedEventArgs e)
        {
            new Client_Home().ShowDialog();
        }
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

            Shed_Ship_Cb.ItemsSource = db.CurTRPO_Ships.ToList();
            Shed_DepPoint_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
            Shed_FirStop_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
            Shed_SecStop_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
            Shed_ArrPoint_Cb.ItemsSource = db.CurTRPO_Ports.ToList();
            Shed_Status_Cb.ItemsSource = db.CurTRPO_Status.ToList();
            ShedGrid.ItemsSource = db.CurTRPO_Shedule.ToList();

            Ship_Type_Cb.ItemsSource = db.CurTRPO_Ship_Type.ToList();
            ShipGrid.ItemsSource = db.CurTRPO_Ships.ToList();

            PortGrid.ItemsSource = db.CurTRPO_Ports.ToList();

            User_Role_Cb.ItemsSource = db.CurTRPO_Role.Where(i => i.Id != 1).ToList();
            UserGrid.ItemsSource = db.CurTRPO_Users.ToList();

            db = new gr691_baoEntities();
        }
    }
}
