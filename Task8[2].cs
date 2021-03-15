using System;
using System.Collections.Generic;
using System.Collections;   
using System.Linq;




namespace Tasks8
{
    class Program
    {
        static void Main()
        {
            /*     
                 [Использовать LINQ]

                 Необходимо получить список уникальных (без повторений) доменных имен почтовых ящиков из списка почтовых адресов
                 Доменное имя - правая часть почтового адреса (всё что после @)
            */

            string[] emails = new string[]
            {
                "randommail@mail.ru",
                "someoneshere@gmail.by",
                "jackteller@gmail.com",
                "yellow.brick.records@mail.cz",
                "randommail2@mail.ru",
                "kidywalters999@gmail.com",
                "mail.trueman@mail.cz",
                "sol.goodman@gmail.com",
                "alfick.demon.44@mail.gv.cz"
            };

            var examples = (from domain in emails select domain.Substring(domain.IndexOf("@")+1, domain.Length - (domain.IndexOf("@")+1))).Distinct().ToList();

            foreach(var domain in examples)
            {
                Console.WriteLine("Unique domain: " + domain);
            }

            Console.ReadKey();
        }

	}


}
