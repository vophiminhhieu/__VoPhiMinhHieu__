using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class FanSteam : FanMachine
    {
        private double capacityWater;
        public FanSteam()
        {
            base.typeProduct = "Quạt hơi nước";
        }
        public override void input(ref int xPoint, ref int yPoint)
        {
            base.input(ref xPoint, ref yPoint);
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("Dung tích nước(lít) : ");
            capacityWater = ConsoleReadlineInteger();
            calCost();
            yPoint++;
        }
        protected override void calCost()
        {
            base.cost = capacityWater * 400;
            base.cost *= count;
        }
        public override void output(ref int xPoint, ref int yPoint)
        {
            base.output(ref xPoint, ref yPoint);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Dung tích nước(lít) : "+capacityWater);

        }
        public override string toString()
        {
            return base.toString() + " < " + capacityWater + " > < " + count + " >";
        }
    }
}
