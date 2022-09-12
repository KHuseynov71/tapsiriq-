using Newtonsoft.Json;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.CRUDS
{
    class ProductsCRUD
    {
        public static List<Products> GetReaad()
        {
            List<Products> pizzaes = new List<Products>();
            using (StreamReader sr = new StreamReader("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Products.json"))
                pizzaes = JsonConvert.DeserializeObject<List<Products>>(sr.ReadToEnd());
            return pizzaes;
        }
        public static List<Products> GetWriate(List<Products>pizzaes)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Products.json"))
                sw.Write(JsonConvert.SerializeObject(pizzaes));
            return pizzaes;
        }
        public static int IncreaseId(List<Products> users, int id)
        {
            foreach (Products item in users)
            {
                if (item.Id > id)
                {
                    id = item.Id;
                }
            }
            return id;
        }
        public static void ShowPizza(List<Products> pizzaes,int id)
        {
            foreach (Products item in pizzaes)
            {
                if (item.Id== id)
                {
                    Console.WriteLine("Pizzanin Adi: " +item.PizzaName+ "\nPizzanin qiymeti: "+item.Priaece+ "\nPizzanin terkibi: "+ item.PizzaInside);
                }
            }
        }
    }
}
