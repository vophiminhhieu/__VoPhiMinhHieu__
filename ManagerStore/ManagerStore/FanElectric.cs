using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class FanElectric : FanMachine
    {
        private double capacityPower;
        public FanElectric()
        {
            base.typeProduct = "Quạt điện";
        }
        public override void input(ref int xPoint, ref int yPoint)
        {
            base.input(ref xPoint, ref yPoint);
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("Dung lượng pin : ");
            capacityPower = ConsoleReadlineInteger();
            calCost();
            yPoint++;
        }
        public override void output(ref int xPoint, ref int yPoint)
        {
            base.output(ref xPoint, ref yPoint);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Dung tích pin : " + capacityPower);
        }
        protected override void calCost()
        {
            base.cost = capacityPower * 500;
            base.cost *= count;
        }
        public override string toString()
        {
            return base.toString() + " < " + capacityPower + " > < " + count + " >";
        }
    }
}
