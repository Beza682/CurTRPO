using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurTRPO
{
    public class SaleCl
    {
        public bool Add(string sh, int user, string not)
        {
            CheckCl checkCl = new CheckCl();

            gr691_baoEntities db = new gr691_baoEntities();
            int num = Convert.ToInt32(sh);
            var shed = db.CurTRPO_Shedule.Where(i => i.Id == num).FirstOrDefault();
            try
            {
                CurTRPO_Trips curTRPO_Trips = new CurTRPO_Trips();

                if (string.IsNullOrWhiteSpace(user.ToString()) || string.IsNullOrWhiteSpace(not))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Поездки", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(user.ToString()) || checkCl.Num_Check(not)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Поездки", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                decimal total_pr = Convert.ToDecimal(shed.price) * Convert.ToInt32(not);
                int total_tick = Convert.ToInt32(shed.total_number_of_tickets) - Convert.ToInt32(not);
                if (Convert.ToInt32(shed.total_number_of_tickets) < Convert.ToInt32(not))
                {
                    MessageBox.Show("Количество покупаемых билетов: " + not +  ", превышает количество имеющихся билетов: " + shed.total_number_of_tickets + ".", "Поездки", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Trips.Shed_Id = shed.Id;
                    curTRPO_Trips.User_Id = user;
                    curTRPO_Trips.number_of_tickets = not;
                    curTRPO_Trips.total_price = total_pr;
                    shed.total_number_of_tickets = Convert.ToString(total_tick);
                    db.CurTRPO_Trips.Add(curTRPO_Trips);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool AddClient(string sh, string not)
        {
            CheckCl checkCl = new CheckCl();

            gr691_baoEntities db = new gr691_baoEntities();
            int num = Convert.ToInt32(sh);
            var shed = db.CurTRPO_Shedule.Where(i => i.Id == num).FirstOrDefault();
            try
            {
                CurTRPO_Trips curTRPO_Trips = new CurTRPO_Trips();

                if (string.IsNullOrWhiteSpace(not))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Поездки", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(not)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Поездки", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                decimal total_pr = Convert.ToDecimal(shed.price) * Convert.ToInt32(not);
                int total_tick = Convert.ToInt32(shed.total_number_of_tickets) - Convert.ToInt32(not);
                if (Convert.ToInt32(shed.total_number_of_tickets) < Convert.ToInt32(not))
                {
                    MessageBox.Show("Количество покупаемых билетов: " + not + ", превышает количество имеющихся билетов: " + shed.total_number_of_tickets + ".", "Поездки", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Trips.Shed_Id = shed.Id;
                    curTRPO_Trips.User_Id = AuthCl.global_user;
                    curTRPO_Trips.number_of_tickets = not;
                    curTRPO_Trips.total_price = total_pr;
                    shed.total_number_of_tickets = Convert.ToString(total_tick);
                    db.CurTRPO_Trips.Add(curTRPO_Trips);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_t = db.CurTRPO_Trips.Where(i => i.Id == num).FirstOrDefault();
                var shed = db.CurTRPO_Shedule.Where(i => i.Id == d_t.Shed_Id).FirstOrDefault();
                if (d_t == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Покупки", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    int total = Convert.ToInt32(shed.total_number_of_tickets) + Convert.ToInt32(d_t.number_of_tickets);
                    shed.total_number_of_tickets = Convert.ToString(total);
                    db.CurTRPO_Trips.Remove(d_t);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Покупки", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string not)
        {
            CheckCl checkCl = new CheckCl();

            gr691_baoEntities db = new gr691_baoEntities();
            int num = Convert.ToInt32(id);
            var u_t = db.CurTRPO_Trips.Where(i => i.Id == num).FirstOrDefault();
            var shed = db.CurTRPO_Shedule.Where(i => i.Id == u_t.Shed_Id).FirstOrDefault();

            try
            {
                CurTRPO_Trips curTRPO_Trips = new CurTRPO_Trips();

                if (string.IsNullOrWhiteSpace(not))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Покупки", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (checkCl.Num_Check(not) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Покупки", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                decimal total_pr = Convert.ToDecimal(u_t.total_price) / Convert.ToInt32(u_t.number_of_tickets) * Convert.ToInt32(not);
                int total_tick = Convert.ToInt32(shed.total_number_of_tickets) + Convert.ToInt32(u_t.number_of_tickets) - Convert.ToInt32(not);
                if (Convert.ToInt32(u_t.number_of_tickets) <= Convert.ToInt32(not))
                {
                    MessageBox.Show("Количество возвращаемых билетов: " + not + ", превышает или равняется количеству имеющихся у Вас билетов: " + u_t.number_of_tickets + ".", "Поездки", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (Convert.ToInt32(shed.total_number_of_tickets) <= Convert.ToInt32(not))
                {
                    MessageBox.Show("Количество приобретаемых билетов: " + not + ", не должно превышать количество имеющихся билетов: " + shed.total_number_of_tickets + ".", "Поездки", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_t.number_of_tickets = not;
                    u_t.total_price = total_pr;
                    shed.total_number_of_tickets = Convert.ToString(total_tick);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Покупки", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
