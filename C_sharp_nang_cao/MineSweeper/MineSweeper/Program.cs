using System;
using System.Text;

// Võ Phi Minh Hiếu
// Thuật toán dò mìn có dùng đệ quy




namespace MineSweeper
{
    class Program
    {
        static void prepare()
        {
            Console.SetCursorPosition(45, 2);
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Hướng dẫn các phím sử dụng trong Tò Chơi");
            Console.SetCursorPosition(45, 4);
            Console.Write("Các phím mũi tên để di chuyển. Để mở ô nhấn [ENTER]");
            Console.SetCursorPosition(45, 5);
            Console.Write("Bạn nghi ngờ nó làm boom, bạn có thể nhấn [B]");
            Console.SetCursorPosition(45, 6);
            Console.Write("Bạn chơi quá 3 tiếng ? Mời bạn nhấn [ESC] để thoát");
        }
        static void print_Ban_()
        {
            Console.ForegroundColor = ConsoleColor.White;
            char c = (char)35;
            Console.SetCursorPosition(45, 8);
            Console.Write(c+""+c+""+c+"      "+c+"     "+c+""+c+""+c+""+c+""+c);
            Console.SetCursorPosition(45, 9);
            Console.Write(c+"  "+c+"    "+c+" "+c+"    "+c+"   "+c);
            Console.SetCursorPosition(45, 10);
            Console.Write(c + "" + c + "" + c+"    "+c+"   "+c+"   "+c + "   " + c);
            Console.SetCursorPosition(45,11);
            Console.Write(c+"  "+c+"  "+c+"  "+c+"  "+c+"  "+c + "   " + c);
            Console.SetCursorPosition(45, 12);
            Console.Write(c + "" + c + "" + c+"  "+c+"       "+c+" "+c + "   " + c);
        }
        static void printWin()
        {
            print_Ban_();
            char c = (char)35;
            Console.SetCursorPosition(70, 8);
            Console.Write(c + "         " + c+"  "+c+"  "+c+""+c+""+c+""+c+""+c);
            Console.SetCursorPosition(70, 9);
            Console.Write(c+"         "+c+"     "+c+"   "+c);
            Console.SetCursorPosition(71, 10);
            Console.Write(c+"   "+c+"   "+c+"   "+c+"  "+c+"   "+c);
            Console.SetCursorPosition(72, 11);
            Console.Write(c+" "+c+" "+c+" "+c+"    "+c + "  " + c + "   " +c);
            Console.SetCursorPosition(73, 12);
            Console.Write(c+"   "+c+"     "+c + "  " + c + "   " +c);
            Console.SetCursorPosition(45, 14);
        }
        static void printLose()
        {
            print_Ban_();
            char c = (char)35;
            Console.SetCursorPosition(70, 8);
            Console.Write(c +"    "+c+""+c+""+c+""+c+" "+c+""+c+""+c+""+c+" "+ c + "" + c + "" + c + "" + c);
            Console.SetCursorPosition(70, 9);
            Console.Write(c + "    " + c + "  " + c+" "+c+"    "+c);
            Console.SetCursorPosition(70, 10);
            Console.Write(c + "    " + c + "  " + c+" "+c+""+c+""+c+""+c + " " + c + "" + c + "" + c + "" + c);
            Console.SetCursorPosition(70, 11);
            Console.Write(c + "    " + c + "  " + c+"    "+c + " " + c);
            Console.SetCursorPosition(70, 12);
            Console.Write(c+""+c+""+c+""+c+" "+c+""+c+""+c+""+c+" "+c+""+c+""+c+""+c + " " + c + "" + c + "" + c + "" + c);
            Console.SetCursorPosition(45, 14);
        }
        static void Main(string[] args)
        {
            /// Nhap size bang va so boom ///
            Console.Write("Moi ban nhap size bang: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.Write("Moi ban nhap so boom: ");
            int countBoom = Convert.ToInt32(Console.ReadLine());
            if (size > 22)
            {
                size = 22;
            }
            if (countBoom > size * size)
            {
                countBoom = size * size;
            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                             ");
            Console.WriteLine("                             ");
            ////
            ///

            /// Chuẩn bị dữ liệu, data game 
            Board board = new Board(size, countBoom);
            prepare();
            board.prepareGame();
            board.print();
            int x_mouse = 0;
            int y_mouse = 0;
            bool check;
            bool[][] tmp = new bool[size][];
            for (int i = 0; i < size; i++)
            {
                tmp[i] = new bool[size];
                for (int j = 0; j < size; j++)
                {
                    tmp[i][j] = true;
                }
            }
            Control control = new Control();

            ///


            while (control.getEvent() != -1)
            {
                control.listener();
                if (control.getEvent() <=4&&control.getEvent()>=1)
                {
                    control.router(ref x_mouse, ref y_mouse, size);
                }
                else if (control.getEvent() == 6)
                {
                    board.drawFlag(x_mouse, y_mouse,tmp);
                }
                else if (control.getEvent() == 5)
                {
                    check = board.check(y_mouse, x_mouse/2);
                    board.draw(y_mouse, x_mouse/2, check, tmp);
                    if (check == true)
                    {
                        board.getSpaceOneNode(y_mouse, x_mouse/2, tmp);
                    }
                    else
                    {
                        printLose();
                        return;
                    }
                    if (board.checkWin(tmp))
                    {
                        printWin();
                        return;
                    }
                }
            }
        }
    }
}
