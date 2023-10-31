using System;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет!");
            bool isInt = false;
            int count = 0;

            while (!isInt)
            {
                try
                {
                    Console.WriteLine("Введи длину последовательности:");
                    count = int.Parse(Console.ReadLine());

                    if (count <= 0)
                    {
                        Console.WriteLine("В последовательности нет наименьшего элемента");
                        break;
                    }
                    else
                    {
                        isInt = true;

                        Console.WriteLine("Начинай вводить саму последовательность. Числа разделяются клавишей Enter.");
                        int min = int.MaxValue;
                        for (int i = 0; i < count; i++)
                        {
                            bool isRightNumber = false;
                            while (!isRightNumber)
                            {
                                try
                                {
                                    int n = int.Parse(Console.ReadLine());

                                    if (n < min)
                                    {
                                        min = n;
                                    }

                                    isRightNumber = true;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Это не целое число. Попробуй еще раз.");
                                }
                            }
                        }

                        Console.WriteLine($"Минимальный элемент: {min}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Некорректное число. Попробуй еще раз.");
                }
            }
            Console.ReadLine();
        }
    }
}
