using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Player : Fighting
    {
        private float playerXP = 0;      //
                                        // Leveling system
        private float playerLevel = 1; //

        private Random gen = new Random(); //generator
        public override void SetStats() //Setstats Metoden ärver från fighting fat ändrad från orginalet
        {
            base.SetStats(); //base.SetStats körs, enda skillnaden är att player klassen förändrar på vissa parameterar, i detta fall hp.
            hp = gen.Next(500, 800);
        }

        public float GetPlayerXp() //xp systemet, metoden anropas när spelaren vinner i program.cs som sedan lägger till xp variabeln från fighting till playerXP.
        {
            playerXP = playerXP + xp;

            return playerXP;
        }

        public float PlayerLevel() //Leveling baseras på playerXP, skapar ett "grinding" system som progressivt lvl:ar upp spelaren
        {
            playerLevel = playerLevel + playerXP / 25;

            return playerLevel;
        }

        public override int Attack() //Attack metoden, override från fighting, 
        {
            int damage = base.Attack(); //base.Attack() körs
            if (playerLevel >= 2) //Om spelaren har lvl:at upp ökar spelarens dmg
            {
                damage = damage + 2;
            }
            Console.WriteLine(name + " gör skada för " + damage);
            return damage;
        }
        public void SetPlayer() //SetPlayer Metoden
        {
            Console.Write("Välj din spelares namn: ");
            name = Console.ReadLine(); //En console.readline för att skriva ut spelarens namn
            Console.WriteLine("Du namngav din spelare till " + name);
        }
    }
}
