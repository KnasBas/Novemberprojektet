using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Items
    {
        private int goldpieces = 100;
        protected int healthpotions = 0;
        protected float hp = 0;

        public int UseHealthPotions(int value)
        {
            if (value == 3 && healthpotions >= 1)
            {
                hp = hp + 50;
                healthpotions = healthpotions - 1;

            }      
            return healthpotions;
        }
        public int IncreaseGoldpieces()
        {
            return goldpieces + 10;
        }

        public int GetGoldPieces()
        {
            return goldpieces;
        }

        public int SpendGoldPieces(int value)
        {
            goldpieces = goldpieces - value;
            return goldpieces;
        }

        public int IncreaseHeatlthPotions(int value)
        {
            healthpotions = healthpotions + value;
            return healthpotions;
        }

        public int GetHealthPotions()
        {
            return healthpotions;
        }
    }
}
