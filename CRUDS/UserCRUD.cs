using Newtonsoft.Json;
using Project.Utilet.CostumException;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.Models
{
    class UserCRUD
    {
        public static List<User> GetReader()
        {
            List<User> users = new List<User>();
            using (StreamReader sr = new StreamReader("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Users.json"))
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            return users;
        }
        public static List<User> GetWriate(List<User> users)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\LENOVO\\Desktop\\Yazdigim Tasklar\\Project\\Files\\Users.json"))
                sw.Write(JsonConvert.SerializeObject(users));
            return users;
        }
        public static void ShowNameSurName(List<User> users, string username)
        {
            foreach (User item in users)
            {
                if (item.UserName == username)
                    Console.WriteLine("Xos geldiniz :" + item.Name + " " + item.SurName);
            }
        }
        public static bool GiveStatus(List<User> users, int id) // Usere adminlik vermek
        {
            foreach (User item in users)
            {
                if (item.Id == id)
                {
                    item.Status = true;
                    GetReader();
                    GetWriate(users);
                    return true;
                }
            }
            return false;
        }
        public static int IncreaseId(List<User> users, int id)
        {
            foreach (User item in users)
            {
                if (item.Id > id)
                {
                    id = item.Id;
                }
            }
            return id;
        }
    }
}
