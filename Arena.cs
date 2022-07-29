using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium_2
{
    class Arena
    {
        private List<BaseFighter> _fighters;

        public Arena()
        {
            InitializeFighters();
        }

        public void Work()
        {
            Console.WriteLine("Арена начала работать.");
            
            ShowAccessFighters();

            Console.WriteLine();

            ChooseFighters(out BaseFighter leftFighter, out BaseFighter rightFighter);

            Console.WriteLine();

            ToFight(leftFighter, rightFighter);

            Console.WriteLine("Арена закончила работать.");
        }

        public void ShowAccessFighters()
        {
            Console.WriteLine("Список доступных бойцов:");

            foreach(BaseFighter fighter in _fighters)
            {
                fighter.ShowInfo();
            }
        }

        private void ToFight(BaseFighter leftFighter, BaseFighter rightFighter)
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

        private void ShowResult(BaseFighter leftFighter, BaseFighter rightFighter)
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

        private void ChooseFighters(out BaseFighter leftFighter, out BaseFighter rightFighter)
        {
            Console.WriteLine("Выберите бойца слева");
            leftFighter = ChooseFighter();

            Console.WriteLine("Выберите бойца справа");
            rightFighter = ChooseFighter();
        }

        private BaseFighter ChooseFighter()
        {
            BaseFighter chosenFighter = null;
            bool isCorrect = false;

            while (isCorrect == false)
            {
                string fighterClass = Console.ReadLine();

                foreach(BaseFighter fighter in _fighters)
                {
                    if (fighter.Class.ToLower() == fighterClass.ToLower())
                    {
                        chosenFighter = fighter.ToCopy();
                        isCorrect = true;
                    }
                }
            }

            return chosenFighter;
        }

        private void InitializeFighters()
        {
            _fighters = new List<BaseFighter>
            {
                new Assassin(),
                new Warior(),
                new Viking(),
                new IceMen(),
                new Priest()
            };
        }
    }
}
