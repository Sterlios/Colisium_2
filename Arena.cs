using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    class Arena
    {
        private List<Fighter> _fighters;

        public Arena()
        {
            InitializeFighters();
        }

        public void Work()
        {
            Console.WriteLine("Арена начала работать.");
            
            ShowAccessFighters();

            Console.WriteLine();

            User user = new User();
            ToChallengeFighters(user, out Fighter leftFighter, out Fighter rightFighter);

            Console.WriteLine();

            ToFight(leftFighter, rightFighter);

            Console.WriteLine("Арена закончила работать.");
        }

        public void ShowAccessFighters()
        {
            Console.WriteLine("Список доступных бойцов:");

            foreach(Fighter fighter in _fighters)
            {
                fighter.ShowInfo();
            }
        }

        private void ToFight(Fighter leftFighter, Fighter rightFighter)
        {
            while(leftFighter.IsAlive && rightFighter.IsAlive)
            {
                leftFighter.ShowInfo();
                rightFighter.ShowInfo();

                rightFighter.TakeDamage(leftFighter.ToAttack());

                if (rightFighter.IsAlive)
                {
                    leftFighter.TakeDamage(rightFighter.ToAttack());
                }

                Console.WriteLine();
            }

            FinishFight(leftFighter, rightFighter);
        }

        private void FinishFight(Fighter leftFighter, Fighter rightFighter)
        {
            leftFighter.ShowInfo();
            rightFighter.ShowInfo();

            if (leftFighter.IsAlive == false && rightFighter.IsAlive == false)
            {
                Console.WriteLine("Ничья!");
            }
            else if (leftFighter.IsAlive == false)
            {
                Console.WriteLine("Победил правый боец!");
            }
            else 
            {
                Console.WriteLine("Победил левый боец!");
            }
        }

        private void ToChallengeFighters(User user, out Fighter leftFighter, out Fighter rightFighter)
        {
            Console.WriteLine("Выберите бойца слева");
            leftFighter = ToChallengeFighter(user);

            Console.WriteLine("Выберите бойца справа");
            rightFighter = ToChallengeFighter(user);
        }

        private Fighter ToChallengeFighter(User user)
        {
            Fighter fighter = null;
            string fighterName = user.GetAnwer();
            
            if(Enum.TryParse(fighterName, out FighterClass FighterClass))
            {
                fighter = new Fighter(FighterClass);
            }
            else
            {
                fighter = ToChallengeFighter(user);
            }

            return fighter;
        }

        private void InitializeFighters()
        {
            _fighters = new List<Fighter>();

            for(int i = 1; i < Enum.GetNames(typeof(FighterClass)).Length; i++)
            {
                _fighters.Add(new Fighter((FighterClass)i));
            }
        }
    }
}
