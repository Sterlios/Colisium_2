using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    class Viking : BaseFighter
    {
        public Viking() : base("Viking", 1300, 25, 43) { }

        public override void Attack(BaseFighter enemy, bool isStunSuccess = false)
        {
            int precentage = 100;
            bool abilitySuccess = Random.Next(precentage) < AbilityChance;

            if (abilitySuccess)
            {
                int defaultDamage = Damage;
                int damageMultible = 2;

                Damage = defaultDamage * damageMultible;
                Console.Write("КРИТИЧЕСКИЙ УДАР! ");
                base.Attack(enemy);
                Damage = defaultDamage;
            }
            else
            {
                base.Attack(enemy);
            }
        }

        public override BaseFighter ToCopy()
        {
            return new Viking();
        }
    }
}
