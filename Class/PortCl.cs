using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurTRPO
{
    public class PortCl
    {
        public bool Add(string name, string address, string pn, string lat, string lon)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                CurTRPO_Ports curTRPO_Ports = new CurTRPO_Ports();

                var name_check = db.CurTRPO_Ports.FirstOrDefault(ch => ch.name == name);

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(pn) || string.IsNullOrWhiteSpace(lat) || string.IsNullOrWhiteSpace(lon))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.RusName_Check(name) || checkCl.RusName_Check(address) || checkCl.Num_Check(pn) || checkCl.Coord_Check(lat) || checkCl.Coord_Check(lon)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (name_check != null)
                {
                    MessageBox.Show("Данное судно уже существует.", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    curTRPO_Ports.name = name;
                    curTRPO_Ports.address = address;
                    curTRPO_Ports.phone_number = pn;
                    curTRPO_Ports.latitude = lat;
                    curTRPO_Ports.longitude = lon;
                    db.CurTRPO_Ports.Add(curTRPO_Ports);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_p = db.CurTRPO_Ports.Where(i => i.Id == num).FirstOrDefault();
                if (d_p == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.CurTRPO_Ports.Remove(d_p);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Нельзя удалить порт, который привязан к расписанию .\nОчистите расписание.", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string name, string address, string pn, string lat, string lon)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_p = db.CurTRPO_Ports.Where(u => u.Id == num).FirstOrDefault();
                var name_check = db.CurTRPO_Ports.FirstOrDefault(ch => ch.name == name);

                if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(pn) || string.IsNullOrWhiteSpace(lat) || string.IsNullOrWhiteSpace(lon))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(id) || checkCl.RusName_Check(name) || checkCl.RusName_Check(address) || checkCl.Num_Check(pn) || checkCl.Coord_Check(lat) || checkCl.Coord_Check(lon)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (name_check != null)
                {
                    MessageBox.Show("Данное судно уже существует.", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if(u_p == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    u_p.name = name;
                    u_p.address = address;
                    u_p.phone_number = pn;
                    u_p.latitude = lat;
                    u_p.longitude = lon;
                    db.SaveChanges();
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Порты", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
