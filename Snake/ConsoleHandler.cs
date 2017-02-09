using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class ConsoleHandler
    {
        public static void Display(Snake snake)
        {
            Console.Clear();
            for (int i = 0; i < Field.Rows; i++)
            {
                for (int j = 0; j < Field.Columns; j++)
                {
                    Console.Write(Field.Cells[i, j]);
                }
                Console.WriteLine();
            }
            snake.Move(Console.ReadKey().Key);

        }



    }
}
