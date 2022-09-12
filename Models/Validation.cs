using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.Models
{
    class Validation
    {
        public static bool LoginIsAllowed(string username)
        {
            if ( username.Length >= 3 && username.Length <= 16)
            {
                return true;
            }
            Console.WriteLine("Daxil etdiyiniz Login uzunlugu 3 den az 16 dan boyuk ola bilmez");
            return false;
        }
        public static bool PaswordIsAllowed(string pasword)
        {
            if ( pasword.Length >= 6 && pasword.Length <= 16 && HasDigit(pasword) && HasLower(pasword)&& HasUpper(pasword))
            {
                return true;
            }
            return false;
        }
        public static bool NameIsAllowed(string name)
        {
            if (name.Length >= 3 && name.Length <= 30)
            {
                return true;
            }
            Console.WriteLine("Daxil etdiyiniz adin uzunlugu 3- den az 30- dan ise boyuk ola bilmez.");
            return false;
        }
        public static bool SurnameIsAllowed(string surName)
        {
            if ( surName.Length >= 3 && surName.Length <= 30)
            {
                return true;
            }
            Console.WriteLine("Daxil etdiyiniz soyadin uzunlugu 3- den az 30- dan ise boyuk ola bilmez.");
            return false;
        }
        public static bool CheckLogin(List<User> users, string username )
        {
            foreach (User item in users)
            {
                if (item.UserName == username)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool HasDigit(string password)
        {
            foreach (char item in password)
            {
                if (item >= 48 && item <= 57)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool HasUpper(string password)
        {
            foreach (char item in password)
            {
                if (item >= 65 && item <= 90)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool HasLower(string password)
        {
            foreach (char item in password)
            {
                if (item >= 97 && item <= 122)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckPasword(List<User> users, string pasword)
        {
            User user = users.Find(u => u.Pasword == pasword);
            if (user != null)
            {
                return true;
            }
            return false;
        }
        public static bool ChechLoginAvailability(List<User> users, string username)
        {

            foreach (User item in users)
            {
                if (item.UserName== username)
                {
                    return true;
                }
            }
            return false;
        }
        public static void OrederPizza(double lastpriace)
        {
            Console.WriteLine(lastpriace-1);
            Console.Write("Zehmet olmasa Catdirilma unvani ve elaqe nomresi qeyd edin: ");
            Console.ReadLine();
            Console.WriteLine("Sifarisiniz hazirlanir.... Nus olsun .");
        }
        public static int StartAdminMenu(int chouse)
        {
            Console.WriteLine("1.Hamisina Bax\n2.Elave et\n3.Duzelis et\n4.Sil");
            int.TryParse(Console.ReadLine(), out chouse);
            return chouse;
        }
    }
}

