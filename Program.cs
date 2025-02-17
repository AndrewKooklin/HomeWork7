﻿using System;
using System.IO;

namespace HomeWork7 {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Чтение и запись данных о сотрудниках");

            Start();

            Console.WriteLine("\nПрограмма завершена");

            Console.ReadLine();
        }

        static void Start()
        {
            Console.WriteLine("Введите цифру : \n 1 - для чтения данных\n 2 - для записи данных в файл");

            string path = @"Employees.txt";           

            char input = Console.ReadKey().KeyChar;

            if (input == '1')
            {                
                    ReadData(path);                   
            }
            else if (input == '2')
            {
                char key = 'д';

                do {
                    Console.WriteLine();

                    WriteData(path, InputData());

                    Console.WriteLine("Добавить нового сотрудника? н/д");

                    key = Console.ReadKey().KeyChar;
                }
                while (char.ToLower(key) == 'д');                
            }           
        }

        static byte[] InputData()
        {
                string record = "";

                Console.WriteLine("Введите ID сотрудника");
                string id = Console.ReadLine();

                string dCreate = DateTime.Now.ToString("dd.MM.yyyy hh:mm");

                Console.WriteLine("Введите Ф.И.О.");
                string fullName = Console.ReadLine();

                Console.WriteLine("Введите возраст");
                string age = Console.ReadLine();

                Console.WriteLine("Введите рост в см");
                string height = Console.ReadLine();

                Console.WriteLine("Введите дату рождения");
                string dateOfBirth = Console.ReadLine();

                Console.WriteLine("Введите место рождения");
                string placeOfBirth = Console.ReadLine();

                record = id + "#" + dCreate + "#" + fullName + "#" + age + "#" + height + "#" + dateOfBirth + "#" + placeOfBirth + "\n";
                byte[] array = System.Text.Encoding.Default.GetBytes(record);

                return array;          
        }

        static void WriteData(string path, byte[] array) { 

            Console.WriteLine();

            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                fs.Write(array, 0, array.Length);
            }
        }

        static void ReadData(string path)
        {
            Console.WriteLine();

            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];

                fstream.Read(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);

                string[] words = textFromFile.Split('#');

                foreach (var word in words) 
                {                                    
                Console.Write($"{word} ");
                }
            }
        }
    }
}


