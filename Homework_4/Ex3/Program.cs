using System;

namespace Homework_4
{
    class Program
    {
        private const int MaxHeigth = 30;
        private const int MaxWidth = 30;

        private static int cursorPositionX;
        private static int cursorPositionY;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Привет! Это игра \"Жизнь\"");
            int width = GetCellsDimention("Введи количество строк в матрице с клетками, не большее " + MaxWidth + ":", MaxWidth);
            int heigth = GetCellsDimention("Введи количество столбцов в матрице с клетками, не большее " + MaxHeigth + ":", MaxHeigth);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Дальше будет симуляция роста клеток в матрице (чашке Петри). Она бесконечная. Чтобы выйти из симуляции, нажми Esc");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;

            cursorPositionX = Console.CursorLeft;
            cursorPositionY = Console.CursorTop;

            CellsColony colony = new CellsColony(width, heigth);
            colony.Draw();
            System.Threading.Thread.Sleep(700);

            do
            {
                while (!Console.KeyAvailable)
                {
                    colony.Evolve();
                    Console.SetCursorPosition(cursorPositionX, cursorPositionY);
                    colony.Draw();
                    System.Threading.Thread.Sleep(700);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static int GetCellsDimention(string explainMessage, int maxDimention)
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(explainMessage);
                    Console.ForegroundColor = ConsoleColor.White;
                    int dimention = int.Parse(Console.ReadLine());
                    if (dimention > 0 && dimention <= maxDimention)
                    {
                        return dimention;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Число должно быть положительным, и не больше " + maxDimention + ". Попробуй еще раз");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Число должно быть положительным, и не больше " + maxDimention + ". Попробуй еще раз");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }

    class CellsColony
    {
        private bool[,] cells;
        private int width;
        private int heigth;

        public CellsColony(int _width, int _heigth)
        {
            width = _width;
            heigth = _heigth;
            cells = new bool[_width, _heigth];

            Random random = new Random();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    cells[i, j] = random.NextDouble() >= 0.5;
                }
            }
        }

        public void Draw()
        {
            string s;

            for (int i = 0; i < width; i++)
            {
                s = "";
                for (int j = 0; j < heigth; j++)
                {
                    s += cells[i, j] ? "x" : ".";
                }
                Console.WriteLine(s.Trim());
            }
        }

        public void Evolve()
        {
            /**
             * Правила (классическая игра "Жизнь", взяты из википедии):
             *  1. В пустой (мёртвой) клетке, с которой соседствуют три живые клетки, зарождается жизнь;
             *  2. Если у живой клетки есть две или три живые соседки, то эта клетка продолжает жить;
             *  3. Если живых соседей меньше двух или больше трёх, клетка умирает («от одиночества» или «от перенаселённости»).
             *  
             *  Я предположила, что у нас все клетки умирают или рождаются одновременно, поэтому понадобилось ввести дополнительную матрицу вместо замены текущей.
            **/
            bool[,] newCells = new bool[width, heigth];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    int aliveNeighbors = GetNeighborsCount(i, j);

                    if (aliveNeighbors == 3)
                    {
                        newCells[i, j] = true;
                    }
                    else if (aliveNeighbors == 2 && cells[i, j])
                    {
                        newCells[i, j] = true;
                    }
                    else
                    {
                        newCells[i, j] = false;
                    }
                }
            }

            cells = newCells;
        }

        private int GetNeighborsCount(int cellX, int cellY)
        {
            int aliveNeighbors = 0;

            for (int i = cellX - 1; i <= cellX + 1; i++)
            {
                for (int j = cellY - 1; j <= cellY + 1; j++)
                {
                    try
                    {
                        if (cells[i, j])
                        {
                            aliveNeighbors++;
                        }
                    }
                    catch (Exception e) { }
                }
            }
            if (cells[cellX, cellY])
            {
                return aliveNeighbors - 1;
            }
            else
            {
                return aliveNeighbors;
            }
        }
    }
}