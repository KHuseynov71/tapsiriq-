using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Project;
using Project.CRUDS;

namespace Project.Models
{
    class MenuCRUD
    {
        public static void GetPizza(List<Products> pizzaes)
        {
            pizzaes = ProductsCRUD.GetReaad();
            foreach (Products item in pizzaes)
                Console.WriteLine(item.Id + " " + item.PizzaName);
        }
        public static void AddPizza(List<Products> pizzaes, string pizzaName, double priace, string pizzaInside)
        {
            int id = 0;
            List<Products> pizzaes1;
            using (StreamReader sr = new StreamReader("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Products.json"))
            {
                pizzaes1 = JsonConvert.DeserializeObject<List<Products>>(sr.ReadToEnd());
            }
            pizzaes1.Add(new Products { PizzaName = pizzaName, Priaece = priace, PizzaInside = pizzaInside, Id = (ProductsCRUD.IncreaseId(pizzaes, id)) + 1 });
            using (StreamWriter sw = new StreamWriter("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Products.json"))
                sw.Write(JsonConvert.SerializeObject(pizzaes1));
            pizzaes.Add(new Products { PizzaName = pizzaName, Priaece = priace, PizzaInside = pizzaInside, Id = (ProductsCRUD.IncreaseId(pizzaes, id)) + 1 });

        }
        public static int PizzaInside(List<Products> pizzaes, int id)
        {
            int count = 0;
            foreach (Products item in pizzaes)
            {
                if (item.Id == id)
                {
                    Console.WriteLine(item.PizzaInside);
                    count += 1;
                }
            }
            return count;
        }
        public static void GetUser(List<User> users)
        {
            int id;
            users=UserCRUD.GetReader();
            Console.Clear();
            foreach (User item in users)
            {
                id= item.Id;
                Console.WriteLine(item.Id+"." + "\nAd :" + item.UserName + " \nSoyad :" + item.SurName + "\nUsername :" + item.UserName + "\nStatus :" ); Status(users, id);
            }
        }
        public static void Status(List<User> users, int id )
        {
            foreach (User item in users)
            {
                if (item.Id == id)
                {
                    if (item.Status)
                    {
                        Console.WriteLine("Admin");
                    }
                    else
                    {
                        Console.WriteLine("Istifadeci");
                    }
                }
            }
        }
    }
}
