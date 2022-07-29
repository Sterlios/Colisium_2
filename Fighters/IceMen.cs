using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    class IceMen : BaseFighter
    {
        public IceMen() : base("IceMen", 850, 30, 47) { }

        public override void Attack(BaseFighter enemy, bool isStunSuccess = false)
        {
            int precentage = 100;
            bool abilitySuccess = Random.Next(precentage) < AbilityChance;

            if (abilitySuccess)
            {
                Console.WriteLine(Class + " оглушил");
                base.Attack(enemy, true);
            }
            else
            {
                base.Attack(enemy);
            }
        }

        public override BaseFighter ToCopy()
        {
            return new IceMen();
        }
    }
}
