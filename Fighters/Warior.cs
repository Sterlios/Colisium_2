using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    class Warior : BaseFighter
    {
        public Warior() : base("Warior", 1200, 30, 40) { }

        public override BaseFighter ToCopy()
        {
            return new Warior();
        }
    }
}
