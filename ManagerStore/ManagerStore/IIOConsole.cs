using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    interface IIOConsole
    {
        public void input(ref int xPoint, ref int yPoint);
        public void output(ref int xPoint, ref int yPoint);

    }
}
