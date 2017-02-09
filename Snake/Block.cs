using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Block
    {
        private int row;
        private int column;

        public char Symbol { get; private set; }
        public int  N { get; private set; }
        public int Row {
            get { return row; }
            private set
            {
                if (value < Field.Rows && value >= 0)
                    row = value;
            }
        }

        public int Column
        {
            get { return column; }
            private set
            {
                if (value < Field.Columns && value >= 0)
                    column = value;
            }
        }
        
        public Block(int n, int row, int column, char symbol)
        {
            N = n;
            Row = row;
            Column = column;
            Symbol = symbol;
        }

        public void Move(int? newRow = null, int? newColumn = null)
        {
            if (newRow != null)
            {
                if(newRow != Row)
                    Row = (int)newRow;
            }
            if (newColumn != null)
            {
                if(newColumn != Column)
                    Column = (int)newColumn;
            }
        }
    }
}
