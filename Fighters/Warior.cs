using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    class Warior : BaseFighter
    {
        public Warior() : base("Warior", 1200, 30, 40) { }

        public override void Attack(BaseFighter enemy)
        {
            int precentage = 100;
            bool abilitySuccess = Random.Next(precentage) < AbilityChance;

            if (abilitySuccess)
            {
                int defaultDamageCount = DamageCount;
                int damageCountMultible = 2;

                DamageCount = defaultDamageCount * damageCountMultible;
                base.Attack(enemy);
                DamageCount = defaultDamageCount;
            }
            else
            {
                base.Attack(enemy);
            }
        }

        public override BaseFighter ToCopy()
        {
            return new Warior();
        }
    }
}
