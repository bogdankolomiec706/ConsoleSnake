using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public List<Block> Body { get; set; }
        public int Lenght { get; private set; }
        public char Symbol { get; private set; }
        public Direction CurrentDirection { get; private set; }
        public bool isBodyCollision { get; private set; }
        public Snake(int startRow, int startColumn, int startLength, char symbol)
        {
            Body = new List<Block>();
            Symbol = symbol;
            isBodyCollision = false;

            CurrentDirection = Direction.Right;

            Grow(startRow, startColumn);
            if (startLength > 1)
            {
                for (int i = 0; i < startLength; i++)
                {
                    Grow();   
                }
            }

        }

        public void Grow()
        {
            Block last = Body.Last();
            switch (CurrentDirection)
            {
                case Direction.Up:
                    Grow(last.Row + 1, last.Column);
                    break;
                case Direction.Down:
                    Grow(last.Row - 1, last.Column);
                    break;
                case Direction.Left:
                    Grow(last.Row, last.Column + 1);
                    break;
                case Direction.Right:
                    Grow(last.Row, last.Column - 1);
                    break;
            }
        }

        private void Grow(int row, int column)
        {
            Block block = new Block(Body.Count, row, column, Symbol);
            Body.Add(block);
            Lenght = Body.Count;
        }

        private bool SetDirection(ConsoleKey key)
        {
            Direction prevDirection = CurrentDirection;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    CurrentDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    CurrentDirection = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    CurrentDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    CurrentDirection = Direction.Down;
                    break;
            }

            bool left_right = (prevDirection == Direction.Left && CurrentDirection == Direction.Right);
            bool right_left = (prevDirection == Direction.Right && CurrentDirection == Direction.Left);
            bool up_down = (prevDirection == Direction.Up && CurrentDirection == Direction.Down);
            bool down_up = (prevDirection == Direction.Down && CurrentDirection == Direction.Up);

            if (!left_right && !right_left && !up_down && !down_up)
            {
                return true;
            }
            return false;
        }

        private bool CheckCollisionWithFood()
        {
            Block head = Body.Single(b => b.N == 0);
            if (head.Row == Bonus.Row && head.Column == Bonus.Column)
            {
                Bonus.isColision = true;
                Grow();
            }
            return Bonus.isColision;
        }

        private bool CheckCollisionWithBody()
        {
            Block head = Body.Single(b => b.N == 0);
            List<Block> otherPart = Body.Except(new Block[] {head}).ToList();

            foreach (var block in otherPart)
            {
                if (block.Row == head.Row && block.Column == head.Column)
                    isBodyCollision = true;
            }
            return isBodyCollision;
        }

        public void Move(ConsoleKey key)
        {
            bool res = SetDirection(key);
            if (res)
            {
                Block[] body = Body.OrderBy(b => b.N).ToArray();
                for (int i = Body.Count - 1; i >= 0; i--)
                {
                    if (body[i].N == 0)//head
                    {
                        switch (CurrentDirection)
                        {
                            case Direction.Left:
                                body[i].Move(newColumn: body[i].Column - 1);
                                break;
                            case Direction.Right:
                                body[i].Move(newColumn: body[i].Column + 1);
                                break;
                            case Direction.Up:
                                body[i].Move(newRow: body[i].Row - 1);
                                break;
                            case Direction.Down:
                                body[i].Move(newRow: body[i].Row + 1);
                                break;
                        }

                        CheckCollisionWithFood();
                        CheckCollisionWithBody();
                    }
                    else//other part
                    {
                        body[i].Move(body[i - 1].Row, body[i - 1].Column);
                    }
                }
            }

        }
    }
}
