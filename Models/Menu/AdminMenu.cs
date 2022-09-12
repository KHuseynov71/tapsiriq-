using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.Menu
{
    class Adminmenu
    {
        public static void AdminMenu(List<User> users,List<Products> pizzaes, int inId, double lastpriace)
        {
            AdminMenu:
            Console.WriteLine("1. Pizzalara bax \n2. Sifaris ver\n3. Pizzalar\n4. Userler");
            int key1;
            int.TryParse(Console.ReadLine(), out key1);
            Console.Clear();
            if (key1 == 1)
            {
            noinformation:
                MenuCRUD.GetPizza(pizzaes);
                Console.Write("Istediyiniz pizzanin nomresini daxil edin:");
                try
                {
                    int.TryParse(Console.ReadLine(), out inId);
                    Console.Clear();
                    if (MenuCRUD.PizzaInside(pizzaes, inId) == 0)
                    {
                        Console.WriteLine("Daxil etdiyiniz nomrede Pizza yoxdur");
                        goto noinformation;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Isteyinize uygun emeliyyat tapilmadi zehmet olmasa duzgun reqem daxil edin");
                    goto noinformation;
                }
            up:
                Console.WriteLine("Pizzani sebete elave etmek ucun S, Diger pizzalara baxmaq ucun ise G daxil edin, Geri getmek ucun ise 0");
                char inchouse;
                try
                {
                    char.TryParse(Console.ReadLine().ToUpper(), out inchouse);
                    Console.Clear();
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Isteyinize uygun emeliyyat tapilmadi zehmet olmasa duzgun reqem daxil edin");
                    goto up;
                }
                if (inchouse == 'S')
                {
                    UserMenu.AddBasket(pizzaes, inId, lastpriace);
                }
                if (inchouse == 'G')
                {
                    Console.Clear();
                    goto noinformation;
                }
                else if (inchouse == '0')
                {
                    Console.Clear();
                    goto AdminMenu;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Isteyinize uygun emeliyyat tapilmadi zehmet olmasa duzgun reqem daxil edin");
                    goto up;
                }
            }
            else if (key1 == 2)
            {
                if (lastpriace == 1)
                {
                    Console.WriteLine("Sebetiniz bosdu. Zehmet olmasa sifares vermezden evvel sebete Pizza daxil edin. ");
                    goto AdminMenu;
                }
                else
                    Validation.OrederPizza(lastpriace);
            }
            switch (key1)
            {
                case 3:
                    PizzaesCRUDMenu.CRUDMenu(pizzaes);
                    break;
                case 4:
                    UserCRUDMenu.CRUDMenu(users);
                    break;
                default:
                    Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin");
                    goto AdminMenu;
            }
        }
    }
}
