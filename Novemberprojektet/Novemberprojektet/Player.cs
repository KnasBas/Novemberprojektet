using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Player : Fighting
    {
        public void SetPlayer()
        {
            Console.Write("Välj din spelares namn: ");
            name = Console.ReadLine();
            Console.WriteLine("Du namngav din spelare till " + name);
        }

    }
}
