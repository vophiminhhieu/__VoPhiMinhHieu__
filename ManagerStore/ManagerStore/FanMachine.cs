using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class FanMachine:Product
    {
        public override string toString()
        {
            return "    Máy quạt: < " + id + " > < " + typeProduct + " > < " + name + " > < " + provider + " > < "+cost+" >";
        }

        protected override void calCost()
        {
            base.cost = 500;
            base.cost *= count;
        }
    }
}
