using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class AirMachine : Product
    {
        protected bool isSupportInverted = false;
        protected double costSupportInverted = 500;
        protected override void calCost()
        {
            base.cost = 1000;
            if (isSupportInverted)
            {
                base.cost += costSupportInverted;
            }
            base.cost *= count;
        }
        public override void input(ref int xPoint, ref int yPoint)
        {
            base.input(ref xPoint, ref yPoint);
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("Hỗ trợ công nghệ Invertex (1-Có 0-Không): ");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                isSupportInverted = true;
            }
            yPoint = yPoint + 1;
        }
        public override void output(ref int xPoint, ref int yPoint)
        {
            base.output(ref xPoint, ref yPoint);
            Console.SetCursorPosition(xPoint, yPoint++);
            string s = "";
            if (isSupportInverted == true)
            {
                s += "Có hỗ trợ công nghệ Invertex với giá ";
                s = s + costSupportInverted;
            }
            else
            {
                s += "Không hỗ trợ công nghệ Invertex";
            }
            Console.Write(s);
        }
        public override string toString()
        {
            string result = "    Máy lạnh: < " + id + " > < " + typeProduct + " > < " + name + " > < " + provider +
                " > < " + cost + " > < ";
            if (isSupportInverted == true)
            {
                result += "Có hỗ trợ Invertex >";
            }
            else
            {
                result += "Không hỗ trợ Invertex >";
            }
            return result;
        }
    }
}
