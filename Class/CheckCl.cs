using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurTRPO
{
    public class CheckCl
    {
        public bool Num_Check(string text)
        {
            Regex phone = new Regex(@"[^0-9 ]");

            bool check = phone.IsMatch(text);

            if (check == true)
            {
                return false;
            }
            else return true;
        }
        public bool Cyr_Check(string text)
        {
            Regex cur = new Regex(@"[^а-яА-Я ]");

            bool check = cur.IsMatch(text);

            if (check == true)
            {
                return false;
            }
            else return true;
        }
        public bool Acc_Check(string text)
        {
            Regex lat = new Regex(@"[^a-zA-Z ]");
            Regex num = new Regex(@"[^0-9 ]");

            bool check1 = lat.IsMatch(text);
            bool check2 = num.IsMatch(text);

            if ((check1 && check2) == true)
            {
                return false;
            }
            else return true;
        }
        public bool Ship_Check(string text)
        {
            Regex lat = new Regex(@"[^a-zA-Z ]");
            Regex cur = new Regex(@"[^а-яА-Я ]");
            Regex num = new Regex(@"[^0-9 ]");
            Regex simb = new Regex(@"[^- ]");

            bool check1 = lat.IsMatch(text);
            bool check2 = cur.IsMatch(text);
            bool check3 = num.IsMatch(text);
            bool check4 = simb.IsMatch(text);

            if ((check1 && check2 && check3 && check4) == true)
            {
                return false;
            }
            else return true;
        }
        public bool Time_Check(string text)
        {
            Regex num = new Regex(@"[^0-9 ]");
            Regex simb2 = new Regex(@"[^: ]");


            bool check1 = num.IsMatch(text);
            bool check2 = simb2.IsMatch(text);

            if ((check1 && check2) == true)
            {
                return false;
            }
            else return true;
        }
        public bool Coord_Check(string text)
        {
            Regex num = new Regex(@"[^0-9 ]");
            Regex simb = new Regex(@"[^. ]");

            bool check1 = num.IsMatch(text);
            bool check2 = simb.IsMatch(text);

            if ((check1 && check2) == true)
            {
                return false;
            }
            else return true;
        }
        public bool RusName_Check(string text)
        {
            Regex num1 = new Regex(@"[^а-яА-Я ]");
            Regex num2 = new Regex(@"[^0-9 ]");
            Regex simb1 = new Regex(@"[^. ]");
            Regex simb2 = new Regex(@"[^, ]");
            Regex simb3 = new Regex(@"[^- ]");


            bool check1 = num1.IsMatch(text);
            bool check2 = num2.IsMatch(text);
            bool check3 = simb1.IsMatch(text);
            bool check4 = simb2.IsMatch(text);
            bool check5 = simb3.IsMatch(text);

            if ((check1 && check2 && check3 && check4 && check5) == true)
            {
                return false;
            }
            else return true;
        }
    }
}
