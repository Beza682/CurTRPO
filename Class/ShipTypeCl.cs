using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurTRPO
{
    public class ShipTypeCl
    {
        public bool Add(string type)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                CurTRPO_Ship_Type curTRPO_Ship_Type = new CurTRPO_Ship_Type();

                var type_check = db.CurTRPO_Ship_Type.FirstOrDefault(ch => ch.name == type);

                if (string.IsNullOrWhiteSpace(type))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Типы судов", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Cyr_Check(type)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Типы судов", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (type_check != null)
                {
                    MessageBox.Show("Данный тип судна уже существует.", "Типы судов", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Ship_Type.name = type;
                    db.CurTRPO_Ship_Type.Add(curTRPO_Ship_Type);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Типы судов", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_s = db.CurTRPO_Ship_Type.Where(i => i.Id == num).FirstOrDefault();
                if (d_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Типы судов", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.CurTRPO_Ship_Type.Remove(d_s);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Нельзя удалить типы суда, который привязан к судну.\nОчистите суда.", "Типы судов", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string type)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.CurTRPO_Ship_Type.Where(u => u.Id == num).FirstOrDefault();
                var type_check = db.CurTRPO_Ship_Type.FirstOrDefault(ch => ch.name == type);

                if (string.IsNullOrWhiteSpace(type))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Типы судов", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Cyr_Check(type)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Типы судов", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (type_check != null)
                {
                    MessageBox.Show("Данный тип судна уже существует.", "Типы судов", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    if (u_s == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Типы судов", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_s.name = type;
                    db.SaveChanges();
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Типы судов", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
