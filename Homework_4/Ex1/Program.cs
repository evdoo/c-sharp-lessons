using System;

namespace Homework_4
{
    public class MatrixProgram
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Задание 1");
            Console.ResetColor();
            Console.WriteLine("Привет!");

            int n = GetMatrixDimention("Введи количество строк в матрице: ");
            int m = GetMatrixDimention("Введи количество столбцов в матрице: ");

            int[,] matrix = CreateRandomMatrix(n, m);

            long sum = 0;

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum += matrix[i, j];
                    Console.Write($"{matrix[i, j], 3}");
                }
                Console.Write("\n");
            }

            Console.WriteLine();
            Console.WriteLine($"Сумма всех элементов матрицы = {sum}");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Задание 2");
            Console.ResetColor();

            int[,] secondMatrix = MatrixProgram.CreateRandomMatrix(n, m);

            int[,] sumMatrix = new int[n, m];

            Console.WriteLine("Исходные матрицы:");
            Console.WriteLine();

            string firstMatrixLine;
            string secondMatrixLine;

            for (int i = 0; i < n; i++)
            {
                firstMatrixLine = "";
                secondMatrixLine = "";

                for (int j = 0; j < m; j++)
                {
                    sumMatrix[i, j] = matrix[i, j] + secondMatrix[i, j];

                    firstMatrixLine += $"{matrix[i, j], 3}";
                    secondMatrixLine += $"{secondMatrix[i, j], 3}";
                }

                Console.WriteLine($"{firstMatrixLine}\t\t{secondMatrixLine}");
            }
            
            Console.WriteLine();
            Console.WriteLine("Матрица результата сложения:");
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{sumMatrix[i, j], 4}");
                }
                Console.Write("\n");
            }

        }

        static int GetMatrixDimention(String explainMessage)
        {
            while (true)
            {
                try
                {
                    Console.Write(explainMessage);
                    int dimention = int.Parse(Console.ReadLine());
                    if (dimention > 0)
                    {
                        return dimention;
                    }
                    else
                    {
                        Console.WriteLine("Число должно быть положительным. Попробуй еще раз");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Число должно быть целым. Попробуй еще раз");
                }
            }
        }

        public static int[,] CreateRandomMatrix(int str, int column)
        {
            int[,] matrix = new int[str, column];
            Random random = new Random();

            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = random.Next(100);
                }
            }

            return matrix;
        }
    }
}