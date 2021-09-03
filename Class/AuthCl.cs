using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurTRPO
{
    public class AuthCl
    {
        public static int global_user;
        public bool Enter(string login, string password)
        {
            CheckCl checkCl = new CheckCl();
            gr691_baoEntities db = new gr691_baoEntities();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Вы заполнили не все поля", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if ((checkCl.Acc_Check(login) || checkCl.Acc_Check(password)) == false)
            {
                MessageBox.Show("Поля заполнены неверно", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            var auth_check = db.CurTRPO_Accounts.FirstOrDefault(ch => ch.login == login && ch.password == password);
            if (auth_check == null)
            {
                MessageBox.Show("Логин или пароль введены неверно", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            var us = db.CurTRPO_Users.FirstOrDefault(u => u.Acc_Id == auth_check.Id);
            global_user = us.Id;
            return true;
        }
    }
}
