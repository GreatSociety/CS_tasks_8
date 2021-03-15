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

            DataBase newBase = new DataBase(3);

            Mem(newBase);

            Race raceHuman = new Race("Human");
            Race raceElf = new Race("Elf");
            Race raceGnome = new Race("Gnome");
            Race raceDwarf = new Race("Dwarf");
            Race raceOrk = new Race("Ork");

            newBase.AddPlayers(new Player("Hermione", 15, raceHuman),
                new Player("Harry", 15, raceHuman),
                new Player("Ron", 15, raceHuman)); // 3

            newBase.Print();
            Mem(newBase);

            newBase.AddPlayers(new Player("Dante", 104, raceGnome),
                new Player("Pit", 82, raceDwarf),
                new Player("Virgil", 524, raceElf),
                new Player("Valera", 54, raceOrk),
                new Player("Ron", 22, raceHuman)); // 5


            newBase.Print();
            Mem(newBase);


            newBase.AddPlayers(new Player("John", 104, raceGnome),
                new Player("Harry", 220, raceDwarf),
                new Player("Bill", 14, raceElf),
                new Player("Indro", 54, raceOrk),
                new Player("Kris", 22, raceHuman)); // 5

            newBase.Print();
            Mem(newBase);

            // Список по одной расе
            List<Player> oneRace = newBase.playersBase.Where(player => player.race.Name == raceHuman.Name).ToList();

            listPrint(oneRace);

            // Список по лвл больше 30
            List<Player> levelOF = newBase.playersBase.Where(player => player.age > 30).ToList();

            listPrint(levelOF);

            //Список по первой букве name
            List<Player> letterN = newBase.playersBase.Where(player => player.name[0] == 'V').ToList();

            listPrint(letterN);

            // Список по лвл выше 20 для одной расы и по лвл выше 15 для другой
            List<Player> twoRace = newBase.playersBase.Where(player => (player.race.Name == raceHuman.Name && player.age > 20)
                                                                        || player.race.Name == raceElf.Name && player.age > 15).ToList();
            listPrint(twoRace);

            Console.ReadKey();
        }

        static void Mem(DataBase data)
        {
            Console.WriteLine($"\nNow we have memory for {data.playersBase.Capacity} elements");
            Console.WriteLine($"And we have {data.playersBase.Count} elements with value\n");
        }

        static void listPrint(List<Player> name)
        {
            Console.WriteLine("-----------------------------------");

            foreach (var pl in name)
            {
                Console.WriteLine($"Name: {pl.name}\t Race: {pl.race.Name} \t Level: {pl.age}");
            }
        }

	}


    /*
    Создать структуру Race
    • Свойство Name (только для чтения)
    • Конструктор, инициализирующий Name

    Создать класс Player, содержащий:
    [Информация] Модификаторы доступа и сигнатуру (поле или свойство) выбрать на свое усмотрение
    • Ник
    • Возраст персонажа
    • Раса (тип Race)
    • Конструктор для инициализации полей
    
    Создать класс DataBase
    [Информация] Модификаторы доступа и сигнатуру (поле или свойство) выбрать на свое усмотрение
    • Максимальный размер базы данных (целое число)
    • Коллекция для хранения объектов типа Player
    • Конструктор, инициализирующий максимальный размер базы данных
    • Открытый метод void AddPlayers(X) для добавления игроков. Вместо X — возможность принимать в качестве параметра любое количество объектов типа Player.
        • Учесть в базе данных возможность нехватки места (превышение макс. размера базы)
        • Учесть возможность наличия такого никнейма в базе до его добавления (реализовать с использованием следующего метода)
    • Закрытый метод bool IsNickNameExists(string nickname) возвращающий true если такой ник уже есть в базе, false - иначе

    Main
    • Создать игроков (с произвольными никнеймами, уровнем и расой)
    • Создать базу данных
    • Добавить игроков в базу данных
    [LINQ]
    Сформировать из игроков, находящихся в базе данных, следующие выборки:
    • Игроки одной расы (любая произвольная раса из существующих)
    • Игроки больше X уровня. X выбрать произвольно.
    • Игроки, чьи ники начинаются с определенной (произвольной) буквы
    • Игроки расы X с уровнем не больше чем A и игроки расы Y с уровнем не больше чем B. A, B, X, Y выбрать на свое усмотрение.
*/


    struct Race
    {
        public string Name { get; }

        public Race(string name)
        {
            Name = name;
        }

    }

    class Player
    {
        public readonly string name;

        public readonly uint age;

        public readonly Race race;

        public Player(string name, uint age, Race race)
        {
            this.name = name;
            this.age = age;
            this.race = race; 
        }

    }

    class DataBase
    {
        private readonly int maxInit;

        public List<Player> playersBase = new List<Player>();

        public DataBase(int Max)
        {
            maxInit = Max;

            playersBase.Capacity = maxInit;

        }

        public void AddPlayers(params Player[] players)
        {
            int available = playersBase.Capacity - playersBase.Count();

            // Ну это пародия выделения памяти, она бы и сама смогла. 
            if (available < players.Length)
            {
                Console.WriteLine("\nWait... Allocating memory...\n");

                playersBase.Capacity += players.Length - available;

            }

            foreach (var player in players)
            {
                if (IsNickNameExists(player.name))
                    continue;

                playersBase.Add(player);
            }

        }

        private bool IsNickNameExists(string nickname)
        {
            foreach(var player in playersBase)
            {
                if(nickname == player.name)
                {
                    return true;
                }
            }

            return false;
        }

        public void Print()
        {
            foreach (var players in playersBase)
            {
                Console.WriteLine($"Name: {players.name}\t Race: {players.race.Name} \t Level: {players.age}");
            }
        }

    }

}
