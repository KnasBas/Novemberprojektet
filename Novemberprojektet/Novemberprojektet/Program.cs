using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Novembet projekt, GameState och fightersim
            int victories = 0;
            int pointOfCompass;
            List<string> pointOfCompassName = new List<string> { "Norr", "Väst", "Öst", "Syd" };
            Player p1 = new Player();
            p1.SetPlayer();
            p1.SetStats();

            while (victories <= 3 && p1.isAlive())
            {
                Console.WriteLine("Vilket vädersträck vill du gå?");
                Console.WriteLine("Norr (1), Väst (2), Öst (3), Syd (4)");
                Console.Write("Ditt val: ");

                pointOfCompass = GetDirection();

                Console.WriteLine("Du valde att gå " + pointOfCompassName[pointOfCompass - 1]);

                switch (pointOfCompass)
                {
                    case 1:
                        victories = triggerInstance(p1, victories);
                        break;

                    case 2:
                        victories = triggerInstance(p1, victories);
                        break;

                    case 3:
                        victories = triggerInstance(p1, victories);
                        break;

                    case 4:
                        victories = triggerInstance(p1, victories);
                        break;
                }
                Console.ReadLine();
            }

            if (!p1.isAlive()) 
            { 
                Console.WriteLine("Du förlorade spelet!"); 
            }
            else
            {
                Console.WriteLine("Grattis du överlevde fyra strider!");
            }
            Console.ReadLine();
        }
            
        static int GetDirection()
        {
            string answer = Console.ReadLine();
            bool resultDirection = int.TryParse(answer, out int i);
            while (!resultDirection || i < 1 || i >= 5)
            {
                Console.WriteLine("Ogiltigt alternativ, försök igen");
                Console.WriteLine("Norr (1), Väst (2), Öst (3), Syd (4)");
                Console.WriteLine("Ditt val: ");
                answer = Console.ReadLine();
                resultDirection = int.TryParse(answer, out i);
            }

            return i;
        }

        static int triggerInstance(Player p1, int victories)
        {
            Random gen = new Random();
            int instance = gen.Next(3); //0,1,2
            if (instance == 2)
            {
                victories = Fight(p1, victories);
            }
            return victories;
        }

        static int Fight(Player p1, int victories)
        {
            Enemy e1 = new Enemy();
            e1.SetEnemy();
            e1.SetStats();
            while (p1.isAlive() && e1.isAlive())
            {
                p1.GetStance();
                float attacks = p1.Attack();
                e1.Hurt(attacks);
                e1.GetHp();
                if (e1.isAlive())
                {
                    e1.GetStance();
                    attacks = e1.Attack();
                    p1.Hurt(attacks);
                    p1.GetHp();
                }
            }
            if (!p1.isAlive() && e1.isAlive())
            {
                Console.WriteLine("Du dog!");
            }
            else
            {
                Console.WriteLine(p1.name + " vann!");
                victories = victories + 1;
            }
            Console.ReadKey();
            return victories;
        }
    }
}
