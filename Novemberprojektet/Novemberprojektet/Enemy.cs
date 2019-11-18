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
            
        public Enemy()
        {
            xp = xp + 1;
            gear = enemygenerator.Next(3); //1/3 chans          
        }

        public override int Attack()
        {
            int damage = base.Attack();
            if (gear == 2 )
            {
                damage = damage + 3 + xp / 2;
            }
            else
            {
                damage = damage + xp / 2;
            }
            Console.WriteLine(name + " gör skada för " + damage);

            return damage;
        }

        public override void SetStats()
        {
            base.SetStats();
            hp = enemygenerator.Next(55, 80);
        }
        public void SetEnemy()
        {
            List<string> enemies = new List<string> {"Lesser Demon", "Skeletal Wyvern", "Zombie", "Ghast", "Giant Snake", "Giant Spider", "Vet'ion" };
            name = enemies[enemygenerator.Next(7)];
            if (gear == 2) 
            {
                Console.WriteLine("Denna match kommer du möta " + name + " som din motståndare");
                Console.WriteLine("Du har otur, motståndaren har bättre utrustning än normalt");
            }
            else
            {
                Console.WriteLine("Denna match kommer du möta " + name + " som din motståndare");
            }            
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
