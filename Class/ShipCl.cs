using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurTRPO
{
    public class ShipCl
    {
        public bool Add(string name, string nos, int type)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                CurTRPO_Ships curTRPO_Ships = new CurTRPO_Ships();

                var name_check = db.CurTRPO_Ships.FirstOrDefault(ch => ch.name == name);

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type.ToString()))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Cуда", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Ship_Check(name) || checkCl.Num_Check(type.ToString())) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Cуда", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (name_check != null)
                {
                    MessageBox.Show("Данное судно уже существует.", "Cуда", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Ships.name = name;
                    curTRPO_Ships.number_of_seats = nos;
                    curTRPO_Ships.Ship_Type_Id = type;
                    db.CurTRPO_Ships.Add(curTRPO_Ships);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Cуда", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_s = db.CurTRPO_Ships.Where(i => i.Id == num).FirstOrDefault();
                if (d_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Cуда", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.CurTRPO_Ships.Remove(d_s);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Нельзя удалить судно, которое привязан к расписанию .\nОчистите расписание.", "Cуда", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string name, string nos, int type)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Ships.Where(u => u.Id == num).FirstOrDefault();
                var name_check = db.CurTRPO_Ships.FirstOrDefault(ch => ch.name == name);

                if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type.ToString()))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Cуда", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(id.ToString()) || checkCl.Ship_Check(name) || checkCl.Num_Check(type.ToString())) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Cуда", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (name_check != null)
                {
                    MessageBox.Show("Данное судно уже существует.", "Cуда", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if(u_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Cуда", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_s.name = name;
                    u_s.number_of_seats = nos;
                    u_s.Ship_Type_Id = type;
                    db.SaveChanges();
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Cуда", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
