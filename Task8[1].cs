using System;
using System.Collections.Generic;
using System.Collections; // ArrayList - Хоба [list]  
using System.Linq;




namespace Tasks8
{
    class Program
    {
        static void Main()
        {

            List<User> users = new List<User>
            {
                new User("Valera", "Donbass@mail.ru", 54),
                new User("Lolita", "none", 89),
                new User("Jackie", "male@.male", 35),
                new User("Antoxa", "AntoxaNagib1337@mai.ru", 13),
                new User("Blind Joe", "jnsdkjng#gmail.com", 63)

            };


            // from user in users where user.age > 13 && user.mail.Contains('@') select user;

            var selection = users.Where(user => user.age > 13 && user.mail.Contains("@")).ToList();

            Console.WriteLine("Verified users");

            foreach(var e in selection)
            {
                Console.WriteLine($"Name: {e.name} Email: {e.mail} Age: {e.age}");
            }

            Console.ReadKey();
        }

	}

    /*  
        Объявить тип User содержащий:
        • Имя пользователя
        • Возраст
        • Почтовый адрес
        • Конструктор с параметрами

        Создать коллекцию из 5 пользователей

        [Использовать LINQ]
        Создать List<User>, в который добавить только пользователей старше 13 лет и почтовые ящики у которых содержат символ @
    */


    struct User
    {
        public readonly string name;

        public readonly uint age;

        public readonly string mail;

        public User(string name, string mail, uint age)
        {
            this.name = name;
            this.age = age;
            this.mail = mail; 
        }
    }

}
