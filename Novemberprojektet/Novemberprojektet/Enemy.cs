using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Enemy : Fighting //arv
    {
        static Random enemygenerator = new Random(); //en  generator
        private int enemyLevel = 1; //parametern användes för ett lvl:ing system, notera dock att system inte är vid funktion inför inlämningen på grund av tidsskäl.            
        public override int Attack() //Attack metoden
        {
            int damage = base.Attack(); //Attack metoden från fighting klassen körs
            if (gear == 2 ) //En check ifall enemyn är starkare denna runda
            {
                damage = damage + 3 + enemyLevel; 
            }
            else
            {
                damage = damage + enemyLevel;
            }
            Console.WriteLine(name + " gör skada för " + damage); //skriver ut damage

            return damage;
        }

        public override void SetStats() //SetStats för enemyn då den har en mindre hp-pool än playern eventuellt är den beroende av enemyns level
        {
            base.SetStats();
            hp = enemygenerator.Next(80, 80 * enemyLevel);
        }
        public void SetEnemy()
        {
            List<string> enemies = new List<string> {"Lesser Demon", "Skeletal Wyvern", "Zombie", "Ghast", "Giant Snake", "Giant Spider", "Vet'ion" };
            name = enemies[enemygenerator.Next(7)];         //Här Slumpas vilken "typ" av enemy som spelaren möter
            gear = enemygenerator.Next(3); //slump gen 0,1,2 ,,, 1/3 chans
            if (gear == 2) //Tar emot gear variabeln, ifall motsånaderen kommer vara starkare dennna runda.
            {
                Console.WriteLine("Denna match kommer du möta " + name + " som din motståndare");
                Console.WriteLine("Du har otur, motståndaren har bättre utrustning än normalt");
                Console.WriteLine("{lvl: " + enemyLevel + "}");
            }
            else
            {                
                Console.WriteLine("Denna match kommer du möta " + name + " som din motståndare");
                Console.WriteLine("{lvl: " + enemyLevel + "}"); //Skriver ut namn och lvl
            }            
        }

        public int EnemyLevelUp() //En metod som anropas när spelaren vinner striden för att lvl:a upp enemyn
        {
            enemyLevel = enemyLevel + 1;

            return enemyLevel;
        }

        public override int GetStance() //Get Stance metoden måste vara slumad eftersom att ingen kontrollerar enemyn
        {
            int amount = enemygenerator.Next(1,3); //slump generatorn
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
