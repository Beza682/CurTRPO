using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurTRPO
{
    public class UserCl
    {
        public bool Add(string last, string first, string middle, string phone, string log, string pass, int role)
        {
            {
                CheckCl checkCl = new CheckCl();
                gr691_baoEntities db = new gr691_baoEntities();
                try
                {
                    CurTRPO_Users user = new CurTRPO_Users();
                    CurTRPO_Accounts account = new CurTRPO_Accounts();

                    var login_check = db.CurTRPO_Accounts.FirstOrDefault(ch => ch.login == log);
                    var phone_check = db.CurTRPO_Users.FirstOrDefault(ch => ch.phone_number == phone);

                    if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(log) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(role.ToString()))
                    {
                        MessageBox.Show("Вы не полностью заполнили форму", "Создание пользователя", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else if ((checkCl.Cyr_Check(last) || checkCl.Cyr_Check(first) || checkCl.Cyr_Check(middle) || checkCl.Num_Check(phone) || checkCl.Acc_Check(log) || checkCl.Acc_Check(pass)) == false)
                    {
                        MessageBox.Show("Форма регистрации заполнена не корректно", "Создание пользователя", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else if (login_check != null)
                    {
                        MessageBox.Show("Данный логин уже существует.", "Создание пользователя", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else if (phone_check != null)
                    {
                        MessageBox.Show("Пользователь с номером телефона: " + phone + " уже существует.", "Создание пользователя", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else
                    {
                        account.Role_Id = role;
                        account.login = log;
                        account.password = pass;
                        db.CurTRPO_Accounts.Add(account);

                        user.Acc_Id = account.Id;
                        user.last_name = last;
                        user.first_name = first;
                        user.middle_name = middle;
                        user.phone_number = phone;
                        db.CurTRPO_Users.Add(user);
                        db.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Введите корректные значения.", "Создание пользователя", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                return true;
            }
        }
        public bool Delete(string id)
        {
            gr691_baoEntities db = new gr691_baoEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var d_a = db.CurTRPO_Accounts.Where(i => i.Id == num).FirstOrDefault();
                var d_acc_id = db.CurTRPO_Users.Where(i => i.Acc_Id == num).FirstOrDefault();
                if (d_a == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Удаление аккаунта пользователя", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if(d_a.Role_Id == 1)
                {
                    MessageBox.Show("Нельзя удалить аккаунт с ролью 'Администратор'.", "Удаление аккаунта пользователя", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    d_acc_id.Acc_Id = null;
                    db.CurTRPO_Accounts.Remove(d_a);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении аккаунта.", "Создание аккаунта", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
