using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Avto
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."
            bool izhod = false;
            while (!izhod)
            {
                //IZPIS
                Console.Clear();
                Console.WriteLine("Glavni Meni");
                Console.WriteLine("NAVODILA : vtipkajte številko opcijo katere želite.");
                Console.WriteLine("1. Dodaj avto");
                Console.WriteLine("--------------------");
                Console.WriteLine("2. Natisni inventar");
                Console.WriteLine("--------------------");
                Console.WriteLine("3. Shrani inventar (če hočete vozilo shraniti stalno po vnosu izberite to možnost)");
                Console.WriteLine("--------------------");
                Console.WriteLine("4. Naloži inventar");
                Console.WriteLine("--------------------");
                Console.WriteLine("5. Izbriši vnos");
                Console.WriteLine("--------------------");
                Console.WriteLine("6. Izhod");
                Console.WriteLine("--------------------");
                Console.Write("Izberi možnost: ");
                string vnos = Console.ReadLine();

                switch (vnos)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        PrintInventory();
                        break;
                    case "3":
                        SaveInventory();
                        break;
                    case "4":
                        LoadInventory();
                        break;
                    case "5":
                        DeleteCar();
                        break;
                    case "6":
                        izhod = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Pritisnite ENTER da nadaljujete");
                Console.ReadLine();
            }
        }

        static void AddCar()
        {
            Console.WriteLine("Vpišite značilnosti avta:");
            Console.Write("Znamka: ");
            string znamka = Console.ReadLine();
            if (int.TryParse(znamka, out _)) 
            {
                Console.WriteLine("Napačen format znamke. Prosimo, vnesite veljaven niz.");
                
            }
            else if(char.TryParse(znamka, out _)){

                Console.WriteLine("Napačen format znamke. Prosimo, vnesite veljaven niz.");
                return;
            }
            Console.Write("Model: ");
            string model = Console.ReadLine();
            if (int.TryParse(model, out _))
            {
                Console.WriteLine("Napačen format znamke. Prosimo, vnesite veljaven niz.");

            }
            else if (char.TryParse(model, out _))
            {

                Console.WriteLine("Napačen format znamke. Prosimo, vnesite veljaven niz.");
                return;
            }
            Console.Write("Letnik: ");
            
            int letnik = int.Parse(Console.ReadLine());
            Console.Write("Barva: ");
            string barva = Console.ReadLine();
            if (int.TryParse(barva, out _))
            {
                Console.WriteLine("Napačen format znamke. Prosimo, vnesite veljaven niz.");

            }
            else if (char.TryParse(barva, out _))
            {

                Console.WriteLine("Napačen format znamke. Prosimo, vnesite veljaven niz.");
                return;
            }
            Console.Write("Cena: ");
            int cena = int.Parse(Console.ReadLine());

            knjiznica avto = new knjiznica(znamka, model, letnik, barva, cena);
            ZalogaAvtov.DodajAvto(avto);
            Console.WriteLine("Avto je bil dodan uspešno");
        }

        static void PrintInventory()
        {
            Console.WriteLine("Trenutni inventorij: ");
            ZalogaAvtov.NatisniInventuro();
        }

        static void SaveInventory()
        {
            string pot_datoteke = @"C:\Users\lukar\OneDrive\Namizje\Avto\Inventura_Avtov.txt";
            ZapisovanjePodatkov.NapišiInventuroVDatoteko(ZalogaAvtov.avti, pot_datoteke);
            Console.WriteLine("Inventorij je bil shranjen uspešno.");
        }

        static void LoadInventory()
        {
            string pot_datoteke = @"C:\Users\lukar\OneDrive\Namizje\Avto\Inventura_Avtov.txt";
            List<knjiznica> nalozeni_avti = BranjePodatkov.PreberiInventuroIzDatoteke(pot_datoteke);
            ZalogaAvtov.avti.Clear();
            ZalogaAvtov.avti.AddRange(nalozeni_avti);
            Console.WriteLine("Inventorij je bil naložen uspešno");
        }
        static void DeleteCar()
        {
            Console.WriteLine("Vnesi index od avta katerega hočete zbrisati:");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < ZalogaAvtov.avti.Count)
            {
                knjiznica car = ZalogaAvtov.avti[index];
                ZalogaAvtov.OdstraniAvto(car);
                Console.WriteLine("Avto je bil izbrisan uspešno.");
            }
            else
            {
                Console.WriteLine("Neveljaven index.");
            }
        }
     
    }
}
