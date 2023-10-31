using System;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приветствую тебя в игре \"21\"!");
            bool isInt = false;
            int cardCount = 0;

            while (!isInt)
            {
                try
                {
                    Console.WriteLine("Скажи, сколько у тебя на руках карт:");
                    cardCount = int.Parse(Console.ReadLine());
                    isInt = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Извини, количество некорректно. Попробуй еще раз.");
                }
            }

            int sum = 0;
            String values = ".1.2.3.4.5.6.7.8.9.J.Q.K.T.";

            for (int i = 1; i <= cardCount; i++)
            {
                bool isContains = false;
                String card = null;
                while (!isContains)
                {
                    Console.WriteLine($"Введи номинал {i}-й карты:");
                    card = Console.ReadLine();
                    if (!values.Contains(card))
                    {
                        Console.WriteLine("Извини, я не знаю такую карту :( Пожалуйста, попробуй еще раз.");
                    } else
                    {
                        isContains = true;
                    }
                }

                switch (card)
                {
                    case "J":
                    case "Q":
                    case "K":
                    case "T":
                        sum += 10;
                        break;
                    default:
                        int a = int.Parse(card);
                        sum += a;
                        break;
                }
            }

            Console.WriteLine($"Сумма карт: {sum}");
            Console.ReadLine();
        }
    }
}