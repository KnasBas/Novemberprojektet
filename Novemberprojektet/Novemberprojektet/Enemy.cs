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
        private int enemyLevel = 1;
            
        public Enemy()
        {
            gear = enemygenerator.Next(3); //1/3 chans
        }

        public override int Attack()
        {
            int damage = base.Attack();
            if (gear == 2 )
            {
                damage = damage + 3 + enemyLevel;
            }
            else
            {
                damage = damage + enemyLevel;
            }
            Console.WriteLine(name + " gör skada för " + damage);

            return damage;
        }

        public override float SetStats()
        {
            base.SetStats();
            hp = enemygenerator.Next(55, 80 * enemyLevel);

            return hp;
        }
        public void SetEnemy()
        {
            List<string> enemies = new List<string> {"Lesser Demon", "Skeletal Wyvern", "Zombie", "Ghast", "Giant Snake", "Giant Spider", "Vet'ion" };
            name = enemies[enemygenerator.Next(7)];
            if (gear == 2) 
            {
                Console.WriteLine("Denna match kommer du möta " + name + " som din motståndare");
                Console.WriteLine("Du har otur, motståndaren har bättre utrustning än normalt");
                Console.WriteLine("{lvl: " + enemyLevel + "}");
            }
            else
            {                
                Console.WriteLine("Denna match kommer du möta " + name + " som din motståndare");
                Console.WriteLine("{lvl: " + enemyLevel + "}");
            }            
        }

        public int EnemyLevelUp()
        {
            enemyLevel = enemyLevel + 1;

            return enemyLevel;
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
