using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class AirOneSide : AirMachine
    {
        public AirOneSide()
        {
            base.typeProduct = "Máy lạnh 1 chiều";
        }
        public override void input(ref int xPoint, ref int yPoint)
        {
            base.input(ref xPoint, ref yPoint);
            calCost();
        }
        public override void output(ref int xPoint, ref int yPoint)
        {
            base.output(ref xPoint, ref yPoint);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Giá sản phẩm: " + cost);
        }
        public override string toString()
        {
            return base.toString()+" < "+count+" >";
        }
    }
}
