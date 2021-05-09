using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class GUIConsole
    {
        public void printFrame(int xStart, int yStart, int xLength, int yLength)
        {
            Console.SetCursorPosition(xStart, yStart);
            for (int i = 0; i < xLength; i++)
            {
                Console.Write("$");
            }
            Console.SetCursorPosition(xStart, yStart + yLength - 1);
            for (int i = 0; i < xLength; i++)
            {
                Console.Write("$");
            }
            for (int i = 0; i < yLength; i++)
            {
                Console.SetCursorPosition(xStart, yStart + i);
                Console.Write("$");
                Console.SetCursorPosition(xStart + xLength - 1, yStart + i);
                Console.Write("$");
            }
        }

        public void printMenu(int xStart, int yStart)
        {
            Console.SetCursorPosition(xStart + 6, yStart+1);
            Console.Write("Quản lý hóa đơn");
            Console.SetCursorPosition(xStart, yStart + 6);
            Console.Write(" Nhập danh sách N hóa đơn");
            Console.SetCursorPosition(xStart, yStart + 10);
            Console.Write(" Xuất danh sách N hóa đơn");
            Console.SetCursorPosition(xStart, yStart + 14);
            Console.Write("  Lưu danh sách hóa đơn");
            Console.SetCursorPosition(xStart, yStart + 18);
            Console.Write(" Thoát chương trình");
            Console.SetCursorPosition(xStart - 9, yStart + 6);
            Console.Write(">>>");
            Console.SetCursorPosition(xStart + 32, yStart + 6);
            Console.Write("<<<");
            Console.SetCursorPosition(0, 39);
        }

        public void moveUpMenu(ref int choice, int xStart, int yStart)
        {
            Console.SetCursorPosition(xStart - 9, yStart + 2 + 4 * choice);
            Console.Write("   ");
            Console.SetCursorPosition(xStart + 32, yStart + 2 + 4 * choice);
            Console.Write("   ");
            if (choice == 1)
            {
                choice = 4;
            }
            else
            {
                choice--;
            }
            Console.SetCursorPosition(xStart - 9, yStart + 2 + 4 * choice);
            Console.Write(">>>");
            Console.SetCursorPosition(xStart + 32, yStart + 2 + 4 * choice);
            Console.Write("<<<");
            Console.SetCursorPosition(0, 33);
        }

        public void moveDownMenu(ref int choice, int xStart, int yStart)
        {
            Console.SetCursorPosition(xStart - 9, yStart + 2 + 4 * choice);
            Console.Write("   ");
            Console.SetCursorPosition(xStart + 32, yStart + 2 + 4 * choice);
            Console.Write("   ");
            if (choice == 4)
            {
                choice = 1;
            }
            else
            {
                choice++;
            }
            Console.SetCursorPosition(xStart - 9, yStart + 2 + 4 * choice);
            Console.Write(">>>");
            Console.SetCursorPosition(xStart + 32, yStart + 2 + 4 * choice);
            Console.Write("<<<");
            Console.SetCursorPosition(0, 33);
        }

        public void clearScreen(int xStart, int yStart, int xLength, int yLength)
        {
            for (int i = 0; i < yLength; i++)
            {
                Console.SetCursorPosition(xStart, yStart + i);
                for (int j = 0; j < xLength; j++)
                {
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        public void printBill(int option,Bill bill,int indexBill,int count)
        {
            int x = 22;
            int y = 10;
            Console.SetCursorPosition(22, 9);
            Console.Write("*****************  Hóa đơn "+(indexBill+1)+"/"+(count)+"  ****************");
            bill.output(ref x,ref y);
            bill.printProduct(ref x, ref y, option);
        }


    }
}
