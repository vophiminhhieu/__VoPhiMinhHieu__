using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MineSweaper_
{
    class Board
    {
        private int [][] board;
        private int countBoom;
        private int getNode(int x,int y)
        {
            if (x < 0 || x > 9 || y < 0 || y > 14)
            {
                return 0;
            }
            return board[x][y];
        }
        private int calculate(int x,int y)
        {
            if (getNode(x, y) == -1)
            {
                return -1;
            }
            int sum = 0;
            for(int i = -1; i <= 1; i++)
            {
                if (getNode(x + i, y - 1) == -1)
                {
                    sum++;
                }
                if (getNode(x + i, y) == -1)
                {
                    sum++;
                }
                if (getNode(x + i, y + 1) == -1)
                {
                    sum++;
                }
                
            }
            return sum;
        }
        private void RandonBoard(int countBoom)
        {
            int count = countBoom;
            Random rng = new Random();
            while (count != 0)
            {
                int _Int = rng.Next(0, 149);
                if (board[_Int / 15][_Int % 15] == 0)
                {
                    board[_Int / 15][_Int % 15] = -1;
                    count--;
                }
            }
        }
        private void prepareCal()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    board[i][j] = calculate(i, j);
                }
            }
        }
        public string MessageBoard()
        {
            string s = "";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    s = s + board[i][j] + " ";
                }
                s = s + "\n";
            }
            return s;
        }
        public int get(int x,int y)
        {
            return board[x][y];
        }
       
        public Board(int level,int numBoom)
        {
            countBoom = level * numBoom;
            board = new int[10][];
            for(int i = 0; i < 10; i++)
            {
                board[i] = new int[15];
                for(int j = 0; j < 15; j++)
                {
                    board[i][j] = 0;
                }
            }
            RandonBoard(countBoom);
            prepareCal();
        }
    }
}
