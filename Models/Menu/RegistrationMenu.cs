using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.Models.Menu
{
    class RegistrationMenu
    {
        public static void RegistrationUser(List<User> users)
        {
        adsehvi:
            Console.WriteLine("Zehmet olmasa Adinizi daxil edin");
            string name = Console.ReadLine();
            Console.Clear();
            if (!Validation.NameIsAllowed(name)) goto adsehvi;
            soyadsehvi:
            Console.WriteLine("Zehmet olmasa Soyadinizi daxil edin");
            string surname = Console.ReadLine();
            Console.Clear();
            if (!Validation.SurnameIsAllowed(surname)) goto soyadsehvi;
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
            if (!Validation.LoginIsAllowed(login)) goto loginsehvi;
            paswordsehvi:
            Console.WriteLine("Zehmet olmasa Parol daxil edin, Parolun uzunlugu en az 6 en cox ise 16 ola biler\n ( 1 boyuk, 1 kicik herf ve en azi 1 reqem olmagi mutleqdir) ");
            string pasword = Console.ReadLine();
            Console.Clear();
            if (!Validation.PaswordIsAllowed(pasword)) goto paswordsehvi;
            int id = 0;
            List<User> users1;
            using (StreamReader sr = new StreamReader("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Users.json"))
                users1 = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            users1.Add(new User { Name = name, SurName = surname, UserName = login, Pasword = pasword, Id = (UserCRUD.IncreaseId(users, id)) + 1 });
            using (StreamWriter sw = new StreamWriter("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Users.json"))
                sw.Write(JsonConvert.SerializeObject(users1));
            Console.WriteLine("Qeydiyyat ugurla heyata kecdi");
        }
    }
}
