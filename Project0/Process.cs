using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project0
{
     static class Process
    {
        static string Path = "C:\\Users\\Togrul\\Desktop\\p3262\\Project0\\Project0\\Files\\Products.json";
        

        public static List<Pizza> GetPizza()
        {
            List<Pizza> pizzaz = new List<Pizza>();
            using (StreamReader sr = new StreamReader(Path))
            {
                pizzaz = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
            }
            return pizzaz;
        }




        public static void AddPizza(Pizza a)
        {
            List<Pizza> pizzaz = GetPizza();
            int MaxId = 1;
            foreach (Pizza pizza in pizzaz)
            {
                if (pizza.Id > MaxId)
                    MaxId = pizza.Id;
            }
            a.Id = MaxId + 1;
            pizzaz.Add(a);

            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.Write(JsonConvert.SerializeObject(pizzaz));
            }
        }

       

    }
}
