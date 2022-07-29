using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    class Priest : BaseFighter
    {
        public Priest() :base("Priest", 800, 10, 35) { }

        public override BaseFighter ToCopy()
        {
            return new Priest();
        }
    }
}
