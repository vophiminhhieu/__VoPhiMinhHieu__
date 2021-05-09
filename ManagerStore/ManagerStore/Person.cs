using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    abstract class Person : IIOConsole
    {
        protected string id;
        protected string name;
        protected string address;
        protected string phone;
        public virtual void input(ref int xPoint, ref int yPoint)
        {
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("Mời bạn nhập mã người: ");
            id = Console.ReadLine();
            Console.SetCursorPosition(xPoint, yPoint + 1);
            Console.Write("Mời bạn nhập tên người: ");
            name = Console.ReadLine();
            Console.SetCursorPosition(xPoint, yPoint + 2);
            Console.Write("Mời bạn nhập địa chỉ : ");
            address = Console.ReadLine();
            Console.SetCursorPosition(xPoint, yPoint + 3);
            Console.Write("Mời bạn nhập số điện thoại: ");
            phone = Console.ReadLine();
            yPoint = yPoint + 4;
        }
        public virtual void output(ref int xPoint, ref int yPoint)
        {
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("Mã người: "+id);
            Console.SetCursorPosition(xPoint, yPoint + 1);
            Console.Write("Tên người: "+name);
            Console.SetCursorPosition(xPoint, yPoint + 2);
            Console.Write("Địa chỉ : "+address);
            Console.SetCursorPosition(xPoint, yPoint + 3);
            Console.Write("Số điện thoại: "+phone);
            yPoint = yPoint + 4;
        }
    }
}
