using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.Menu
{
    class UserCRUDMenu
    {
        public static void CRUDMenu(List<User> users)
        {
        Adminmenu:
            int chouse = -1;
            chouse = Validation.StartAdminMenu(chouse);
            switch (chouse)
            {
                case 1:
                    MenuCRUD.GetUser(users);
                    goto Adminmenu;
                case 2:
                    AddUser(users);
                    goto Adminmenu;
                case 3:
                    GiveAdmin(users);
                    goto Adminmenu;
                case 4:
                    CheckDelateUser(users);
                    goto Adminmenu;
                default:
                    Console.Clear();
                    Console.WriteLine("Duzgun reqem daxil edin");
                    goto Adminmenu;
            }
        }
        public static void AddUser(List<User> users)
        {
            Console.Clear();
            RegistrationMenu.RegistrationUser(users);
            Console.Clear();
            Console.WriteLine("Istifadeci elave olundu");
        }
        public static void GiveAdmin(List<User> users)
        {
            int id = -1;
            up:
            MenuCRUD.GetUser(users);
            Console.Write("Adminlik vermek istediyiniz istifadecinin nomresini daxil edin(geri getmek ucun 0 daxil edin) :");
            int.TryParse(Console.ReadLine(), out id);
            if (UserCRUD.GiveStatus(users, id))
            {
                Console.Clear();
                Console.WriteLine("Status deyisdirildi");
                UserCRUD.GetReader();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bele bir Istifadeci movcud deyil");
            }
        }
        public static bool DelateUser(List<User> users)
        {
            up:
            MenuCRUD.GetUser(users);
            Console.Write("Silmek istediyiniz istifadecinin nomresini daxil edin: ");
            int id = -1;
            try
            {
                int.TryParse(Console.ReadLine(), out id);
            }
            catch (Exception)
            {
                Console.WriteLine("Bele bir pizza movcud deyil");
                goto up;
            }
            if (id==1)
            {
                Console.WriteLine("Bu istifadecini silmek mumkun deyil.!!!");
                goto up;
            }
            else
            {
            foreach (User item in users)
            {
                if (item.Id == id)
                {
                    users.Remove(item);
                    users = UserCRUD.GetWriate(users);
                    Console.Clear();
                    return true;
                }
            }
            Console.Clear();
            }
            return false;
        }
        public static void CheckDelateUser(List<User> users)
        {
            users = UserCRUD.GetReader();
            if (DelateUser(users))
                Console.WriteLine("Istifadeci siyahidan silindi. ");
            else
                Console.WriteLine("Daxil etdiyiniz istifadeci tapilmadi");
        }
    }
}
