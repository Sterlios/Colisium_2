using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    class IceMen : BaseFighter
    {
        public IceMen() : base("IceMen", 850, 30, 47) { }

        public override BaseFighter ToCopy()
        {
            return new IceMen();
        }
    }
}
