using System;
using System.Collections.Generic;
using System.Text;
using Project;

namespace Project.Models
{
    class MenuCRUD
    {
        public static void GetPizza(List<Products> pizzaes)
        {
            foreach (Products item in pizzaes)
            {
                Console.WriteLine(item.Id+" " + item.PizzaName);
            }
        }
       public  static void AddPizza(List<Products> pizzaes, string pizzaName,double priace,string pizzaInside )
        {
            pizzaes.Add(new Products { PizzaName = pizzaName, Priaece = priace, PizzaInside = pizzaInside });
        }
        public static void PizzaInside(List<Products> pizzaes, int id) // bunu yazmaq yarimciq qalib
        {
            foreach (Products item in pizzaes)
            {
                if (item.Id == id)
                {
                    Console.WriteLine(item.PizzaInside);
                }
            }
            Console.WriteLine("Daxil etdiyiniz reqeme uygun pizza tapilmadi zehmet olamsa dugun reqem daxil edin");
        }
        public static double PizzaCountPriace(int num,double priace)
        {
            return num * priace;
        }

    }
}
