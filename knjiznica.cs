using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Avto
{
    //"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."
    class knjiznica
    {
        public string znamka { get; set; }
        public string model { get; set; }
        public int letnik { get; set; }
        public string barva { get; set; }
        public int cena { get; set; }

        public knjiznica(string znamka, string model, int letnik, string barva, int cena)
        {
            this.znamka = znamka;
            this.model = model;
            this.letnik = letnik;
            this.barva = barva;
            this.cena = cena;
        }
    }

    static class ZalogaAvtov
    {
        public static List<knjiznica> avti = new List<knjiznica>();
        //DODAJANJE OBJEKTOV
        public static void DodajAvto(knjiznica knjiznica)
        {
            avti.Add(knjiznica);
        }

        //BRISANJE OBJEKTOV trenutna inventura
        public static void OdstraniAvto(knjiznica knjiznica)
        {
            avti.Remove(knjiznica);
        }
        public static void NatisniInventuro()
        {
            foreach (knjiznica knjiznica in avti)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", knjiznica.znamka, knjiznica.letnik, knjiznica.model, knjiznica.barva, knjiznica.cena);
            }
        }

    }
    //ZAPISOVANJE PODATKOV
    static class ZapisovanjePodatkov
    {
        public static void NapišiInventuroVDatoteko(List<knjiznica> avti, string pot_datoteke)
        {
            StreamWriter zapisovalnik = new StreamWriter(pot_datoteke);
            foreach (knjiznica avto in avti)
            {
                zapisovalnik.WriteLine("{0} {1} {2} {3} {4}", avto.znamka, avto.letnik, avto.model, avto.barva, avto.cena);
            }
            zapisovalnik.Close();
        }
    }
    static class BranjePodatkov
    {
        public static List<knjiznica> PreberiInventuroIzDatoteke(string pot_datoteke)
        {
            List<knjiznica> avti = new List<knjiznica>();
            try
            {
                using (StreamReader branje = new StreamReader(pot_datoteke))
                {
                    string vrstica;
                    while ((vrstica = branje.ReadLine()) != null)
                    {
                        string[] podatki = vrstica.Split(' ');
                        string znamka = podatki[0];
                        int letnik = int.Parse(podatki[1]);
                        string model = podatki[2];
                        string barva = podatki[3];
                        int cena = int.Parse(podatki[4]);
                        avti.Add(new knjiznica(znamka, model, letnik, barva, cena));
                    }
                }
            }
            catch (FileNotFoundException napaka)
            {
                Console.WriteLine("Napaka pri branju datoteke: {0}", napaka.Message);
            }
            catch (IOException napaka)
            {
                Console.WriteLine("Napaka pri branju podatkov: {0}", napaka.Message);
            }
            catch (FormatException napaka)
            {
                Console.WriteLine("Napaka pri pretvarjanju podatkov: {0}", napaka.Message);
            }
            catch (Exception napaka)
            {
                Console.WriteLine("Napaka: {0}", napaka.Message);
            }

            return avti;
        }
    }
}






