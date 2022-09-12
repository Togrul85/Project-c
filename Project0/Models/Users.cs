using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project0.Models
{
    class User
    {
        
        public int Id { get; set; }
        public bool IsAdmin { get; set; }   
        public string Password { get;set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }


        static string UserPath = "C:\\Users\\Togrul\\Desktop\\p3262\\Project0\\Project0\\Files\\users.json";
        public static List<User> ReadFromJson()
        {
            List<User> users;
            using (StreamReader sr = new StreamReader(UserPath))
            {
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            }
            return users;
        }

        public static void AddToJson(User b)
        {
            List<User> users = ReadFromJson();
            int MaxId = 1;
            foreach (User user in users)
            {
                if (user.Id > MaxId)
                    MaxId = user.Id;
            }
            b.Id = MaxId + 1;
            users.Add(b);

            using (StreamWriter sw = new StreamWriter(UserPath))
            {
                sw.Write(JsonConvert.SerializeObject(users));
            }
        }




      



    }

   

}
