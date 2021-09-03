using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurTRPO
{
    public class StatusCl
    {
        public bool Add(string stat)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                CurTRPO_Status curTRPO_Status = new CurTRPO_Status();

                var stat_check = db.CurTRPO_Status.FirstOrDefault(ch => ch.name == stat);

                if (string.IsNullOrWhiteSpace(stat))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Cyr_Check(stat)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (stat_check != null)
                {
                    MessageBox.Show("Данный статус уже существует.", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Status.name = stat;
                    db.CurTRPO_Status.Add(curTRPO_Status);
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
                var d_s = db.CurTRPO_Status.Where(i => i.Id == num).FirstOrDefault();
                if (d_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.CurTRPO_Status.Remove(d_s);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Нельзя удалить статус, который используется в расписании.\nОчистите расписание.", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string stat)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Status.Where(u => u.Id == num).FirstOrDefault();
                var stat_check = db.CurTRPO_Status.FirstOrDefault(ch => ch.name == stat);

                if (string.IsNullOrWhiteSpace(stat))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Cyr_Check(stat)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (stat_check != null)
                {
                    MessageBox.Show("Данный статус уже существует.", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    if (u_s == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_s.name = stat;
                    db.SaveChanges();
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Статус отправления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
