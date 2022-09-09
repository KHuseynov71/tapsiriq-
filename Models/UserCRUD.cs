using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.Models
{
    class UserCRUD
    {

        public static void RegistrationUser(List<User> users)
        {
        adsehvi:
            Console.WriteLine("Zehmet olmasa Adinizi daxil edin");
            string name = Console.ReadLine();
            Console.Clear();
            if (!Validation.NameIsAllowed(name))
            {
                goto adsehvi;
            }
        soyadsehvi:
            Console.WriteLine("Zehmet olmasa Soyadinizi daxil edin");
            string surname = Console.ReadLine();
            Console.Clear();
            if (!Validation.SurnameIsAllowed(surname))
            {
                goto soyadsehvi;
            }
        loginsehvi:
            Console.WriteLine("Zehmet olmasa Istifadeci adi daxil edin");
        eyniaddalogin:
            string login = Console.ReadLine();
            if (Validation.CheckLogin(users, login))
            {
                Console.Clear();
                Console.WriteLine("Bu adda istifadeci movcuddur, Zehmet olmasa yeni ad daxil edin");
                goto eyniaddalogin;
            }
            Console.Clear();
            if (!Validation.LoginIsAllowed(login))
            {
                goto loginsehvi;
            }
        paswordsehvi:
            Console.WriteLine("Zehmet olmasa Parol daxil edin, Parolun uzunlugu en az 6 en cox ise 16 ola biler\n ( 1 boyuk, 1 kicik herf ve en azi 1 reqem olmagi mutleqdir) ");
            string pasword = Console.ReadLine();
            Console.Clear();
            if (!Validation.PaswordIsAllowed(pasword))
            {

                goto paswordsehvi;
            }

            users.Add(new User { Name = name, SurName = surname, UserName = login, Pasword = pasword });
            using (StreamWriter sw = new StreamWriter("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Users.json", true))
            {
                sw.WriteLine(JsonConvert.SerializeObject(users));
            }
            Console.WriteLine("Qeydiyyat ugurla heyata kecdi");
            LoginUser(users);
        }
        public static void ShowNameSurName(List<User> users, string username)
        {
            foreach (User item in users)
            {
                if (item.UserName == username)
                {
                    Console.WriteLine("Xos geldiniz" + item.Name + " " + item.SurName);
                }
            }
        }
        public static void LoginUser(List<User> users)
        {
            Console.WriteLine("Zehmet olmasa Login ve Parolunuzu daxil edin");
            Console.Write("Login:");
            string inputeLogin = Console.ReadLine();
            Console.Write("Parol:");
            string inputPasword = Console.ReadLine();
            if (!Validation.CheckLogin(users, inputeLogin))
            {
                Console.WriteLine("Daxil etdiyiniz Login sehvdir");
            }
            else if (!Validation.CheckPasword(users, inputPasword))
            {
                Console.WriteLine("Daxil etdiyiniz Parol sehvdir");
            }
            ShowNameSurName(users, inputeLogin);

        }
        public static void UserMenu(List<Products> pizzaes)
        {
        UserMenu:
            Console.WriteLine("1. Pizzalara bax \n2. Sifaris ver");
            int key;
            int.TryParse(Console.ReadLine(), out key);
            Console.Clear();
            if (key == 1)
            {
                using (StreamWriter sw = new StreamWriter("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Products.json"))
                {
                    sw.Write(JsonConvert.SerializeObject(pizzaes));
                }
                MenuCRUD.GetPizza(pizzaes);
            }
            else if (key == 2)
            {
                Console.WriteLine("Istediyiniz Pizzanin Nomresini daxil edin");

            }
            else
            {
                Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin");
                goto UserMenu;
            }
        }
    }
}
