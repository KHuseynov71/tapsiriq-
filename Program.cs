using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
         List<Admin> admins = new List<Admin>();
         List<Products> pizzaes = new List<Products>();
         List<User> users = new List<User>(); 
            //using (StreamReader sr= new StreamReader("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Products.json"))
            //{
            //  pizzaes = JsonConvert.DeserializeObject<List<Products>>(sr.ReadToEnd());
            //}
            //pizzaes.Add(new Products { PizzaName = "Marqarita", Priaece = 11.90, PizzaInside = "Pizza sous, Gouda pendiri, Mozarella pendiri, Pomidor" });
            //pizzaes.Add(new Products { PizzaName = "Vegetarian", Priaece = 8.90, PizzaInside = "Pizza sous, Gouda pendiri,  Ispanaq, Qırmızı soğan, Bolqar bibəri, Pomidor, Göbələk" });
            //pizzaes.Add(new Products { PizzaName = "Fungi Kon Pollo", Priaece = 9.90, PizzaInside = "Pizza sous, Gouda pendiri, Göbələk, Toyuq filesi" });
            //pizzaes.Add(new Products { PizzaName = "Mista", Priaece = 9.90, PizzaInside = "Pizza sous, Gouda pendiri, Göbələk, Mal ətindən vetçina (halal), Salyami kolbasası (halal)" });
            //pizzaes.Add(new Products { PizzaName = "Salyami", Priaece = 9.90, PizzaInside = "Pizza sous, Gouda pendiri, Salyami kolbasası (halal)" });
            //pizzaes.Add(new Products { PizzaName = "Klassiko", Priaece = 9.90, PizzaInside = "Pizza sous, Gouda pendiri, Salyami kolbasası (halal), Göbələk, Pepperoni bibəri" });
            //pizzaes.Add(new Products { PizzaName = "Çiken Strips", Priaece = 10.90, PizzaInside = "Barbekyu sousu, Gouda pendiri, Toyuq naggetsləri, Qarğıdalı, Bolqar bibər" });
            //pizzaes.Add(new Products { PizzaName = "Amerikana", Priaece = 11.90, PizzaInside = "Pizza sousu, Qauda pendiri, Sosiska, Kartof fri, Duzlu xıyar" });
            //string a = JsonConvert.SerializeObject(pizzaes);
            //using (StreamWriter sw = new StreamWriter("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Products.json"))
            //{
            //    sw.Write(a);
            //}
            //MenuCRUD.GetPizza(pizzaes);
            //admins.Add(new Admin { UserName = "Admin", Pasword = "Admin123" });
            //using (StreamWriter sw = new StreamWriter("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Users.json"))
            //{
            //    sw.Write(JsonConvert.SerializeObject(admins));
            //}
        //using (StreamReader sr = new StreamReader("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Users.json"))
        //{
        //    admins = JsonConvert.DeserializeObject<List<Admin>>(sr.ReadToEnd());
        //}
        login:
            Console.WriteLine("Xos Gelmisiniz. Zehmet olmasa isteyinize uygun reqem daxil edin.");
            Console.WriteLine("1. Login\n2. Qeydiyyat");
            int key;
            int.TryParse(Console.ReadLine(), out key);
            Console.Clear();
            if (key == 1)
            {
                UserCRUD.LoginUser(users);
                Console.WriteLine();
            }
            else if (key == 2)
            {
                UserCRUD.RegistrationUser(users);
            }
            else
            {
                Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin");
                goto login;
            }
        }
    }
}
