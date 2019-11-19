using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Player : Fighting
    {
        private float playerXP = 0;

        private float playerLevel = 1;

        private Random gen = new Random();
        public override void SetStats()
        {
            base.SetStats();
            hp = gen.Next(1000, 1000);
            weapon = gen.Next(3);
        }

        public float GetPlayerXp()
        {
            playerXP = playerXP + xp;

            return playerXP;
        }

        public float PlayerLevel()
        {
            playerLevel = playerLevel + playerXP / 25;

            return playerLevel;
        }

        public override int Attack()
        {
            int damage = base.Attack();
            if (xp >= 3)
            {
                damage = damage + xp;
            }
            Console.WriteLine(name + " gör skada för " + damage);
            return damage;
        }
        public void SetPlayer()
        {
            Console.Write("Välj din spelares namn: ");
            name = Console.ReadLine();
            Console.WriteLine("Du namngav din spelare till " + name);
        }
    }
}
