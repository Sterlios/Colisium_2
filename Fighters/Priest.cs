using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    class Priest : BaseFighter
    {
        public Priest() : base("Priest", 800, 10, 35) { }

        public override void Attack(BaseFighter enemy, bool isStunSuccess = false)
        {
            int precentage = 100;
            bool abilitySuccess = Random.Next(precentage) < AbilityChance;

            if (abilitySuccess)
            {
                Heal();
            }
            else
            {
                base.Attack(enemy);
            }
        }

        private void Heal()
        {
            int healPoint = 200;
            Health += healPoint;

            if(Health > MaxHealth)
            {
                Health = MaxHealth;
            }

            Console.WriteLine(Class + " восстановил " + healPoint + " здоровья");
        }

        public override BaseFighter ToCopy()
        {
            return new Priest();
        }
    }
}
