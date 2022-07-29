using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    class Assassin : BaseFighter
    {
        public Assassin() : base("Assassin", 800, 15, 35) { }

        public override void TakeDamage(Attack attack)
        {
            IReadOnlyList<float> damageList = attack.Damages;

            foreach (float damage in damageList)
            {
                int precentage = 100;
                bool abilitySuccess = Random.Next(precentage) < AbilityChance;

                if (abilitySuccess)
                {
                    Console.WriteLine(Class + " уклонился");
                }
                else
                {
                    TakeDamage(damage, attack.IsStunSuccess);
                }
            }
        }

        public override BaseFighter ToCopy()
        {
            return new Assassin();
        }
    }
}
