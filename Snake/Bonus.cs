using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class Bonus
    {
        public static bool isColision { get; set; }

        private static int row;
        private static int column;

        public static int Row
        {
            get { return row; }
            private set
            {
                if (value < Field.Rows && value >= 0)
                    row = value;
            }
        }

        public static int Column
        {
            get { return column; }
            private set
            {
                if (value < Field.Columns && value >= 0)
                    column = value;
            }
        }

        public static char Symbol { get; private set; }

        static Bonus()
        {
            isColision = false;
        }


        public static void Generate(char symbol)
        {
            Symbol = symbol;
            Generate();
        }

        public static void Generate()
        {
            if (isColision)
            {
                Random rand = new Random();
                Row = rand.Next(0, Field.Rows - 1);
                Column = rand.Next(0, Field.Columns - 1);

                isColision = false;
            }
        }

    }
}
