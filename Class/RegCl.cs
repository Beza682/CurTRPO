using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurTRPO
{
    public class RegCl
    {
        public static string RegUs;
        public bool Add(string last, string first, string middle, string phone, string log, string pass)
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

                    if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(log) || string.IsNullOrWhiteSpace(pass))
                    {
                        MessageBox.Show("Вы не полностью заполнили форму", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else if ((checkCl.Cyr_Check(last) || checkCl.Cyr_Check(first) || checkCl.Cyr_Check(middle) || checkCl.Num_Check(phone) || checkCl.Acc_Check(log) || checkCl.Acc_Check(pass)) == false)
                    {
                        MessageBox.Show("Форма регистрации заполнена не корректно", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else if (login_check != null)
                    {
                        MessageBox.Show("Данный логин уже существует.", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else if (phone_check != null)
                    {
                        MessageBox.Show("Пользователь с номером телефона: " + phone + " уже существует.", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else
                    {
                        account.Role_Id = 3;
                        account.login = log;
                        account.password = pass;
                        db.CurTRPO_Accounts.Add(account);

                        user.Acc_Id = account.Id;
                        user.last_name = last;
                        user.first_name = first;
                        user.middle_name = middle;
                        user.phone_number = phone;
                        db.CurTRPO_Users.Add(user);

                        RegUs = phone;

                        db.SaveChanges();

                        MessageBox.Show("Регистрация прошла успешно!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Введите корректные значения.", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                return true;
            }
        }
    }
}

