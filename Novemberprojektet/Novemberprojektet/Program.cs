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
            //Mekaniker som enemyns leveling system samt health potions systemet är fortfarande work in progress
            Items i1 = new Items();
            Fighting f1 = new Fighting();
            Player p1 = new Player();
            Enemy e1 = new Enemy();         //De olika klasserna börjar här
            
            int potionCheck = 0;
            p1.SetPlayer(); //Playern startar från börjar vilket förklarar att sperlarens karaktär skapas
            p1.SetStats();
            e1.SetStats();

            //////////////////

            int victories = 0; // en int som används för en while - loop som håller igång hela spelet
            int whichChoice;
            List<string> choices = new List<string> { "Norr", "Väst", "Öst", "Syd", "Övrigt"}; // en lista på olika alternativ spelaren kan välja

            while (victories < 4 && p1.isAlive()) //While loopen körs tills att spelaren dör eller att spelaren överlever 4 strider
            {
                Console.WriteLine("Vilket vädersträck vill du gå? Vad vill du göra?");
                Console.WriteLine("Norr (1), Väst (2), Öst (3), Syd (4), Övrigt (5)");
                Console.Write("Ditt val: ");

                whichChoice = GetChoice(); //Get Choice metoden anropas till int whichChoice

                Console.WriteLine("Du valde att gå " + choices[whichChoice - 1]); //listan choices skirver ut alternativet genom int:en whichChoice, med - 1 eftersom listans första plats börjar på 0

                switch (whichChoice) //En switch baserat på det man valde innan
                {
                    case 1:
                        victories = TriggerInstance(p1,i1, e1, victories, potionCheck); //victories parametern körs med triggerInstance metoden
                        break;

                    case 2:
                        victories = TriggerInstance(p1, i1, e1, victories, potionCheck); //eventuellt tar victories emot alla dess parameterar eftersom metoden använder en metod i en metod vilket kräver värden.
                        break;

                    case 3:
                        victories = TriggerInstance(p1, i1, e1, victories, potionCheck);
                        break;

                    case 4:
                        victories = TriggerInstance(p1, i1, e1, victories, potionCheck);
                        break;
                    case 5:
                        Shop(i1, potionCheck); //alternativ 5 tar en till shop metoden
                        break;
                }
                    Console.ReadLine();
            }

            if (!p1.isAlive()) //ett argument ifall spelaren dog 
            { 
                Console.WriteLine("Du förlorade spelet!"); 
            }
            else //annars vann spelaren
            {
                Console.WriteLine("Grattis du överlevde fyra strider!");
            }
            Console.ReadLine();
        }
            
        static int GetChoice() //En felsöknings metod
        {
            string answer = Console.ReadLine(); 
            bool resultChoice = int.TryParse(answer, out int i); //en tryparse på spelarens alternativ, alltså det måste vara giltigt
            while (!resultChoice || i < 1 || i >= 6) //while loopen checkar om svaret var giltigt via argumenten
            {
                Console.WriteLine("Ogiltigt alternativ, försök igen");
                Console.WriteLine("Norr (1), Väst (2), Öst (3), Syd (4), Övrigt (5)");
                Console.Write("Ditt val: ");
                answer = Console.ReadLine();
                resultChoice = int.TryParse(answer, out i);
            }

            return i; //returnerar tillbaka rätt svar
        }

        static int Shop(Items i1, int potionCheck)
        {
            Console.WriteLine("Vill du köpa en health potion?");
            Console.WriteLine("Ja(1), Nej(2)");
            Console.Write("Ditt val: ");
            string answer = Console.ReadLine();
            int i;
            bool resultChoice = int.TryParse(answer, out i); // en try parse som tidigare felsöknings system men denna gång nya parameterar
            while (!resultChoice || i != 1 && i != 2)
            {
                Console.WriteLine("Vänligen ge ett giltigt alternativ om köpet");
                Console.WriteLine("Ja(1), Nej(2)");
                Console.Write("Ditt val: ");
                answer = Console.ReadLine();
                resultChoice = int.TryParse(answer, out i);
            }
            while (i == 1) //om man väljer att gå in shopen
            {
                Console.WriteLine("Du har för tillfället " + i1.GetGoldPieces() + "st guldmynt."); //i1.GetGoldPieces skirver ut dina pengar
                Console.WriteLine("En Healthpotion kostar 5 mynt.");
                Console.ReadKey();
                Console.WriteLine("Hur många vill du köpa? Eller vill du lämna? (skriv avbryt)");
                Console.Write("Ditt val: ");
                answer = Console.ReadLine().ToLower(); //To.Lower för att säkerställa felsökning
                if (answer == "avbryt")
                {
                    i = 2;
                }
                int amount = 0;
                resultChoice = int.TryParse(answer, out amount);
                int totalGoldpieces = i1.GetGoldPieces();
                while(!resultChoice && amount > totalGoldpieces) //ser till att spelaren inte kan köpa healthpotions om man inte har råd
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
                if(resultChoice && amount <= totalGoldpieces) //om man lyckas köpa 
                {
                    i1.IncreaseHeatlthPotions(amount); //Metoden från klassen items körs beroende på hur många man köpte
                    i1.SpendGoldPieces(amount * 5); //minskar dina pengar
                    Console.WriteLine("Du har nu " + i1.GetHealthPotions() + "st healthpotions");
                    potionCheck = i1.GetHealthPotions();
                }
                
            }            
                Console.WriteLine("*Lämnar shopen*");
                Console.ReadKey();
            return potionCheck;
        }

        static int TriggerInstance(Player p1, Items i1, Enemy e1, int victories, int potionCheck) //En check ifall spelaren möter en enemy
        {
            Random gen = new Random();
            int instance = gen.Next(3); //0,1,2
            if (instance == 2) // 1/3 chans att spelarenn hittar en enemy beroende på vilket vädersträck man valde
            {
                victories = Fight(p1, i1, e1, victories, potionCheck);
            }
            else
            {
                Console.WriteLine("Du traskar runt i vildmarken ett bra tag men hittar inget.");
                Console.WriteLine("Fortsätt din resa.");
            }
            return victories;
        }

        static int Fight(Player p1, Items i1, Enemy e1, int victories, int potionCheck)
        {
            if(!e1.isAlive())
            {
                e1 = new Enemy();
            }
            e1.SetEnemy();
            e1.SetStats();      //Enemyns metoder körs för att slumpa fram en motståndare mot spelaren

            while (p1.isAlive() && e1.isAlive()) // en loop som skapar fighten, körs tills gången dör
            {
                i1.CheckHealthPotions(potionCheck);
                i1.UseHealthPotions(p1.GetStance()); //healthpotions metoden är baserad på GetStance eftersom stance metoden kan skicka ett resultat som går vidare till metod, läker spelaren
                float attacks = p1.Attack(); //float attacks tar emot Attack metodens resultat
                e1.Hurt(attacks); //hurt får sedan resultatet från attack
                e1.GetHp(); //En check på motståndarens hp
                if (e1.isAlive()) //om motståndaren är vid liv kan hen attackera annars vinner spelaren
                {
                    e1.GetStance();
                    attacks = e1.Attack(); //samma principer som tidigare metoder
                    p1.Hurt(attacks);
                    p1.GetHp();
                }
            }
            if (!p1.isAlive() && e1.isAlive()) //argument för vem som vann
            {
                Console.WriteLine("Du dog!");
            }
            else
            {
                p1.Victory(); 
                e1.EnemyLevelUp();
                Console.WriteLine(p1.name + " vann!"); //skriver ut spelarens vinst
                i1.IncreaseGoldpieces(10);
                Console.WriteLine("Du har nu " + i1.GetGoldPieces() + " guldmynt");
                Console.WriteLine("XP: " + p1.GetXp());
                Console.WriteLine("Total XP: " + p1.GetPlayerXp());         //Alla metoder som körs här är kommenterade för vad respektive metod utför
                Console.WriteLine("Level: " + p1.PlayerLevel());
                victories = victories + 1;
            }
            Console.ReadKey();
            return victories;
        }
    }
}
