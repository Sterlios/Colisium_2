using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    abstract class BaseFighter
    {
        protected int AbilityChance;
        private bool _isStun;
        private int _damageSpreading;

        public float Health { get; private set; }
        public int Armor { get; private set; }
        public int Damage { get; private set; }
        public int DamageCount { get; protected set; }
        public bool IsAlive => Health > 0;
        public string Class { get; }
        protected Random Random { get; }

        public BaseFighter(string fighterClass = "Базовый класс", float health = 1000, int armor = 20, int damage = 50, int damageCount = 1)
        {
            Class = fighterClass;
            Health = health;
            Armor = armor;
            Damage = damage;
            DamageCount = 1;
            _damageSpreading = 10;
            _isStun = false;
            Random = new Random();
            AbilityChance = 25;
        }

        public void ShowInfo()
        {
            Console.WriteLine(this); 
        }

        public virtual void TakeDamage(Attack attack)
        {
            IReadOnlyList<float> damageList = attack.Damages;

            foreach (float damage in damageList)
            {
                TakeDamage(damage, attack.IsStunSuccess);
            }
        }

        public virtual void Attack(BaseFighter enemy)
        {
            List<float> damageList = new List<float>();
            Random random = new Random();

            if (_isStun)
            {
                _isStun = false;

                Console.WriteLine(Class + " оглушен");
            }

            for (int i = 0; i < DamageCount; i++)
            {
                int minDamage = Math.Min(Math.Abs(Damage - _damageSpreading), Math.Abs(Damage + _damageSpreading));
                int maxDamage = Math.Max(Math.Abs(Damage - _damageSpreading), Math.Abs(Damage + _damageSpreading));
                int calculatedDamage = random.Next(minDamage, maxDamage);
                damageList.Add(calculatedDamage);

                Console.WriteLine(Class + " нанес " + calculatedDamage + " урона");
            }

            enemy.TakeDamage(new Attack(damageList));
        }

        public override string ToString()
        {
            return Class + " | Health: " + (int)Health + " | Armor: " + Armor + " | Damage: " + Damage;
        }

        public abstract BaseFighter ToCopy();

        protected void TakeDamage(float damage, bool IsStunSuccess)
        {
            _isStun = IsStunSuccess ? IsStunSuccess : _isStun;

            float precenage = 100;
            float calculatedDamage = (float)damage * (precenage - Armor) / precenage;
            Health -= calculatedDamage;

            Console.WriteLine(Class + " получил " + calculatedDamage + " урона");
        }
    }
}
