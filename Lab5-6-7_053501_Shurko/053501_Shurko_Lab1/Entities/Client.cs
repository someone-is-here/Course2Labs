using System;
using System.Collections.Generic;
using System.Text;

namespace _053501_Shurko_Lab1.Entities {
    class Client {
        protected Random rand = new Random();
        private String name;
        private String surname;
        private int age;
        private String phoneNumber;
        private bool hasRoom;
        public String Name { get; set; }
        public String Surname { get; set; }
        public String PhoneNumber { get; set; }
        public int Age { get; set; }
        public bool HasRoom { get; set; }
        public Client() {
            GenerateInfo();
        }
        public Client(String name, String surname, int age, String phoneNumber) {
            Name = name;
            Surname = surname;
            Age = age;
            PhoneNumber = phoneNumber;
        }
        protected void GenerateInfo() {
            String[] names = { "Alexsandr", "Alexey", "Anna", "Daniil", "Dmitry", "Uliana", "Angelina", "Daniela", "Veronika", "Anastasia", "Matvey" };
            StringBuilder gen = new StringBuilder(rand.Next(3,13));
            for (int i = 0; i < gen.Capacity; i++) {
                gen.Append((char)rand.Next('a', 'z' + 1));
            }
            Name = names[rand.Next(names.Length)];
            Surname = gen.ToString();
            Age = rand.Next(110);
            gen.Clear();
            gen.Append("+375");
            for (int i = 0; i < 9; i++) {
                gen.Append(i.ToString());
            }
            PhoneNumber = gen.ToString();
            gen.Clear();
        }
        public void AddClient() {
            Console.WriteLine("Enter your name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter your surname: ");
            Surname = Console.ReadLine();
            Console.WriteLine("Enter your age: ");
            Age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter your mobile phone number: ");
            PhoneNumber = Console.ReadLine();
        }
    }
}
