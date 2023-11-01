using System;

namespace Homework_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Привет! Введи любое предложение:");
            Console.ResetColor();

            string text = Console.ReadLine();

            string str = ReverseWords(text);

            Console.WriteLine(str);
        }

        static string ReverseWords(string text)
        {
            string[] words = Split(text);
            Array.Reverse(words);

            return String.Join(" ", words);
        }

        static string[] Split(string text)
        {
            return text.Trim().Split(" ");
        }
    }
}
