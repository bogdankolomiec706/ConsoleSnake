using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Field.Initialize(15,50);
            Snake snake = new Snake(10, 10, 3, 'X');
            Bonus.Generate('$');
            while (!snake.isBodyCollision)
            {
                Bonus.Generate();
                Field.LocateThings(snake);
                ConsoleHandler.Display(snake);
            }
            Console.WriteLine("Game finished.");
        }
    }
}


