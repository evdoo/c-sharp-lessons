using System;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Сыграем в \"Угадай число\"?");
            bool isInt = false;
            int max = 0;

            while (!isInt)
            {
                try
                {
                    Console.WriteLine("Введи целое число - максимальную границу диапазона. А я загадаю число в этом диапазоне.");
                    max = int.Parse(Console.ReadLine());
                    isInt = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Некорректное число. Попробуй еще раз.");
                }
            }

            Random rnd = new Random();
            int number = rnd.Next(max);

            Console.WriteLine("Готово, я загадал число. Ты можешь начать отгадывать.");

            while (true)
            {
                String str = Console.ReadLine();
                if (str.Equals(""))
                {
                    Console.WriteLine($"Я загадал число {number}.");
                    break;
                }
                else
                {
                    try
                    {
                        int userNumber = int.Parse(str);

                        if (userNumber < number)
                        {
                            Console.WriteLine("Загаданное число больше названного.");
                        } else if (userNumber > number)
                        {
                            Console.WriteLine("Загаданное число меньше названного.");
                        } else
                        {
                            Console.WriteLine($"Ура, ты угадал! Я загадал число {number}.");
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Не угадал. Я загадал натуральное число, а не букву.");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
