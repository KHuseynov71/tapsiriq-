using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Project.Utilet.CostumException;
using Project.Models.Menu;
using Project.CRUDS;

namespace Project
{
    class Program
    {
        static List<Products> pizzaes = new List<Products>();//qiymet meselesi duzelmelidi
        static List<User> users = new List<User>();
        static void Main(string[] args)
        {
            users = UserCRUD.GetReader();
            pizzaes = ProductsCRUD.GetReaad();
        login:
            Console.WriteLine("Xos Gelmisiniz. Zehmet olmasa isteyinize uygun reqem daxil edin.");
            Console.WriteLine("1. Login\n2. Qeydiyyat");
            double lastpriace = 1;
            int inId = -1;
            int key = -1;
            try
            {
                int.TryParse(Console.ReadLine(), out key);
                Console.Clear();
            }
            catch (Exception)
            {
                Console.WriteLine("Isteyinize uygun emeliyyat tapilmadi zehmet olmasa duzgun reqem daxil edin");
            }
            if (key == 1)
            {
                if (!LoginMenu.LoginUser(users))
                UserMenu.ShowPizzaAndOrder(pizzaes,inId,lastpriace);
                else
                {
                    Adminmenu.AdminMenu(users,pizzaes,inId,lastpriace);
                }
            }
            else if (key == 2)
            {
                RegistrationMenu.RegistrationUser(users);
                goto login;
            }
            else
            {
                Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin");
                goto login;
            }
        }
    }
}
