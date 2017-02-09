using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class Field
    {
        public static int Rows { get; private set; }
        public static int Columns { get; private set; }
        public static char[,] Cells { get; private set; }

        public static bool IsInitialized;
        static Field()
        {
            IsInitialized = false;
        }
        public static void Initialize(int rows, int columns)
        {
            if (!IsInitialized)
            {
                Rows = rows;
                Columns = columns;
                Cells = new char[Rows, Columns];
                Clear();
                IsInitialized = true;
            }
            else
                Console.WriteLine("Field is already initialized."); 
        }

        private static void Clear()
        {
            for (int i = 0; i < Rows-1; i++)
            {
                for (int j = 0; j < Columns-1; j++)
                {
                    Cells[i, j] = ' ';
                }
                Cells[i, Columns-1] = '*';
            }
            for (int i = 0; i < Columns; i++)
            {
                Cells[Rows-1, i] = '*';
            }
        }

        public static void LocateThings(Snake snake)
        {
            LocateSnake(snake);
            LocateFood();
        }

        private static void LocateSnake(Snake snake)
        {
            Clear();
            var body = snake.Body;
            foreach (var block in body)
            {
                Cells[block.Row, block.Column] = snake.Symbol;
            }
        }

        private static void LocateFood()
        {
            Cells[Bonus.Row, Bonus.Column] = Bonus.Symbol;
        }
    }
}
