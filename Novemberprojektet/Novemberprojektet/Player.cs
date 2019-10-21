using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Player : Fighting
    {
        public string name = "";

        public void SetPlayer()
        {
            Random generator = new Random();

            hp = generator.Next(150, 200);

            weapon = generator.Next(3); // 1/3 chans, om generatorn rullar 2 så kommer spelaren göra mer damage

            Console.Write("Välj din spelares namn: ");
            name = Console.ReadLine();
            Console.WriteLine("Du namngav din spelare till " + name);
        }

    }
}
