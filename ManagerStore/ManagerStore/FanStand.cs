using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class FanStand : FanMachine
    {
        public FanStand()
        {
            base.typeProduct = "Quạt đứng";
        }
        public override void input(ref int xPoint, ref int yPoint)
        {
            base.input(ref xPoint, ref yPoint);
            calCost();
        }
        public override string toString()
        {
            return base.toString() + " < " + count + " >";
        }
    }
}
