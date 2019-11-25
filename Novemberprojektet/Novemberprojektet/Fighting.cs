using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Fighting : Items
    {
        public string name = ""; //Name stirng, public eftersom spelaren ska kunna ändra på namnet

        protected int xp = 0;               //
                                            //
        protected int stance = 0;           //
                                            //  Dessa parameterar är protected på grund av hierakin hos klasserna då både Player och enemy behöver tillgång till dessa.
        protected int weapon = 0;           // *Notera dock att strukturen hos klasserna inte är optimala på grund av arvens ordning, till nästa gång bör ett klass diagram tidigare av projektet göras för att undvika detta.
                                            //
        protected int gear = 0;             //
                                            //
        protected bool PlayerState = true;  //
        
        
        public virtual void SetStats() //SetStats är en metod som slumpar olika parameterar som användes av både Player och enemy klasserna vilket förklarar att den är virtual
        {
            Random generator = new Random();

            hp = generator.Next(80, 100);

            weapon = generator.Next(3); // 1/3 chans, om generatorn rullar 2 så kommer spelaren göra mer damage
        }

        public virtual int GetStance() //virtual
        {
            if (healthpotions == 0) //om spelaren inte har en healthpotion
            {
                Console.WriteLine("Välj stance Offensiv (1), Deffensiv (2)");
                Console.Write("Ditt val: ");

                string answer = Console.ReadLine();

                bool checkAnswer = int.TryParse(answer, out stance);

                while (!checkAnswer || stance != 1 && stance != 2) // ett liknande fel checksystem som innan med en ändring att alternativ 3 (healthpotions) inte går att använda
                {
                    Console.WriteLine("Försök igen ( (1) eller (2) )");
                    Console.Write("Ditt val: ");
                    answer = Console.ReadLine();
                    checkAnswer = int.TryParse(answer, out stance);

                    //En check ifall det finns healthpotions vilket möjligör ett extra alternativ för spelaren att kunna välja att använda en.
                }
            }
            else
            {
                Console.WriteLine("Välj stance Offensiv (1), Deffensiv (2) eller Heal (3)");
                Console.Write("Ditt val: ");

                string answer = Console.ReadLine();

                bool checkAnswer = int.TryParse(answer, out stance);

                while (!checkAnswer || stance >= 4 && stance < 1) //ett fel checks system
                {
                    Console.WriteLine("Försök igen ( (1), (2) eller (3) )");
                    Console.Write("Ditt val: ");
                    answer = Console.ReadLine();
                    checkAnswer = int.TryParse(answer, out stance);
                }
            }

            if (stance == 1)                        //
            {                                       //
                Console.WriteLine("{Offensiv}");    //
            }                                       //
            else if (stance == 2)                   //
            {                                       //
                Console.WriteLine("{Deffensiv}");   // Skriver ut vilken stance spelaren valde
            }                                       //
            else
            {                                       //
                Console.WriteLine("{Heal}");        //
            }                                       //
            return stance;
        }

        public virtual int Attack()
        {
            Random generator = new Random(); //slump gen

            int damage = 0;

            if (stance == 1 && weapon == 2) //Offensiv
            {
                damage = generator.Next(10, 21); //10 - 19
                Console.WriteLine("{Extra weapon dmg}"); //Om weapon tidgare fick en 2.a från generatorn kommer spelaren gör extra mycket dmg
                
            }
            else if (stance == 1 && weapon != 2)
            {
                damage = generator.Next(5, 16); //5 - 15
            }
            else if (stance == 2 && weapon == 2)//Defensiv
            {
                damage = generator.Next(6, 13); //Deffensiv mer dmg 6 - 12
                Console.WriteLine("{Extra weapon dmg}");
            }
            else if (stance == 2 && weapon != 2) 
            {
                damage = generator.Next(1, 9); //1 - 8
            }
            else
            {
                Console.WriteLine("Du valde att läka dig under rundan.");
            }

            return damage;
        }

        public void Hurt(float amount) //tar emot attack metodens dmg i program cs
        {
            Random generator = new Random();

            int defensiveStance = generator.Next(3); // 1/3 chans

            if (stance == 2 && defensiveStance == 2) //Om man tidigare valde defensiv stance kan man ha tur att inte ta någon dmg alls
            {
                amount = 0;
            }
            else if (stance == 2 && defensiveStance != 2)
            {
                amount = amount * 0.5f;
            }

            hp = hp - amount; //hp minskas

            if(hp < 0) //en check så att hp inte går under 0
            {
                hp = 0;
            }
        }
        public float GetHp() //En metod som skriver ut hur mycket hp som spelaren eller enemyn har
        {
            Console.WriteLine(name + " har nu " + hp + "hp kvar.");
            Console.WriteLine("(klicka valfri knapp...)");
            Console.ReadKey();
            return hp;
        }

        public bool isAlive() //En bool metod som baseras på hp, då parametern PlayerState är blir false om hp = 0
        {
            if(hp == 0)
            {
                PlayerState = false;
            }

            return PlayerState;
        }

        public int Victory() //Victory metoden ökar xp
        {
            xp = 2;
            return xp;
        }

        public int GetXp() //GetXp hämtar enbart upp parametern xp
        {
            return xp;
        }

    }
}
