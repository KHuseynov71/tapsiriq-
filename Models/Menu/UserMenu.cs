using Newtonsoft.Json;
using Project.Utilet.CostumException;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.Models.Menu
{
    class UserMenu
    {
        //public static  void UserMenus(List<Products> pizzaes)
        //{
        //    double lastpriace = 1;
        //UserMenu:
        //    Console.WriteLine("1. Pizzalara bax \n2. Sifaris ver");
        //    int key;
        //    int.TryParse(Console.ReadLine(), out key);
        //    Console.Clear();
        //    if (key == 1)
        //    {
        //    noinformation:
        //        MenuCRUD.GetPizza(pizzaes);
        //        Console.Write("Istediyiniz pizzanin nomresini daxil edin:");
        //        int inId;
        //        try
        //        {
        //            int.TryParse(Console.ReadLine(), out inId);
        //            Console.Clear();
        //            if (MenuCRUD.PizzaInside(pizzaes, inId)== 0)
        //            {
        //                Console.WriteLine("Daxil etdiyiniz nomrede Pizza yoxdur");
        //                goto noinformation;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Isteyinize uygun emeliyyat tapilmadi zehmet olmasa duzgun reqem daxil edin");
        //            goto noinformation;
        //        }
        //    up:
        //        Console.WriteLine("Pizzani sebete elave etmek ucun S, Diger pizzalara baxmaq ucun ise G daxil edin, Geri getmek ucun ise 0");
        //        char inchouse;
        //        try
        //        {
        //            char.TryParse(Console.ReadLine().ToUpper(), out inchouse);
        //            Console.Clear();
        //        }
        //        catch (Exception)
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Isteyinize uygun emeliyyat tapilmadi zehmet olmasa duzgun reqem daxil edin");
        //            goto up;
        //        }
        //        double priace;
        //        if (inchouse == 'S')
        //        {
        //            List<Products> pizzaes1;
        //            using (StreamReader sr = new StreamReader("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Products.json"))
        //                pizzaes1 = JsonConvert.DeserializeObject<List<Products>>(sr.ReadToEnd());
        //            foreach (Products item in pizzaes1)
        //            {
        //                if (item.Id == inId)
        //                {
        //                    priace = item.Priaece;
        //                    lastpriace += PizzaCountPriace(priace);
        //                    Console.WriteLine("Pizza sebete elave olundu.");
        //                wrong:
        //                    Console.WriteLine("Sifarisi tamamlamaq ucun 1 , yeni pizza elave etmek ucun ise 2 daxil edin");
        //                    int key1 = -1;
        //                    try
        //                    {
        //                        int.TryParse(Console.ReadLine(), out key1);
        //                    }
        //                    catch (Exception)
        //                    {
        //                        Console.Clear();
        //                        Console.WriteLine("Isteyinize uygun emeliyyat tapilmadi zehmet olmasa duzgun reqem daxil edin");
        //                        goto wrong;
        //                    }
        //                    if (key1 == 1)
        //                    {
        //                        Console.Clear();
        //                        Validation.OrederPizza(lastpriace);
        //                    }
        //                    else if (key1 == 2)
        //                    {
        //                        Console.Clear();
        //                        goto noinformation;
        //                    }
        //                }
        //            }
        //        }
        //        if (inchouse == 'G')
        //        {
        //            Console.Clear();
        //            goto noinformation;
        //        }
        //        else if (inchouse == '0')
        //        {
        //            Console.Clear();
        //            goto UserMenu;
        //        }
        //        else
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Isteyinize uygun emeliyyat tapilmadi zehmet olmasa duzgun reqem daxil edin");
        //            goto up;
        //        }
        //    }
        //    else if (key == 2)
        //    {
        //        if (lastpriace == 1)
        //        {
        //            Console.WriteLine("Sebetiniz bosdu. Zehmet olmasa sifares vermezden evvel sebete Pizza daxil edin. ");
        //            goto UserMenu;
        //        }
        //        else
        //            Validation.OrederPizza(lastpriace);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin");
        //        goto UserMenu;
        //    }
        //}
        public static void ShowPizzaAndOrder(List<Products> pizzaes, int inId, double lastpriace)
        {
        UserMenu:
            Console.WriteLine("1. Pizzalara bax \n2. Sifaris ver");
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
                    AddBasket(pizzaes, inId, lastpriace);
                }
                if (inchouse == 'G')
                {
                    Console.Clear();
                    goto noinformation;
                }
                else if (inchouse == '0')
                {
                    Console.Clear();
                    goto UserMenu;
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
                    goto UserMenu;
                }
                else
                    Validation.OrederPizza(lastpriace);
            }
            else
            {
                Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin");
                goto UserMenu;
            }
        }
        public static double PizzaCountPriace(double priace)
        {
        up:
            Console.Write("Pizza sayini daxil edin :");// basket listini sonda temizlemek yaddan cixmasin
            int num;
            int.TryParse(Console.ReadLine(), out num);
            if (num > 0)
            {
                priace *= num;
                return priace;
            }
            else
                Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin "); goto up;
        }
        public static void LookinAtPizza(List<Products> pizzaes)
        {
        noinformation:
            MenuCRUD.GetPizza(pizzaes);
            Console.Write("Istediyiniz pizzanin nomresini daxil edin:");
            int inId;
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
        }
        public static void AddBasket(List<Products> pizzaes ,int inId,double lastpriace)
        {
            double priace;
            List<Products> pizzaes1;
            using (StreamReader sr = new StreamReader("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Products.json"))
                pizzaes1 = JsonConvert.DeserializeObject<List<Products>>(sr.ReadToEnd());
            foreach (Products item in pizzaes1)
            {
                if (item.Id == inId)
                {
                    priace = item.Priaece;
                    lastpriace += PizzaCountPriace(priace);
                    Console.WriteLine("Pizza sebete elave olundu.");
                wrong:
                    Console.WriteLine("Sifarisi tamamlamaq ucun 1 , yeni pizza elave etmek ucun ise 2 daxil edin");
                    int key1 = -1;
                    try
                    {
                        int.TryParse(Console.ReadLine(), out key1);
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Isteyinize uygun emeliyyat tapilmadi zehmet olmasa duzgun reqem daxil edin");
                        goto wrong;
                    }
                    if (key1 == 1)
                    {
                        Console.Clear();
                        Validation.OrederPizza(lastpriace);
                    }
                    else if (key1 == 2)
                    {
                        Console.Clear();
                        LookinAtPizza(pizzaes);
                    }
                }
            }
        }
    }
}
