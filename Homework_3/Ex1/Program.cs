using System;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Введи целое число:");
            bool isInt = false;

            while (!isInt) {
                try
                {
                    int n = int.Parse(Console.ReadLine());
                    isInt = true;

                    if (n % 2 == 0)
                    {
                        Console.Write("Четное");
                    } else
                    {
                        Console.Write("Нечетное");
                    }
                } catch (Exception e)
                {
                    Console.WriteLine("Ты ввел не то, что нужно. Попробуй еще раз:");
                }
            }
            Console.ReadLine();
        }
    }
}
