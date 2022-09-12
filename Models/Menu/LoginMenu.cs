using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.Menu
{
    class LoginMenu
    {
        public static bool LoginUser(List<User> users)
        {
        Login:
            Console.WriteLine("Zehmet olmasa Login ve Parolunuzu daxil edin");
            Console.Write("Login:");
            string inputeLogin = Console.ReadLine();
            Console.Write("Parol:");
            string inputPasword = Console.ReadLine();
            users = UserCRUD.GetReader(); // reader islemir duzeltilmelidi
            User user = users.Find(u => u.UserName == inputeLogin && u.Pasword == inputPasword );
            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Username ve ya Parol sehvdi");
                goto Login;
            }
            Console.Clear();
            UserCRUD.ShowNameSurName(users, inputeLogin);
            return user.Status;
        }
    }
}
