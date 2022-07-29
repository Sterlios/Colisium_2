using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    class Fighter
    {
        private float _health;
        private int _armor;
        private int _damage;
        private int _damageCount;
        private string _fighterClass;
        private int _damageSpreading;
        private bool _isStun;
        public bool IsAlive => _health > 0;

        public Fighter(string fighterClass = "Базовый класс", float health = 1000, int armor = 20, int damage = 50, int damageCount = 1)
        {
            _fighterClass = fighterClass;
            _health = health;
            _armor = armor;
            _damage = damage;
            _damageCount = damageCount;
            _damageSpreading = 10;
            _isStun = false;
        }

        public void ShowInfo()
        {
            Console.WriteLine(this); 
        }

        public void TakeDamage(Attack attack)
        {
            IReadOnlyList<float> damageList = attack.Damages;
            float precenage = 100;
            _isStun = attack.IsStunSuccess;

            foreach (float damage in damageList)
            {
                float calculatedDamage = (float)damage * (precenage - _armor) / precenage;
                _health -= calculatedDamage;

                Console.WriteLine(_fighterClass + " получил " + calculatedDamage + " урона");
            }
        }

        public void Attack(Fighter enemy)
        {
            List<float> damageList = new List<float>();
            Random random = new Random();

            if (_isStun)
            {
                _isStun = false;

                Console.WriteLine(_fighterClass + " оглушен");
            }
            for (int i = 0; i < _damageCount; i++)
            {
                int minDamage = Math.Min(Math.Abs(_damage - _damageSpreading), Math.Abs(_damage + _damageSpreading));
                int maxDamage = Math.Max(Math.Abs(_damage - _damageSpreading), Math.Abs(_damage + _damageSpreading));
                int calculatedDamage = random.Next(minDamage, maxDamage);
                damageList.Add(calculatedDamage);

                Console.WriteLine(_fighterClass + " нанес " + calculatedDamage + " урона");
            }

            enemy.TakeDamage(new Attack(damageList));
        }

        public override string ToString()
        {
            return _fighterClass + " | Health: " + (int)_health + " | Armor: " + _armor + " | Damage: " + _damage;
        }
    }
}
