using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class Customer : Person
    {
        public string getId()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
        public string getAddress()
        {
            return address;
        }
        public string getPhone()
        {
            return phone;
        }
        public override void input(ref int xPoint, ref int yPoint)
        {
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("Mời bạn nhập mã khách hàng: ");
            id = Console.ReadLine();
            Console.SetCursorPosition(xPoint, yPoint + 1);
            Console.Write("Mời bạn nhập tên khách hàng: ");
            name = Console.ReadLine();
            Console.SetCursorPosition(xPoint, yPoint + 2);
            Console.Write("Mời bạn nhập địa chỉ : ");
            address = Console.ReadLine();
            Console.SetCursorPosition(xPoint, yPoint + 3);
            Console.Write("Mời bạn nhập số điện thoại: ");
            phone = Console.ReadLine();
            yPoint = yPoint + 4;
        }
        public override void output(ref int xPoint, ref int yPoint)
        {
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("Mã khách hàng: " + id);
            Console.SetCursorPosition(xPoint, yPoint + 1);
            Console.Write("Tên khách hàng: " + name);
            Console.SetCursorPosition(xPoint, yPoint + 2);
            Console.Write("Địa chỉ : " + address);
            Console.SetCursorPosition(xPoint, yPoint + 3);
            Console.Write("Số điện thoại: " + phone);
            yPoint = yPoint + 4;
        }
    }
}
