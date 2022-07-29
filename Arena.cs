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

            ChooseFighters(out Fighter leftFighter, out Fighter rightFighter);

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

                leftFighter.Attack(rightFighter);

                if (rightFighter.IsAlive)
                {
                    rightFighter.Attack(leftFighter);
                }

                Console.WriteLine();
            }

            ShowResult(leftFighter, rightFighter);
        }

        private void ShowResult(Fighter leftFighter, Fighter rightFighter)
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

        private void ChooseFighters(out Fighter leftFighter, out Fighter rightFighter)
        {
            Console.WriteLine("Выберите бойца слева");
            leftFighter = ChooseFighter();

            Console.WriteLine("Выберите бойца справа");
            rightFighter = ChooseFighter();
        }

        private Fighter ChooseFighter()
        {
            Fighter chosenFighter = null;
            bool isCorrect = false;

            while (isCorrect == false)
            {
                string fighterClass = Console.ReadLine();

                foreach(Fighter fighter in _fighters)
                {
                    if (fighter.Class.ToLower() == fighterClass.ToLower())
                    {
                        chosenFighter = new Fighter(fighter);
                        isCorrect = true;
                    }
                }
            }

            return chosenFighter;
        }

        private void InitializeFighters()
        {
            _fighters = new List<Fighter>
            {
                new Fighter("Assassin"),
                new Fighter("Warior", 1200, 30, 40, 2),
                new Fighter("Viking", 1300, 25, 43),
                new Fighter("IceMen", 850, 30, 47),
                new Fighter("Priest", 800, 10, 35)
            };
        }
    }
}
