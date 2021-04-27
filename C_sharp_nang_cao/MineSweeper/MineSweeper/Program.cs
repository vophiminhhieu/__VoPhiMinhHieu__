using System;

// Võ Phi Minh Hiếu
// Thuật toán dò mìn có dùng đệ quy



namespace MineSweeper
{
    class Program
    {
        static void clearScreen()
        {
            Console.SetCursorPosition(55, 1);
            Console.Write("   ");
            Console.SetCursorPosition(55, 2);
            Console.Write("   ");
        }
        static void Main(string[] args)
        {
            int size = 10;
            int countBoom = 9;
            Board board = new Board(size, countBoom);
            board.prepareGame();
            board.print();
            bool check = true;

            bool[][] tmp = new bool[size][];
            for (int i = 0; i < size; i++)
            {
                tmp[i] = new bool[size];
                for (int j = 0; j < size; j++)
                {
                    tmp[i][j] = true;
                }
            }
            while (check)
            {
                Console.SetCursorPosition(40, 1);
                Console.Write("Moi ban nhap x: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.SetCursorPosition(40, 2);
                Console.Write("Moi ban nhap y: ");
                int y = Convert.ToInt32(Console.ReadLine());
                check = board.check(x, y);
                board.draw(x, y, check,tmp);
                if (check == true)
                {
                    board.getSpaceOneNode(x, y, tmp);
                }
                clearScreen();
                if (board.checkWin(tmp))
                {
                    Console.SetCursorPosition(40, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("YOU WIN");
                    return;
                }
            }
            Console.SetCursorPosition(40, 5);
            Console.Write("You Lose!!!!!!");
            Console.SetCursorPosition(0,size+5 );
        }
    }
}
