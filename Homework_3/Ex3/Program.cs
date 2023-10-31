using System;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет!");
            bool isInt = false;
            int number = 0;

            while (!isInt)
            {
                try
                {
                    Console.WriteLine("Введи число для проверки:");
                    number = int.Parse(Console.ReadLine());
                    isInt = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Некорректное число. Попробуй еще раз.");
                }
            }

            bool isSimple = true;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    isSimple = false;
                }
            }

            Console.WriteLine(isSimple ? "Это число простое" : "Это число не простое");
            Console.ReadLine();
        }
    }
}
