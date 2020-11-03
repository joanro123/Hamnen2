using System;
using System.Collections.Generic;
using System.Linq;

namespace Hamnen2
{
    class Program
    {
        static void Main(string[] args)
        {
            int dag = 1;
            double platserTotalt = 64;
            double reserveradePlatser = 0;


            Hamnen hamnen = new Hamnen();
            hamnen.Båtplatser = new List<Slot>();


            List<Boat> skapadeBåtar = new List<Boat>();
            List<Boat> inkommandeBåtar = new List<Boat>();
            List<Boat> BåtarUtanPlats = new List<Boat>();
            List<Hamnen> reserverade = new List<Hamnen>();

            Random r = new Random();
            int båtarDagligen = 5;

            while (true)
            {

                Console.WriteLine($"Dag nummer {dag}\n");

                for (int i = 0; i < båtarDagligen; i++)
                {
                    int randomNum = r.Next(1, 5);
                    if (randomNum == 1)
                    {
                        Rowboat rowboats = new Rowboat();
                        skapadeBåtar.Add(rowboats);
                    }
                    else if (randomNum == 2)
                    {
                        Motorboat motorboats = new Motorboat();
                        skapadeBåtar.Add(motorboats);
                    }
                    else if (randomNum == 3)
                    {
                        Sailboat sailboats = new Sailboat();
                        skapadeBåtar.Add(sailboats);
                    }
                    else if (randomNum == 4)
                    {
                        CargoShip cargoships = new CargoShip();
                        skapadeBåtar.Add(cargoships);
                    }
                }

                    foreach (var item in skapadeBåtar)
                    {
                     //   Console.WriteLine($"Boat {item.IdentityNumber} of type {item.BoatType} has arrived");



                        if ((reserveradePlatser + item.Tarplatser) < platserTotalt)
                        {
                            reserveradePlatser += item.Tarplatser;

                            string slotID = Guid.NewGuid().ToString();

                            item.CurrentSlotID = slotID;

                            inkommandeBåtar.Add(item);

                        hamnen.Båtplatser.Add(new Slot { ID = slotID, SlotSize = item.Tarplatser, Reserverad = true });                        
                        }

                        else
                        {              
                            BåtarUtanPlats.Add(item);
                        }
                    }
                

                // Visa vilka har skapats
                Console.WriteLine("Båtar som kommer idag:\n");
                foreach (var item in skapadeBåtar)
                {

                    Console.WriteLine($"{item.BoatType} med id: {item.IdentityNumber}");
                    
                }
                Console.WriteLine();




                foreach (var item in hamnen.Båtplatser)
                {
                    foreach (var item in inkommandeBåtar)
                    {
                        if (item.Tarplatser == item.) 
                    }
                }



                
              

                double platsnummer = 1;
                int antalRowBoat = 0;
                int antalMotor = 0;
                int antalSail = 0;
                int antalCargo = 0;
                double maxhastighet = 0;
                int antalHastighet = 0;
                int vikt = 0;
                


                Console.WriteLine("Plats\tBåttyp\t\tNr\tVikt\tMaxhast\t\tÖvrigt\n");

                foreach (Boat item in inkommandeBåtar.ToList())
                {


                    if (item != null)
                    {
                        if (item.Tarplatser > 1)
                        {
                            Console.WriteLine($"{platsnummer}-{platsnummer + item.Tarplatser - 1}.\t{item.BoatType}\t{item.IdentityNumber}\t{item.Weight}\t{item.MaxSpeed} km/h\t\t{item.UniqueProperty} ");
                            platsnummer++;
                        }
                        else
                        {
                            Console.WriteLine($"{platsnummer}.\t{item.BoatType}\t{item.IdentityNumber}\t{item.Weight}\t{item.MaxSpeed} km/h\t\t{item.UniqueProperty} ");

                        }

                        if (item is Rowboat)
                        {

                            antalRowBoat++;
                            platsnummer += item.Tarplatser;



                        }
                        else if (item is Motorboat)
                        {

                            antalMotor++;
                            platsnummer += item.Tarplatser;


                        }
                        else if (item is Sailboat)
                        {

                            antalSail++;
                            platsnummer += item.Tarplatser - 1;


                        }
                        else if (item is CargoShip)
                        {

                            antalCargo++;
                            platsnummer += item.Tarplatser - 1;


                        }


                    }

                    else
                    {
                        Console.WriteLine(platsnummer + ". Tomt");
                        platsnummer++;

                    }


                }

                foreach (var item in inkommandeBåtar.ToList())
                {
                    if (item != null)
                    {
                        if (item.DagarIHamnen != 0)
                        {
                            vikt += item.Weight;
                            maxhastighet += item.MaxSpeed;
                            item.DagarIHamnen--;
                            antalHastighet++;
                            
                        }

                        else
                        {
                            Console.WriteLine($"Den här båten lämnar hamnen: {item.IdentityNumber}");

                         //   ledigaPlatser += item.Tarplatser;
                            vikt -= item.Weight;
                            maxhastighet -= item.MaxSpeed;
                            antalHastighet--;
                            if (item is Rowboat)
                                antalRowBoat--;
                            else if (item is Motorboat)
                                antalMotor--;
                            else if (item is Sailboat)
                                antalSail--;
                            else if (item is CargoShip)
                                antalCargo--;
                            inkommandeBåtar.Remove(item);

                            






                        }
                    }
                }




                if (platsnummer < 65)
                {
                    double tommaPlatser = 65 - platsnummer;

                    for (int i = 0; i < tommaPlatser; i++)
                    {
                        Console.WriteLine(platsnummer + ". Tomt");
                        platsnummer++;
                    }

                }


                Console.WriteLine();
                Console.WriteLine($"Antal roddbåtar: {antalRowBoat}\nAntal motorbåtar: {antalMotor}\nAntal segelbåtar: {antalSail}\nAntal lastfartyg: {antalCargo}");


                double maxMedeltal = maxhastighet / antalHastighet;
                Console.WriteLine("Medeltal av båtarnas maxhastighet: " + Math.Round(maxMedeltal, 1) + " km/h");
                Console.WriteLine("Vikten är: " + vikt + " kg\n");

                // Visa vilka båtar fick inte plats
                Console.WriteLine("Båtar som inte fick plats:");
                foreach (var item in BåtarUtanPlats)
                {
                    Console.WriteLine($"{item.BoatType} med id: {item.IdentityNumber}");
                }

                

                reserverade.Clear();
                
                dag++;
                Console.WriteLine();
                Console.WriteLine("Nästa dag, klicka enter");

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    Console.Clear();


            }

        }
    }
    
}
