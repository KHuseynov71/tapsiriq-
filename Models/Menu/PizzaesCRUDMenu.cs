using Newtonsoft.Json;
using Project.CRUDS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.Models.Menu
{
    class PizzaesCRUDMenu
    {
        public static void CRUDMenu(List<Products> pizzaes)
        {
            Console.Clear();
        Adminmenu:
            int chouse = -1;
            chouse = Validation.StartAdminMenu(chouse);
            switch (chouse)
            {
                case 1:
                    MenuCRUD.GetPizza(pizzaes);
                    goto Adminmenu;
                case 2:
                    AddPizza(pizzaes);
                    goto Adminmenu;
                case 3:
                    ChangePizza(pizzaes);
                    break;
                case 4:
                    CheckDelatePizza(pizzaes);
                    goto Adminmenu;
                default:
                    Console.WriteLine("Duzgun reqem daxil edin");
                    Console.Clear();
                    goto Adminmenu;
            }
        }
        public static void AddPizza(List<Products> pizzaes)
        {
            Console.Clear();
            Console.Write("Pizzanin Adi:");
            string pizzaname = Console.ReadLine();
        pizzapriace:
            Console.Write("Pizzanin qiymeti:");
            double priace = -1;
            try
            {
                double.TryParse(Console.ReadLine(), out priace);
            }
            catch (Exception)
            {
                goto pizzapriace;
            }
            Console.Write("Pizzaya daxil olan ingridiyentler:");
            string pizzainside = Console.ReadLine();
            MenuCRUD.AddPizza(pizzaes, pizzaname, priace, pizzainside);
            Console.Clear();
            Console.WriteLine("Pizza siyahiya elave olundu");
        }
        public static void ChangePizza(List<Products> pizzaes)
        {
        Up:
            MenuCRUD.GetPizza(pizzaes);
            Console.WriteLine("Deyismek istediyiniz Pizzanin nomresini daxil edin");
            int id = -1;
            try
            {
                int.TryParse(Console.ReadLine(), out id);
                pizzaes = ProductsCRUD.GetReaad();
                foreach (Products item in pizzaes)
                {
                    if (item.Id == id)
                    {
                        ProductsCRUD.ShowPizza(pizzaes, id);
                        ChangePizzaInside(pizzaes,id);
                    }
                }
                Console.Clear();
                Console.WriteLine("Daxil etdiyiniz reqem yalnisdir");
                goto Up;
            }
            catch (Exception)
            {
                Console.WriteLine("Daxil etdiyiniz reqem yalnisdir");
                goto Up;
            }
        }
        public static bool DelatePizza(List<Products> pizzaes)
        {
            MenuCRUD.GetPizza(pizzaes);
            Console.Write("Silmek istediyiniz pizzanin nomresini daxil edin: ");
            int id = -1;
            try
            {
                int.TryParse(Console.ReadLine(), out id);
            }
            catch (Exception)
            {
                Console.WriteLine("Bele bir pizza movcud deyil");
            }
            foreach (Products item in pizzaes)
            {
                if (item.Id == id)
                {
                    pizzaes.Remove(item);
                    pizzaes = ProductsCRUD.GetWriate(pizzaes);
                    Console.Clear();
                    return true;
                }
            }
            Console.Clear();
            return false;
        }
        public static void CheckDelatePizza(List<Products> pizzaes)
        {
            if (DelatePizza(pizzaes))
                Console.WriteLine("Pizza siyahidan silindi. ");
            else
                Console.WriteLine("Daxil etdiyiniz pizza tapilmadi");
        }
        public static void ChangePizzaInside(List<Products> pizzaes, int id)
        {
            int num = -1;
        Up:
            Console.Clear();
            MenuCRUD.GetPizza(pizzaes);
            Console.WriteLine("Deyismek istediyinizi secin.\n1.Adini\n2.Qiymetini\n3.Terkibini\n0.Geri qayitmaq");
            try
            {
                int.TryParse(Console.ReadLine(), out num);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("daxil etdiyiniz reqem yalnisdir");
                goto Up;
            }
            switch (num)
            {
                case 1:
                    ChangeName(pizzaes, id);
                    goto Up;
                case 2:
                    ChangepPriace(pizzaes,id);
                    goto Up;
                case 3:
                    ChangeInside(pizzaes,id);
                    goto Up;
                case 0:
                    Console.Clear();
                    CRUDMenu(pizzaes);
                    break;
                default:
                    Console.WriteLine("Duzgun reqem daxil edin");
                    Console.Clear();
                    goto Up;
            }
        }
        public static void ChangeName(List<Products> pizzaes, int id)
        {
            pizzaes = ProductsCRUD.GetReaad();
            Console.Write("Yeni adi daxil edin: ");
            string newName;
            newName = Console.ReadLine();
            foreach (Products item in pizzaes)
            {
                if (item.Id == id)
                {
                    item.PizzaName = newName;
                   pizzaes=ProductsCRUD.GetWriate(pizzaes);
                }
            }
        }
        public static void ChangepPriace(List<Products> pizzaes, int id)
        {
            pizzaes = ProductsCRUD.GetReaad();
            Console.Write("Yeni qiymet daxil edin: ");
            double newPriace;
            double.TryParse( Console.ReadLine(),out newPriace);
            foreach (Products item in pizzaes)
            {
                if (item.Id == id)
                {
                    item.Priaece = newPriace;
                    ProductsCRUD.GetWriate(pizzaes);
                }
            }
        }
        public static void ChangeInside(List<Products> pizzaes, int id)
        {
            pizzaes = ProductsCRUD.GetReaad();
            Console.Write("Yeni melumatlari daxil edin: ");
            string newInside;
            newInside = Console.ReadLine();
            foreach (Products item in pizzaes)
            {
                if (item.Id == id)
                {
                    item.PizzaInside = newInside;
                    ProductsCRUD.GetWriate(pizzaes);
                }
            }
        }
    }
}
