using System;

namespace Homework_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Привет! Введи любую строку (лучше с пробелами):");
            Console.ResetColor();

            string text = Console.ReadLine();

            string[] wordsArray = SplitText(text);

            PrintWords(wordsArray);
        }

        static string[] SplitText(string text)
        {
            if (text.Equals(""))
            {
                return new string[1] { "Ты ввел пустую строку. Слов в ней нет, выводить нечего" };
            }

            int spaceCount = 0;

            for (int i = 0; i < text.Length; i++)
            {   
                if (text[i].Equals(' ') && i - 1 >= 0 && !text[i - 1].Equals(' '))
                {
                    spaceCount++;
                }
            }

            string[] words = new string[spaceCount + 1];
            int arrayIndex = 0;
            string word = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (!text[i].Equals(' '))
                {
                    word += text[i];
                    if (i == text.Length - 1)
                    {
                        words[arrayIndex] = word;
                    }
                } else
                {
                     if (i - 1 >= 0 && !text[i - 1].Equals(' '))
                    {
                        words[arrayIndex] = word;
                        word = "";
                        arrayIndex++;
                    }
                }
            }

            return words;
        }

        static void PrintWords(string[] words)
        {
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
