using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Enemy : Fighting
    {
        static Random enemygenerator = new Random();
        public void SetEnemy()
        {
            List<string> enemies = new List<string> {"Demon", "Skeleton", "Zombie" };

            name = enemies[enemygenerator.Next(3)];

            Console.WriteLine("Denna match kommer du möta " + name + " som din motståndare");
        }

        public override int GetStance()
        {
            int amount = enemygenerator.Next(1,3);

            if (amount == 1)
            {
                Console.WriteLine("Enemy {Offensiv}");
                stance = 1;
            }
            else
            {
                Console.WriteLine("Enemy {Deffensiv}");
                stance = 2;
            }

            return stance;
        }
    }
}
