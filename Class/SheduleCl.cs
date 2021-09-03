using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurTRPO
{
    public class SheduleCl
    {
        public bool AddS0No(int ship, int dep, int arr, int stat, string date, string dep_time, string arr_time)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                CurTRPO_Shedule curTRPO_Shedule = new CurTRPO_Shedule();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString()) || string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Shedule.User_Id = AuthCl.global_user;
                    curTRPO_Shedule.Ship_Id = ship;
                    curTRPO_Shedule.Departure_Point_Id = dep;
                    curTRPO_Shedule.Arrival_Point_Id = arr;
                    curTRPO_Shedule.Status_Id = stat;
                    curTRPO_Shedule.date = conv_date;
                    curTRPO_Shedule.departure_time = TimeSpan.Parse(dep_time);
                    curTRPO_Shedule.arrival_time = TimeSpan.Parse(arr_time);

                    db.CurTRPO_Shedule.Add(curTRPO_Shedule);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool AddS1No(int ship, int dep, int first, int arr, int stat, string date, string dep_time, string arr_time)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                CurTRPO_Shedule curTRPO_Shedule = new CurTRPO_Shedule();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString()) || string.IsNullOrWhiteSpace(first.ToString()) || string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(first.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Shedule.User_Id = AuthCl.global_user;
                    curTRPO_Shedule.Ship_Id = ship;
                    curTRPO_Shedule.Departure_Point_Id = dep;
                    curTRPO_Shedule.First_Stop_Id = first;
                    curTRPO_Shedule.Arrival_Point_Id = arr;
                    curTRPO_Shedule.Status_Id = stat;
                    curTRPO_Shedule.date = conv_date;
                    curTRPO_Shedule.departure_time = TimeSpan.Parse(dep_time);
                    curTRPO_Shedule.arrival_time = TimeSpan.Parse(arr_time);

                    db.CurTRPO_Shedule.Add(curTRPO_Shedule);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool AddS2No(int ship, int dep, int first, int second, int arr, int stat, string date, string dep_time, string arr_time)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                CurTRPO_Shedule curTRPO_Shedule = new CurTRPO_Shedule();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString()) || string.IsNullOrWhiteSpace(first.ToString()) || string.IsNullOrWhiteSpace(second.ToString()) || string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(first.ToString()) || checkCl.Num_Check(second.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Shedule.User_Id = AuthCl.global_user;
                    curTRPO_Shedule.Ship_Id = ship;
                    curTRPO_Shedule.Departure_Point_Id = dep;
                    curTRPO_Shedule.First_Stop_Id = first;
                    curTRPO_Shedule.Second_Stop_Id = second;
                    curTRPO_Shedule.Arrival_Point_Id = arr;
                    curTRPO_Shedule.Status_Id = stat;
                    curTRPO_Shedule.date = conv_date;
                    curTRPO_Shedule.departure_time = TimeSpan.Parse(dep_time);
                    curTRPO_Shedule.arrival_time = TimeSpan.Parse(arr_time);

                    db.CurTRPO_Shedule.Add(curTRPO_Shedule);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool AddS0Yes(int ship, int dep, int arr, int stat, string date, string dep_time, string arr_time, string price, string tickets)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                CurTRPO_Shedule curTRPO_Shedule = new CurTRPO_Shedule();

                var seats = db.CurTRPO_Ships.Where(i => i.Id == ship).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString())|| string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time)
                 || string.IsNullOrWhiteSpace(price.ToString()) || string.IsNullOrWhiteSpace(tickets))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (Convert.ToInt32(tickets) > Convert.ToInt32(seats.number_of_seats))
                {
                    MessageBox.Show("Вы не можете указать количество билетов больше, чем количество посадочных мест на судне", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)
                       || checkCl.Num_Check(price.ToString()) || checkCl.Num_Check(tickets)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Shedule.User_Id = AuthCl.global_user;
                    curTRPO_Shedule.Ship_Id = ship;
                    curTRPO_Shedule.Departure_Point_Id = dep;
                    curTRPO_Shedule.Arrival_Point_Id = arr;
                    curTRPO_Shedule.Status_Id = stat;
                    curTRPO_Shedule.date = conv_date;
                    curTRPO_Shedule.departure_time = TimeSpan.Parse(dep_time);
                    curTRPO_Shedule.arrival_time = TimeSpan.Parse(arr_time);
                    curTRPO_Shedule.price = Convert.ToDecimal(price);
                    curTRPO_Shedule.total_number_of_tickets = tickets;

                    db.CurTRPO_Shedule.Add(curTRPO_Shedule);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool AddS1Yes(int ship, int dep, int first, int arr, int stat, string date, string dep_time, string arr_time, string price, string tickets)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                CurTRPO_Shedule curTRPO_Shedule = new CurTRPO_Shedule();

                var seats = db.CurTRPO_Ships.Where(i => i.Id == ship).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString()) || string.IsNullOrWhiteSpace(first.ToString())  || string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time)
                 || string.IsNullOrWhiteSpace(price.ToString()) || string.IsNullOrWhiteSpace(tickets))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (Convert.ToInt32(tickets) > Convert.ToInt32(seats.number_of_seats))
                {
                    MessageBox.Show("Вы не можете указать количество билетов больше, чем количество посадочных мест на судне", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(first.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)
                       || checkCl.Num_Check(price.ToString()) || checkCl.Num_Check(tickets)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Shedule.User_Id = AuthCl.global_user;
                    curTRPO_Shedule.Ship_Id = ship;
                    curTRPO_Shedule.Departure_Point_Id = dep;
                    curTRPO_Shedule.First_Stop_Id = first;
                    curTRPO_Shedule.Arrival_Point_Id = arr;
                    curTRPO_Shedule.Status_Id = stat;
                    curTRPO_Shedule.date = conv_date;
                    curTRPO_Shedule.departure_time = TimeSpan.Parse(dep_time);
                    curTRPO_Shedule.arrival_time = TimeSpan.Parse(arr_time);
                    curTRPO_Shedule.price = Convert.ToDecimal(price);
                    curTRPO_Shedule.total_number_of_tickets = tickets;

                    db.CurTRPO_Shedule.Add(curTRPO_Shedule);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool AddS2Yes(int ship, int dep, int first, int second, int arr, int stat, string date, string dep_time, string arr_time, string price, string tickets)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                CurTRPO_Shedule curTRPO_Shedule = new CurTRPO_Shedule();

                var seats = db.CurTRPO_Ships.Where(i => i.Id == ship).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString()) || string.IsNullOrWhiteSpace(first.ToString()) || string.IsNullOrWhiteSpace(second.ToString()) || string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time)
                 || string.IsNullOrWhiteSpace(price.ToString()) || string.IsNullOrWhiteSpace(tickets))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (Convert.ToInt32(tickets) > Convert.ToInt32(seats.number_of_seats))
                {
                    MessageBox.Show("Вы не можете указать количество билетов больше, чем количество посадочных мест на судне", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(first.ToString()) || checkCl.Num_Check(second.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)
                       || checkCl.Num_Check(price.ToString()) || checkCl.Num_Check(tickets)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Shedule.User_Id = AuthCl.global_user;
                    curTRPO_Shedule.Ship_Id = ship;
                    curTRPO_Shedule.Departure_Point_Id = dep;
                    curTRPO_Shedule.First_Stop_Id = first;
                    curTRPO_Shedule.Second_Stop_Id = second;
                    curTRPO_Shedule.Arrival_Point_Id = arr;
                    curTRPO_Shedule.Status_Id = stat;
                    curTRPO_Shedule.date = conv_date;
                    curTRPO_Shedule.departure_time = TimeSpan.Parse(dep_time);
                    curTRPO_Shedule.arrival_time = TimeSpan.Parse(arr_time);
                    curTRPO_Shedule.price = Convert.ToDecimal(price);
                    curTRPO_Shedule.total_number_of_tickets = tickets;

                    db.CurTRPO_Shedule.Add(curTRPO_Shedule);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Delete(string id)
        {
            gr691_baoEntities db = new gr691_baoEntities();

            try
            {
                int num = Convert.ToInt32(id);
                var d_s = db.CurTRPO_Shedule.Where(i => i.Id == num).FirstOrDefault();
                if (d_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.CurTRPO_Shedule.Remove(d_s);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Нельзя удалить поездку, которая привязана к клиенту.\nОчистите клиентов.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool UpdateS0No(string id, int ship, int dep, int arr, int stat, string date, string dep_time, string arr_time)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Shedule.Where(u => u.Id == num).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString()) || string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_s.User_Id = AuthCl.global_user;
                    u_s.Ship_Id = ship;
                    u_s.Departure_Point_Id = dep;
                    u_s.First_Stop_Id = null;
                    u_s.Second_Stop_Id = null;
                    u_s.Arrival_Point_Id = arr;
                    u_s.Status_Id = stat;
                    u_s.date = conv_date;
                    u_s.departure_time = TimeSpan.Parse(dep_time);
                    u_s.arrival_time = TimeSpan.Parse(arr_time);
                    u_s.price = null;
                    u_s.total_number_of_tickets = null;

                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool UpdateS1No(string id, int ship, int dep, int first, int arr, int stat, string date, string dep_time, string arr_time)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Shedule.Where(u => u.Id == num).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString()) || string.IsNullOrWhiteSpace(first.ToString()) || string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(first.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_s.User_Id = AuthCl.global_user;
                    u_s.Ship_Id = ship;
                    u_s.Departure_Point_Id = dep;
                    u_s.First_Stop_Id = first;
                    u_s.Second_Stop_Id = null;
                    u_s.Arrival_Point_Id = arr;
                    u_s.Status_Id = stat;
                    u_s.date = conv_date;
                    u_s.departure_time = TimeSpan.Parse(dep_time);
                    u_s.arrival_time = TimeSpan.Parse(arr_time);
                    u_s.price = null;
                    u_s.total_number_of_tickets = null;

                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool UpdateS2No(string id, int ship, int dep, int first, int second, int arr, int stat, string date, string dep_time, string arr_time)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Shedule.Where(u => u.Id == num).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString()) || string.IsNullOrWhiteSpace(first.ToString()) || string.IsNullOrWhiteSpace(second.ToString()) || string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(first.ToString()) || checkCl.Num_Check(second.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_s.User_Id = AuthCl.global_user;
                    u_s.Ship_Id = ship;
                    u_s.Departure_Point_Id = dep;
                    u_s.First_Stop_Id = first;
                    u_s.Second_Stop_Id = second;
                    u_s.Arrival_Point_Id = arr;
                    u_s.Status_Id = stat;
                    u_s.date = conv_date;
                    u_s.departure_time = TimeSpan.Parse(dep_time);
                    u_s.arrival_time = TimeSpan.Parse(arr_time);
                    u_s.price = null;
                    u_s.total_number_of_tickets = null;

                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool UpdateS0Yes(string id, int ship, int dep, int arr, int stat, string date, string dep_time, string arr_time, string price, string tickets)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Shedule.Where(u => u.Id == num).FirstOrDefault();

                var seats = db.CurTRPO_Ships.Where(i => i.Id == ship).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString()) || string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time)
                 || string.IsNullOrWhiteSpace(price.ToString()) || string.IsNullOrWhiteSpace(tickets))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (Convert.ToInt32(tickets) > Convert.ToInt32(seats.number_of_seats))
                {
                    MessageBox.Show("Вы не можете указать количество билетов больше, чем количество посадочных мест на судне", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)
                       || checkCl.Num_Check(price.ToString()) || checkCl.Num_Check(tickets)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_s.User_Id = AuthCl.global_user;
                    u_s.Ship_Id = ship;
                    u_s.Departure_Point_Id = dep;
                    u_s.First_Stop_Id = null;
                    u_s.Second_Stop_Id = null;
                    u_s.Arrival_Point_Id = arr;
                    u_s.Status_Id = stat;
                    u_s.date = conv_date;
                    u_s.departure_time = TimeSpan.Parse(dep_time);
                    u_s.arrival_time = TimeSpan.Parse(arr_time);
                    u_s.price = Convert.ToDecimal(price);
                    u_s.total_number_of_tickets = tickets;



                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool UpdateS1Yes(string id, int ship, int dep, int first, int arr, int stat, string date, string dep_time, string arr_time, string price, string tickets)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Shedule.Where(u => u.Id == num).FirstOrDefault();

                var seats = db.CurTRPO_Ships.Where(i => i.Id == ship).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString()) || string.IsNullOrWhiteSpace(first.ToString()) || string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time)
                 || string.IsNullOrWhiteSpace(price.ToString()) || string.IsNullOrWhiteSpace(tickets))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (Convert.ToInt32(tickets) > Convert.ToInt32(seats.number_of_seats))
                {
                    MessageBox.Show("Вы не можете указать количество билетов больше, чем количество посадочных мест на судне", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(first.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)
                       || checkCl.Num_Check(price.ToString()) || checkCl.Num_Check(tickets)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_s.User_Id = AuthCl.global_user;
                    u_s.Ship_Id = ship;
                    u_s.Departure_Point_Id = dep;
                    u_s.First_Stop_Id = first;
                    u_s.Second_Stop_Id = null;
                    u_s.Arrival_Point_Id = arr;
                    u_s.Status_Id = stat;
                    u_s.date = conv_date;
                    u_s.departure_time = TimeSpan.Parse(dep_time);
                    u_s.arrival_time = TimeSpan.Parse(arr_time);
                    u_s.price = Convert.ToDecimal(price);
                    u_s.total_number_of_tickets = tickets;



                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool UpdateS2Yes(string id, int ship, int dep, int first, int second, int arr, int stat, string date, string dep_time, string arr_time, string price, string tickets)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Shedule.Where(u => u.Id == num).FirstOrDefault();

                var seats = db.CurTRPO_Ships.Where(i => i.Id == ship).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(ship.ToString()) || string.IsNullOrWhiteSpace(dep.ToString()) || string.IsNullOrWhiteSpace(first.ToString()) || string.IsNullOrWhiteSpace(second.ToString()) || string.IsNullOrWhiteSpace(arr.ToString())
                 || string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(dep_time) || string.IsNullOrWhiteSpace(arr_time)
                 || string.IsNullOrWhiteSpace(price.ToString()) || string.IsNullOrWhiteSpace(tickets))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (DateTime.TryParse(date, out DateTime conv_date) == false)
                {
                    MessageBox.Show("Дата не соответствует шаблону", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (Convert.ToInt32(tickets) > Convert.ToInt32(seats.number_of_seats))
                {
                    MessageBox.Show("Вы не можете указать количество билетов больше, чем количество посадочных мест на судне", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(ship.ToString()) || checkCl.Num_Check(dep.ToString()) || checkCl.Num_Check(first.ToString()) || checkCl.Num_Check(second.ToString()) || checkCl.Num_Check(arr.ToString())
                       || checkCl.Num_Check(stat.ToString()) || checkCl.Coord_Check(date) || checkCl.Time_Check(dep_time) || checkCl.Time_Check(arr_time)
                       || checkCl.Num_Check(price.ToString()) || checkCl.Num_Check(tickets)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_s.User_Id = AuthCl.global_user;
                    u_s.Ship_Id = ship;
                    u_s.Departure_Point_Id = dep;
                    u_s.First_Stop_Id = first;
                    u_s.Second_Stop_Id = second;
                    u_s.Arrival_Point_Id = arr;
                    u_s.Status_Id = stat;
                    u_s.date = conv_date;
                    u_s.departure_time = TimeSpan.Parse(dep_time);
                    u_s.arrival_time = TimeSpan.Parse(arr_time);
                    u_s.price = Convert.ToDecimal(price);
                    u_s.total_number_of_tickets = tickets;

                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update1Disp(string id, int stat)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Shedule.Where(u => u.Id == num).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(stat.ToString()))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (checkCl.Num_Check(stat.ToString()) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_s.User_Id = AuthCl.global_user;
                    u_s.Status_Id = stat;

                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update2Disp(string id, string arr_time)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Shedule.Where(u => u.Id == num).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(arr_time))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_s.User_Id = AuthCl.global_user;
                    u_s.arrival_time = TimeSpan.Parse(arr_time);

                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update3Disp(string id, int stat, string arr_time)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Shedule.Where(u => u.Id == num).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(stat.ToString()) || string.IsNullOrWhiteSpace(arr_time))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(stat.ToString()) || checkCl.Time_Check(arr_time)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_s.User_Id = AuthCl.global_user;
                    u_s.Status_Id = stat;
                    u_s.arrival_time = TimeSpan.Parse(arr_time);

                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
