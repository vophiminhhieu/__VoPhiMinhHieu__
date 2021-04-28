using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class Control
    {
        private int eventKey;
        public Control()
        {
            eventKey = 0;
        }
        public int getEvent()
        {
            return eventKey;
        }
        public void listener()
        {
            ConsoleKeyInfo info = Console.ReadKey(true);
            if (info.Key == ConsoleKey.UpArrow)
            {
                eventKey = 1;
            }
            else if (info.Key == ConsoleKey.DownArrow)
            {
                eventKey = 2;
            }
            else if (info.Key == ConsoleKey.LeftArrow)
            {
                eventKey = 3;
            }
            else if (info.Key == ConsoleKey.RightArrow)
            {
                eventKey = 4;
            }
            else if (info.Key == ConsoleKey.Enter)
            {
                eventKey = 5;
            }
            else if (info.Key == ConsoleKey.B)
            {
                eventKey = 6;
            }
            else if (info.Key == ConsoleKey.Escape)
            {
                eventKey = -1;
            }
            else if (info.Key == ConsoleKey.Y)
            {
                eventKey = 7;
            }
            else if (info.Key == ConsoleKey.N)
            {
                eventKey = 8;
            }
        }
        public void router(ref int x,ref int y,int size)
        {
            if (eventKey == 1)
            {
                if (y == 0)
                {
                    jump(x, size - 1);
                    y = size - 1;
                }
                else
                {
                    jump(x, y - 1);
                    y = y - 1;
                }
            }
            else if (eventKey == 2)
            {
                if (y == size - 1)
                {
                    jump(x, 0);
                    y = 0;
                }
                else
                {
                    jump(x, y + 1);
                    y = y + 1;
                }
            }
            else if (eventKey == 3)
            {
                if (x == 0)
                {
                    jump(2 * size - 2, y);
                    x = 2 * size - 2;
                }
                else
                {
                    jump(x - 2, y);
                    x = x - 2;
                }
            }
            else if (eventKey == 4)
            {
                if (x == 2 * size - 2)
                {
                    jump(0, y);
                    x = 0;
                }
                else
                {
                    jump(x + 2, y);
                    x = x + 2;
                }
            }
        }
        public void jump(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
