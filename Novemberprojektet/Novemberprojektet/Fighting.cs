using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Fighting
    {
        protected int stance = 0;

        protected float hp = 0;

        protected int weapon = 0;

        public int GetStance(int amount)
        {
            if(amount == 1)
            {
                stance = 1;
            }
            else
            {
                stance = 2;
            }
            return stance;
        }

        public int Attack()
        {
            Random generator = new Random();

            int damage = 0;

            if (stance == 1 && weapon == 2) //Offensiv
            {
                damage = generator.Next(10, 20); //5 - 15
            }
            else if (stance == 1 && weapon != 2)
            {
                damage = generator.Next(5, 15); //5 - 15
            }
            else if (stance == 2) //Defensiv
            {
                damage = generator.Next(1, 9); //1 - 9
            }
          
            return damage;
        }

        public void Hurt(float amount)
        {
            Random generator = new Random();

            int defensiveStance = generator.Next(3); // 1/3 chans

            if (stance == 2 && defensiveStance == 2)
            {
                amount = 0;
            }
            else if (stance == 2 && defensiveStance != 2)
            {
                amount = amount * 0.5f;
            }

            hp = hp - amount;
        }

    }
}
