using Newtonsoft.Json;
using Project0.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

namespace Project0
{
    class Program
    {
        

        static void Main(string[] args)
        {
            List<Users> users = new List<Users>();
            //    users.Add(new Users { Username = "admin", Password = "admin" });
            //    users.Add(new Users { Username = "user", Password = "user" });

            //    using (StreamWriter sw = new StreamWriter()) ;
            //    using (StreamWriter sw = new StreamWriter()) ;
            //}

            Console.WriteLine("Input : Write 10");
            Console.WriteLine("Registration : Write 11");
            int key = Convert.ToInt32(Console.ReadLine());
         

            if (key == 10)
            {
                Console.WriteLine("Welcome go to registr ");
                List<Users> user = new List<Users>();
                Console.Write("Name :");
                string name = Console.ReadLine();

                Console.Write("Surname : ");
                string surname = Console.ReadLine();

                Console.Write("Login : ");
                string login = Console.ReadLine();

                Console.Write("Password :");
                string password = Console.ReadLine();
                users.Add(new Users { Name = name, Surname = surname, Login = login, Password = password });
                string b = JsonConvert.SerializeObject(users);



                using (StreamWriter sw = new StreamWriter(@"C:\Users\Togrul\Desktop\p3262\Project0\Project0\Files\users.json"))
                {
                    sw.Write(JsonConvert.SerializeObject(users));

                }
            }



            else if (key == 11)
            {

            Input:
                Console.Write("Username:");
                string username = Console.ReadLine();

                Console.Write("Password:");
                string password = Console.ReadLine();

                List<Users> users1 = new List<Users>();

                using (StreamReader sr = new StreamReader("C:\\Users\\Togrul\\Desktop\\p3262\\Project0\\Project0\\Files\\users.json"))
                {
                    users1 = JsonConvert.DeserializeObject<List<Users>>(sr.ReadToEnd());
                }
                Users user = users.Find(u => u.Username == username && u.Password == password);
                if (user == null)
                {
                    Console.WriteLine("Username or password is incorrect");
                    goto Input;
                }
              
                Console.WriteLine("Welcome");
                Console.WriteLine($"{user.Name}");
                Console.WriteLine($"{user.Surname}");



                if (user.IsAdmin == false)
                {
                Pizza:
                    Console.WriteLine(" Pizzalara bax");
                    Console.WriteLine("Sifaris ver");
                    int key1 = Convert.ToInt32(Console.ReadLine());
                    if (key1 == 1)
                    {
                        Process.AddPizza();
                        goto Pizza;
                    }
                    else if (key1 == 2)
                    {
                        Process.GetPizza();
                        goto Pizza;
                    }
                }

                else
                {
                Admin:
                    Console.WriteLine(" Pizzalar");
                    Console.WriteLine(" Userlər");
                    int key1 = Convert.ToInt32(Console.ReadLine());
                    if (key1 == 1)
                    {
                        Process.AddPizza();
                        goto Admin;
                    }
                    else if (key1 == 2)
                    {
                        Process.GetPizza();
                        goto Admin;
                    }
                  
                }
               




            }

        }


        public static bool IsContainDigit(string str)
        {
            foreach (char ch in str)
            {
                if (ch > 47 && ch < 58)     /*  1 böyük, 1 kiçik hərflərdən və ən azı 1 rəqəm qeyd olunmalıdır.*/
                    return true;
            }
            return false;
        }

        public static bool IsContainLowercase(string str)
        {
            foreach (char ch in str)
            {
                if (ch > 96 && ch < 123)
                    return true;
            }
            return false;
        }

        public static bool IsContainUppercase(string str)
        {
            foreach (char ch in str)
            {
                if (ch > 64 && ch < 91)
                    return true;
            }
            return false;
        }



        static void DeleteFilesFromDirectory(string path)
        {
            foreach (var item in Directory.GetFiles(path))
            {
                File.Delete(item);
            }
        }
        static void DeleteDirectoriesFromDirectory(string path)
        {
            foreach (var item in Directory.GetDirectories(path))
            {
                DeleteFilesFromDirectory(item);
                Directory.Delete(item);

            }
        }
        

      
    }
}
    


