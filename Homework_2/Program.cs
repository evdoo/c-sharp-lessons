using System;

namespace Homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            String fullName = "Иванов Иван Иванович";
            int age = 35;
            String email = "ivanov@mail.ru";
            double programmingBalls = 4.7;
            double mathBalls = 5;
            double physicBalls = 3.5;

            Console.WriteLine($"ФИО: {fullName}\nВозраст: {age}\nEmail: {email}\nБаллы:\n- программирование: {programmingBalls}\n- математика: {mathBalls}\n- физика: {physicBalls}");

            // Задание 2
            double sum = programmingBalls + mathBalls + physicBalls;
            double averageBall = sum / 3;

            Console.ReadKey();

            Console.WriteLine($"Средний балл: {averageBall:#.##}");
            Console.ReadKey();
        }
    }
}
