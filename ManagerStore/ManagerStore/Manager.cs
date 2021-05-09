using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class Manager
    {
        private GUIConsole UI = new GUIConsole();
        private List<Bill> list = new List<Bill>();
        private void InputNBill()
        {
            UI.clearScreen(17, 3, 85, 26);
            Console.SetCursorPosition(22, 6);
            Console.Write("Mời bạn nhập số hóa đơn: ");
            int count = int.Parse(Console.ReadLine());
            int xPoint = 23;
            int yPoint = 9;
            for (int i = 0; i < count; i++)
            {
                UI.clearScreen(17, 7, 85, 22);
                xPoint = 23;
                yPoint = 8;
                Console.SetCursorPosition(xPoint, yPoint++);
                Console.Write("Mời bạn nhập hóa đơn thứ " + (i + 1));
                Bill b = new Bill();
                b.input(ref xPoint, ref yPoint);
                list.Add(b);
            }
        }
        
        private void OutputBill()
        {
            if (list.Count == 0)
            {
                UI.clearScreen(17, 3, 85, 26);
                Console.SetCursorPosition(22, 6);
                Console.Write("Không có Bill nào ở đây, trở lại Menu nhấn Enter ");
                Console.ReadLine();
            }
            else
            {
                UI.clearScreen(17, 3, 85, 26);
                Console.SetCursorPosition(22, 5);
                Console.Write("Bấm trái phải để qua lại giữa các bill.");
                Console.SetCursorPosition(22, 6);
                Console.Write("Bấm lên xuống để xem thêm các chi tiết nếu có");
                Console.SetCursorPosition(22, 7);
                Console.Write("Để về Menu bấm ENTER");
                int indexBill = 0;
                int choiceinBill = 0;
                UI.printBill(choiceinBill, list[indexBill],indexBill,list.Count);
                eventOutput(ref indexBill, ref choiceinBill);
            }
        }
        public void OutputFile()
        {
            if (list.Count == 0)
            {
                UI.clearScreen(17, 3, 85, 26);
                Console.SetCursorPosition(22, 6);
                Console.Write("Không có Bill nào ở đây, trở lại Menu nhấn Enter ");
                Console.ReadLine();
            }
            else
            {
                UI.clearScreen(17, 3, 85, 26);
                int xPoint = 22;
                int yPoint = 5;
                IOFile file = new IOFile();
                string[][] message = new string[list.Count][];
                for(int i = 0; i < list.Count; i++)
                {
                    message[i] = list[i].toString();
                }
                file.write(message, ref xPoint, ref yPoint);
            }
        }
        public void eventOutput(ref int indexBill, ref int choiceInBill)
        {
            ConsoleKeyInfo info = Console.ReadKey(true);
            if (info.Key == ConsoleKey.Enter)
                return;
            else if (info.Key == ConsoleKey.UpArrow || info.Key == ConsoleKey.W)
            {
                choiceInBill--;
                UI.clearScreen(17, 20, 85, 14);
                UI.printBill(choiceInBill, list[indexBill], indexBill, list.Count);
            }
            else if (info.Key == ConsoleKey.DownArrow || info.Key == ConsoleKey.S)
            {
                choiceInBill++;
                UI.clearScreen(17, 20, 85, 14);
                UI.printBill(choiceInBill, list[indexBill], indexBill, list.Count);
            }
            else if (info.Key == ConsoleKey.LeftArrow || info.Key == ConsoleKey.A)
            {
                if (indexBill != 0)
                    indexBill--;
                else
                    indexBill = list.Count - 1;
                UI.clearScreen(17, 8, 85, 28);
                UI.printBill(choiceInBill, list[indexBill], indexBill, list.Count);
            }
            else if (info.Key == ConsoleKey.RightArrow || info.Key == ConsoleKey.D)
            {
                if (indexBill != list.Count - 1)
                    indexBill++;
                else
                    indexBill = 0;
                UI.clearScreen(17, 8, 85, 28);
                UI.printBill(choiceInBill, list[indexBill], indexBill, list.Count);
            }
            eventOutput(ref indexBill,ref choiceInBill);
        }
        private void switchMenu(int choice)
        {
            bool exit = false;
            switch (choice)
            {
                case 1:
                    InputNBill();
                    break;
                case 2:
                    OutputBill();
                    break;
                case 3:
                    OutputFile();
                    break;
                default:
                    exit = true;
                    break;
            }
            if (exit == false)
            {
                UI.clearScreen(17, 3, 85, 33);
                UI.printMenu(50, 5);
                int option = 1;
                eventMenu(ref option);
                switchMenu(option);                
            }
        }
        
        public void eventMenu(ref int choice)
        {
            ConsoleKeyInfo info = Console.ReadKey(true);
            if (info.Key == ConsoleKey.Enter)
            {
                switchMenu(choice);
                return;
            }
            else if (info.Key == ConsoleKey.UpArrow || info.Key == ConsoleKey.W)
            {
                UI.moveUpMenu(ref choice, 50, 5);
            }
            else if (info.Key == ConsoleKey.DownArrow || info.Key == ConsoleKey.S)
            {
                UI.moveDownMenu(ref choice, 50, 5);
            }
            eventMenu(ref choice);
        }
    }
}
