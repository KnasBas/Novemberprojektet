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

            Player p1 = new Player();
            Enemy e1 = new Enemy();

            p1.SetPlayer();
            p1.SetStats();

            e1.SetEnemy();
            e1.SetStats();

            bool p1State = p1.isAlive();          
            bool e1State = e1.isAlive();

            while (p1State == true && e1State == true)
            {
                p1.GetStance();
                float attacks = p1.Attack();
                e1.Hurt(attacks);
                e1.GetHp();
                e1State = e1.isAlive();

                e1.GetStance();
                attacks = e1.Attack();
                p1.Hurt(attacks);
                p1.GetHp();
                p1State = p1.isAlive();
            }

            if(p1State == false && e1State == true)
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
