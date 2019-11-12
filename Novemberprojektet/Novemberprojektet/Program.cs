using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Novembet projekt, GameState och fightersim
            
            Player p1 = new Player();
            Items i1 = new Items();
            p1.SetPlayer();
            p1.SetStats();

            //////////////////

            int victories = 0;
            int whichChoice;
            List<string> choices = new List<string> { "Norr", "Väst", "Öst", "Syd", "Övrigt"};

            while (victories <= 4 && p1.isAlive())
            {
                Console.WriteLine("Vilket vädersträck vill du gå? Vad vill du göra?");
                Console.WriteLine("Norr (1), Väst (2), Öst (3), Syd (4), Övrigt (5)");
                Console.Write("Ditt val: ");

                whichChoice = GetChoice();

                Console.WriteLine("Du valde att gå " + choices[whichChoice - 1]);

                switch (whichChoice)
                {
                    case 1:
                        victories = triggerInstance(p1,i1,victories);
                        break;

                    case 2:
                        victories = triggerInstance(p1, i1, victories);
                        break;

                    case 3:
                        victories = triggerInstance(p1, i1, victories);
                        break;

                    case 4:
                        victories = triggerInstance(p1, i1, victories);
                        break;
                    case 5:
                        Shop(i1);
                        break;
                }
                    Console.ReadLine();
            }

            if (!p1.isAlive()) 
            { 
                Console.WriteLine("Du förlorade spelet!"); 
            }
            else
            {
                Console.WriteLine("Grattis du överlevde fyra strider!");
            }
            Console.ReadLine();
        }
            
        static int GetChoice()
        {
            string answer = Console.ReadLine();
            bool resultChoice = int.TryParse(answer, out int i);
            while (!resultChoice || i < 1 || i >= 6)
            {
                Console.WriteLine("Ogiltigt alternativ, försök igen");
                Console.WriteLine("Norr (1), Väst (2), Öst (3), Syd (4), Övrigt (5)");
                Console.Write("Ditt val: ");
                answer = Console.ReadLine();
                resultChoice = int.TryParse(answer, out i);
            }

            return i;
        }

        static void Shop(Items i1)
        {
            Console.WriteLine("Vill du köpa en health potion?");
            Console.WriteLine("Ja(1), Nej(2)");
            Console.Write("Ditt val: ");
            string answer = Console.ReadLine();
            int i;
            bool resultChoice = int.TryParse(answer, out i);
            while (!resultChoice || i != 1 && i != 2)
            {
                Console.WriteLine("Vänligen ge ett giltigt alternativ om köpet");
                Console.WriteLine("Ja(1), Nej(2)");
                Console.Write("Ditt val: ");
                answer = Console.ReadLine();
                resultChoice = int.TryParse(answer, out i);
            }
            while (i == 1)
            {
                Console.WriteLine("Du har för tillfället " + i1.GetGoldPieces() + "st guldmynt.");
                Console.WriteLine("En Healthpotion kostar 5 mynt.");
                Console.ReadKey();
                Console.WriteLine("Hur många vill du köpa? Eller vill du lämna? (skriv avbryt)");
                Console.Write("Ditt val: ");
                answer = Console.ReadLine().ToLower();
                if (answer == "avbryt")
                {
                    i = 2;
                }
                int amount = 0;
                resultChoice = int.TryParse(answer, out amount);
                int totalGoldpieces = i1.GetGoldPieces();
                while(!resultChoice && amount > totalGoldpieces)
                {
                    Console.WriteLine("Du har inte råd, du har " + totalGoldpieces + "st mynt.");
                    Console.WriteLine("Ange ett nytt belopp eller skriv (avbryt) för att avbryta köpet");
                    answer = Console.ReadLine().ToLower();
                    if (answer == "avbryt")
                    {
                        i = 2;
                    }
                    resultChoice = int.TryParse(answer, out amount);
                }
                if(resultChoice && amount <= totalGoldpieces)
                {
                    i1.IncreaseHeatlthPotions(amount);
                    i1.SpendGoldPieces(amount * 5);
                    Console.WriteLine("Du har nu " + i1.GetHealthPotions() + "st healthpotions");
                }
                
            }            
                Console.WriteLine("*Lämnar shopen*");
                Console.ReadKey();        
        }

        static int triggerInstance(Player p1, Items i1, int victories)
        {
            Random gen = new Random();
            int instance = gen.Next(3); //0,1,2
            if (instance == 2)
            {
                victories = Fight(p1, i1, victories);
            }
            return victories;
        }

        static int Fight(Player p1, Items i1, int victories)
        {
            Enemy e1 = new Enemy();
            e1.SetEnemy();
            e1.SetStats();
            while (p1.isAlive() && e1.isAlive())
            {
                i1.UseHealthPotions(p1.GetStance());
                float attacks = p1.Attack();
                e1.Hurt(attacks);
                e1.GetHp();
                if (e1.isAlive())
                {
                    e1.GetStance();
                    attacks = e1.Attack();
                    p1.Hurt(attacks);
                    p1.GetHp();
                }
            }
            if (!p1.isAlive() && e1.isAlive())
            {
                Console.WriteLine("Du dog!");
            }
            else
            {
                Console.WriteLine(p1.name + " vann!");
                victories = victories + 1;
                i1.IncreaseGoldpieces();
            }
            Console.ReadKey();
            return victories;
        }
    }
}
