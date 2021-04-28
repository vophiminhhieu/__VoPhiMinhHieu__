using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class Board
    {
        private int size { set; get; }
        private int countBoom { set; get; }
        private int[][] LocationBoom { set; get; }

        private int calculator(int indexX,int indexY)
        {
            int result = 0;

            if (indexX - 1 >= 0 && indexY - 1 >= 0)
            {
                if (LocationBoom[indexX - 1][indexY - 1] == -1) result++;
            }
            if (indexX - 1 >= 0)
            {
                if (LocationBoom[indexX - 1][indexY] == -1) result++;
            }
            if (indexX - 1 >= 0 && indexY + 1 < size)
            {
                if (LocationBoom[indexX - 1][indexY + 1] == -1) result++;
            }
            if (indexY + 1 < size)
            {
                if (LocationBoom[indexX][indexY + 1] == -1) result++;
            }
            if (indexY - 1 >= 0)
            {
                if (LocationBoom[indexX][indexY - 1] == -1) result++;
            }
            if (indexX + 1 < size && indexY + 1 < size)
            {
                if (LocationBoom[indexX + 1][indexY + 1] == -1) result ++;
            }
            if (indexX + 1 < size)
            {
                if (LocationBoom[indexX + 1][indexY] == -1) result++;
            }
            if(indexX+1<size&& indexY - 1 >= 0)
            {
                if (LocationBoom[indexX + 1][indexY - 1] == -1) result++;
            }
            return result;
        }
        private void printNode(int x,int y)
        {
            if (x >= 0 && x < size && y >= 0 && y < size)
            {
                Console.SetCursorPosition(2 * y, x);
                if (LocationBoom[x][y] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (LocationBoom[x][y] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (LocationBoom[x][y] == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (LocationBoom[x][y] == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (LocationBoom[x][y] == 5)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else if (LocationBoom[x][y] == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (LocationBoom[x][y] == 7)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (LocationBoom[x][y] == 8)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                Console.Write(LocationBoom[x][y]);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void prepareGame()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (LocationBoom[i][j] != -1)
                    {
                        LocationBoom[i][j] = calculator(i, j);
                    }
                }
            }
        }
        public bool checkWin(bool[][] tmp)
        {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (tmp[i][j] == false)
                    {
                        count++;
                    }
                }
            }
            if (count == size * size - countBoom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void print()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("# ");
                }
                Console.WriteLine();
            }
        }
        public void drawFlag(int x,int y,bool[][]tmp)
        {
            if (tmp[y][x / 2] == true)
            {
                Console.SetCursorPosition(x, y);
                char c = (char)20;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(c);
            }
        }
        public bool check(int x,int y)
        {
            if (LocationBoom[x][y] == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void getSpaceOneNode(int x,int y,bool[][] check)
        {
            if (LocationBoom[x][y] != 0)
            {
                return;
            }
            if (x - 1 >= 0 && y - 1 >= 0 && check[x-1][y-1]==true)
            {
                printNode(x - 1, y - 1);
                check[x - 1][y - 1] = false;
                getSpaceOneNode(x - 1, y - 1, check);
            }
            if (x - 1 >= 0&&check[x-1][y]==true)
            {
                printNode(x - 1, y);
                check[x - 1][y ] = false;
                getSpaceOneNode(x - 1, y, check);
            }
            if (x-1 >= 0 && y + 1 < size&&check[x-1][y+1]==true)
            {
                printNode(x - 1, y + 1);
                check[x - 1][y + 1] = false;
                getSpaceOneNode(x - 1, y + 1, check);
            }
            if (y + 1 < size && check[x][y+1]==true)
            {
                printNode(x, y + 1);
                check[x][y + 1] = false;
                getSpaceOneNode(x, y + 1, check);
            }
            if (y - 1 >= 0 && check[x][y-1]==true)
            {
                printNode(x, y - 1);
                check[x][y - 1] = false;
                getSpaceOneNode(x, y - 1, check);
            }
            if (x + 1 < size && y + 1 < size && check[x+1][y+1])
            {
                printNode(x + 1, y + 1);
                check[x + 1][y + 1] = false;
                getSpaceOneNode(x + 1, y + 1, check);
            }
            if (x + 1 < size && check[x+1][y]==true)
            {
                printNode(x + 1, y);
                check[x + 1][y] = false;
                getSpaceOneNode(x + 1, y, check);
            }
            if (x + 1 < size && y - 1 >= 0 && check[x+1][y-1])
            {
                printNode(x + 1, y - 1);
                check[x + 1][y - 1] = false;
                getSpaceOneNode(x + 1, y - 1, check);
            }
        }
        public void draw(int x,int y, bool check,bool [][] tmp)
        {
            Console.SetCursorPosition(2 * y, x);
            if (check == true)
            {
                printNode(x, y);
                tmp[x][y] = false;
            }
            else
            {
                Console.Write("X");
            }
        }
        public Board(int _size, int _countBoom)
        {
            size = _size;
            countBoom = _countBoom;
            LocationBoom = new int[_size][];
            for (int i = 0; i < size; i++)
            {
                LocationBoom[i] = new int[_size];
                for (int j = 0; j < size; j++)
                {
                    LocationBoom[i][j] = 0;
                }
            }
            Random _rng = new Random();
            while (_countBoom != 0)
            {
                int _Int = _rng.Next(1, size * size);
                if (LocationBoom[_Int / size][_Int % size] == 0)
                {
                    LocationBoom[_Int / size][_Int % size] = -1;
                    _countBoom = _countBoom - 1;
                }
            }
        }
    }
}
