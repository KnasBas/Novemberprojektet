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
            int pointOfCompass;
            List<string> pointOfCompassName = new List<string> { "Norr", "Väst", "Öst", "Syd" };
            //Player p = new Player();
            //p.SetPlayer();
            //p.SetStats();
            //Fight(p);

            Console.WriteLine("Vilket vädersträck vill du gå?");
            Console.WriteLine("Norr (1), Väst (2), Öst (3), Syd (4)");
            Console.Write("Ditt val: ");

            string answer = Console.ReadLine();
            bool resultDirection = int.TryParse(answer, out pointOfCompass);
            while (!resultDirection || pointOfCompass < 1 && pointOfCompass >= 5)
            {
                Console.WriteLine("Ogiltigt alternativ, försök igen");
                Console.WriteLine("(1, 2, 3 ,4)");
                Console.WriteLine("Ditt val: ");
                answer = Console.ReadLine();
                resultDirection = int.TryParse(answer, out pointOfCompass);
            }

            int i = pointOfCompass;

            Console.WriteLine("Du valde att gå " + pointOfCompassName[i-1]);

            switch(pointOfCompass)
            {
                case 1:

                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;
            }           
            Console.ReadLine();
        }

        static void Fight(Player p1)
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
            }
            Console.ReadKey();
        }
    }
}
