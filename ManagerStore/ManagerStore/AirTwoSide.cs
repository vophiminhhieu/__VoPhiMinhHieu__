using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class AirTwoSide : AirMachine
    {
        private bool isDeodorant = false;
        private bool isAntimicrobal = false;
        private double costDeodorant = 500;
        private double costAntimicrobal = 500;
        public AirTwoSide()
        {
            base.typeProduct = "Máy lạnh 2 chiều";
        }
        protected override void calCost()
        {
            base.cost = 2000;
            if (isSupportInverted == true)
            {
                base.cost += costSupportInverted;
            }
            if (isDeodorant == true)
            {
                base.cost += costDeodorant;
            }
            if (isAntimicrobal == true)
            {
                base.cost += costAntimicrobal;
            }
            base.cost *= count;
        }
        public override void input(ref int xPoint, ref int yPoint)
        {
            base.input(ref xPoint, ref yPoint);
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("Hỗ trợ khử mùi (1-Có 0-Không): ");
            yPoint++;
            if (ConsoleReadlineInteger() == 1)
            {
                isDeodorant = true;
            }
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("Hỗ trợ kháng khuẩn (1-Có 0-Không): ");
            if (ConsoleReadlineInteger() == 1)
            {
                isAntimicrobal = true;
            }
            calCost();
            yPoint++;
        }
        public override void output(ref int xPoint, ref int yPoint)
        {
            base.output(ref xPoint, ref yPoint);
            string Deo = "";
            string Anti = "";
            if (isDeodorant == true)
            {
                Deo = "Có hỗ trợ khử mùi với giá " + costDeodorant;
            }
            else {
                Deo = "Không hỗ trợ khửu mùi";
            }
            if (isAntimicrobal == true)
            {
                Anti = "Có hỗ trợ kháng khuẩn với giá " + costAntimicrobal;
            }
            else
            {
                Anti = "Không hỗ trợ kháng khuẩn";
            }
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write(Deo);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write(Anti);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Giá sản phẩm: " + cost);
        }
        public override string toString()
        {
            string result= base.toString();
            if (isDeodorant == true)
            {
                result += " < Có hỗ trợ khử mùi >";
            }
            else
            {
                result += " < Không hỗ trợ khử mùi >";
            }
            if (isAntimicrobal)
            {
                result += " < Có hỗ trợ kháng khuẩn >";
            }
            else
            {
                result += " < Không hỗ trợ kháng khuẩn >";
            }
            result += " < " + count + " >";
            return result;
        }
    }
}
