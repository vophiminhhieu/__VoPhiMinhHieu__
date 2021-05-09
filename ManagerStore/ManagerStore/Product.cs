using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    abstract class Product : IIOConsole,ITryCatchInputInteger
    {
        protected string id;
        protected string name;
        protected string provider;
        protected double cost;
        protected int count;
        public string typeProduct;
        abstract protected void calCost();
        abstract public string toString();
        public int ConsoleReadlineInteger()
        {
            int xPoint = Console.CursorLeft;
            int yPoint = Console.CursorTop;
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.SetCursorPosition(xPoint, yPoint + 1);
                Console.WriteLine("Bạn nhập hợp lệ.Nhập lại nha");
                Console.SetCursorPosition(xPoint, yPoint);
                Console.Write("                                    ");
                Console.SetCursorPosition(xPoint, yPoint);
                return ConsoleReadlineInteger();
            }
            Console.SetCursorPosition(xPoint, yPoint + 1);
            Console.Write("                                      ");
            Console.SetCursorPosition(xPoint, yPoint + 1);
            return a;
        }
        public virtual void input(ref int xPoint, ref int yPoint)
        {
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("Mời bạn nhập mã sản phẩm: ");
            id = Console.ReadLine();
            Console.SetCursorPosition(xPoint, yPoint + 1);
            Console.Write("Mời bạn nhập tên sản phẩm: ");
            name = Console.ReadLine();
            Console.SetCursorPosition(xPoint, yPoint + 2);
            Console.Write("Mời bạn nhập nơi sản xuất: ");
            provider = Console.ReadLine();
            Console.SetCursorPosition(xPoint, yPoint + 3);
            Console.Write("Mời bạn nhập số lượng: ");
            count = ConsoleReadlineInteger();
            yPoint = yPoint + 4;
        }
        public virtual void output(ref int xPoint, ref int yPoint)
        {
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Mã sản phẩm: "+id);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Tên sản phẩm: " + name);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Loại sản phẩm: " + typeProduct);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Nơi sản xuất: "+provider);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Số lượng: " + count);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Tổng giá: " + cost);
        }
        public double getCost()
        {
            return cost;
        }
    }
}
