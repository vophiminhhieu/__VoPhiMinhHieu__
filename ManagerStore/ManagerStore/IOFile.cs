using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManagerStore
{
    class IOFile
    {
        public void write(string[][] message,ref int xPoint,ref int yPoint)
        {
            try
            {
                Console.SetCursorPosition(xPoint, yPoint + 1);
                Console.Write("  Ví dụ: D:/bill.txt");
                Console.SetCursorPosition(xPoint, yPoint);
                Console.Write("Mời bạn nhập đường dẫn file: ");
                int LengthMessage=0;
                for (int i = 0; i < message.Length; i++)
                {
                    LengthMessage += message[i].Length;
                }
                string[] convertMessage = new string[LengthMessage];
                int index = 0;
                for (int i = 0; i < message.Length; i++)
                {
                    for(int j = 0; j < message[i].Length; j++)
                    {
                        convertMessage[index] = message[i][j];
                        index++;
                    }
                }
                System.IO.File.WriteAllLines(@Console.ReadLine(),convertMessage);
            }
            catch
            {
                Console.SetCursorPosition(xPoint, yPoint);
                Console.Write("                                                  ");
                Console.SetCursorPosition(xPoint, yPoint+2);
                Console.Write(" !!! Bạn nhập đường dẫn không hợp lệ. Nhập lại");
                write(message, ref xPoint, ref yPoint);
                return;
            }
            Console.SetCursorPosition(xPoint, yPoint + 1);
            Console.Write(" Đã lưu xuống file thành công !!!                 ");
            Console.ReadLine();
            Console.SetCursorPosition(xPoint, yPoint + 2);
            Console.Write("                                                  ");
            yPoint++;
        }
    }
}
