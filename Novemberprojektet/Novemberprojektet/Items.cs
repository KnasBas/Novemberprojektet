using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Items
    {
        protected int goldpieces = 0;     // 
        public int healthpotions = 0; // protected int för att de användes i arven.
        protected float hp = 0;         //

        public int UseHealthPotions(int value)
        {
            if (value == 3 && healthpotions >= 1) //Metoden tar upp value och checkar om den är 3 eventuellt ifall det finns några healthpotions
            {
                hp = hp + 50; //Ökar hp.
                healthpotions = healthpotions - 1; //minskar spelarens healthpotions

            }      
            return healthpotions;
        }
        public int IncreaseGoldpieces(int value) 
        {
            goldpieces = goldpieces + value; //tar upp value och gör en addition
            return goldpieces;
        }

        public int GetGoldPieces()
        {
            return goldpieces; //En metoden enbart för att checka spelarens goldpieces
        }

        public int SpendGoldPieces(int value)
        {
            goldpieces = goldpieces - value; //tar upp parametern value för att sedan subtrahera value från int goldpieces
            return goldpieces;
        }

        public int IncreaseHeatlthPotions(int value)
        {
            healthpotions = healthpotions + value; //Samma princip som tidigare metoder
            return healthpotions;
        }

        public virtual int GetHealthPotions()
        {
            return healthpotions; //En metod för att enbart låta spelaren gör en check på de intärna parametarna, i detta fall healthpotions
        }

        public int CheckHealthPotions(int value)
        {
            healthpotions = healthpotions + value;
            return healthpotions;
        }

    }
}
