using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Fighting : Items
    {
        public string name = "";

        protected int xp = 0;

        protected int stance = 0;

        protected int weapon = 0;

        protected int gear = 0;

        protected bool PlayerState = true;
        
        public virtual float SetStats()
        {
            Random generator = new Random();

            hp = generator.Next(80, 100);

            weapon = generator.Next(3); // 1/3 chans, om generatorn rullar 2 så kommer spelaren göra mer damage

            return hp;
        }
        public virtual int GetStance()
        {
            if (healthpotions >= 1)
            {
                Console.WriteLine("Välj stance Offensiv (1), Deffensiv (2) eller Heal (3)");
                Console.Write("Ditt val: ");

                string answer = Console.ReadLine();

                bool checkAnswer = int.TryParse(answer, out stance);

                while (!checkAnswer || stance >= 4 && stance < 1)
                {
                    Console.WriteLine("Försök igen ( (1), (2) eller (3) )");
                    Console.Write("Ditt val: ");
                    answer = Console.ReadLine();
                    checkAnswer = int.TryParse(answer, out stance);
                }
            }
            else if(healthpotions == 0)
            {
                Console.WriteLine("Välj stance Offensiv (1), Deffensiv (2)");
                Console.Write("Ditt val: ");

                string answer = Console.ReadLine();

                bool checkAnswer = int.TryParse(answer, out stance);

                while (!checkAnswer || stance != 1 && stance != 2)
                {
                    Console.WriteLine("Försök igen ( (1) eller (2) )");
                    Console.Write("Ditt val: ");
                    answer = Console.ReadLine();
                    checkAnswer = int.TryParse(answer, out stance);
                }
            }                      
            if (stance == 1)
            {
                Console.WriteLine("{Offensiv}");
            }
            else if (stance == 2)
            {
                Console.WriteLine("{Deffensiv}");
            }
            else
            {
                Console.WriteLine("{Heal}");
            }
            return stance;
        }

        public virtual int Attack()
        {
            Random generator = new Random();

            int damage = 0;

            if (stance == 1 && weapon == 2) //Offensiv
            {
                damage = generator.Next(10, 21); //10 - 19
                Console.WriteLine("{Extra weapon dmg}");
                
            }
            else if (stance == 1 && weapon != 2)
            {
                damage = generator.Next(5, 16); //5 - 15
            }
            else if (stance == 2 && weapon == 2)//Defensiv
            {
                damage = generator.Next(6, 13); //Deffensiv mer dmg 6 - 12
                Console.WriteLine("{Extra weapon dmg}");
            }
            else if (stance == 2 && weapon != 2) 
            {
                damage = generator.Next(1, 9); //1 - 8
            }
            else
            {
                Console.WriteLine("Du valde att läka dig under rundan.");
            }

            return damage;
        }

        public void Hurt(float amount)
        {
            Random generator = new Random();

            int defensiveStance = generator.Next(3); // 1/3 chans

            if (stance == 2 && defensiveStance == 2)
            {
                amount = 0;
            }
            else if (stance == 2 && defensiveStance != 2)
            {
                amount = amount * 0.5f;
            }

            hp = hp - amount;

            if(hp < 0)
            {
                hp = 0;
            }
        }
        public float GetHp() 
        {
            Console.WriteLine(name + " har nu " + hp + "hp kvar.");
            Console.WriteLine("(klicka valfri knapp...)");
            Console.ReadKey();
            return hp;
        }

        public bool isAlive()
        {
            if(hp == 0)
            {
                PlayerState = false;
            }

            return PlayerState;
        }

        public int Victory()
        {
            xp = 2;
            return xp;
        }

        public int GetXp()
        {
            return xp;
        }

    }
}
