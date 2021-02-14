using System;
using System.IO;
using System.Collections.Generic;

namespace Plakatowanie
{
    class Zad
    {

        public string name1 = "pla1a";


        public void WypiszListe(List<int> lista)
        {
            Console.WriteLine("\n\nLista: ");
            foreach (int item in lista)
                Console.Write(item + " ");
            Console.WriteLine();
        }

        public int WczytajIRob()
        {
            string name = name1 + ".in";
            //wczytuje plik
            StreamReader sr = new StreamReader(name);
            string line = sr.ReadToEnd();
            Console.WriteLine(line);

            //tworze  liste z domkami (szerokosc ich nie ma znaczenia wiec nie jest to tablica 2wymiarowa)
            List<int> lista = new List<int>();

            string StrNumberToAdd = "";
            int IntNumberToAdd;

            //ZAPELNIAM LISTE
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == 32)//jesli jest spacja
                {
                    i++;
                    //jesli cyferka
                    while (Convert.ToInt32(line[i]) >= 48 && Convert.ToInt32(line[i]) <= 57)
                    {
                        StrNumberToAdd += line[i];
                        i++;
                        if (i == line.Length)
                            break;
                    }
                    IntNumberToAdd = Convert.ToInt32(StrNumberToAdd);
                    lista.Add(IntNumberToAdd);
                    StrNumberToAdd = "";
                }
            }


            //WYPISZ LISTE
            WypiszListe(lista);

            //usuwam powtorzenia gdy obok sa
            for (int ij = 0; ij < lista.Count - 1; ij++)
            {
                if (lista[ij] == lista[ij + 1])
                {
                    lista.RemoveAt(ij + 1);
                    ij--;
                }
            }


            int Posters = 0;

            //wybieram wieze, usuwam srodkowa // i usuwam takie same obok
            for (int i = 0; i < lista.Count - 2; i++)
            {
                //jesli wieza
                if (lista[i + 1] > lista[i] && lista[i + 1] > lista[i + 2])
                {
                    Posters++;
                    lista.RemoveAt(i + 1);

                    //jesli stworza sie takie same obok to usuwam
                    if (lista[i] == lista[i + 1])
                        lista.RemoveAt(i + 1);

                    //cofam sie o 2 dwa bo element co byl na pozycji [i] moze teraz znalesc sie extremum (byc tzw wieza)
                    if (i >= 1)
                        i -= 2;
                    else
                        i--;
                }
            }

            //tyle ile zostaje niezalerznych liczb tyle plakatow trzeba jeszcze 'dokleic'
            Posters += (lista.Count);

            //WYPISZ LISTE
            WypiszListe(lista);

            return Posters;
        }
    }




    class Program
    {
        static void Main(string[] args)
        {

            DateTime start = DateTime.Now;
            Zad z1 = new Zad();
            int Posters = z1.WczytajIRob();

            Console.WriteLine("\nLiczba Plakatow:" + Posters);
            DateTime Stop = DateTime.Now;
            TimeSpan myTime = (Stop - start);
            StreamWriter sw = new StreamWriter(z1.name1 + ".out");
            sw.WriteLine("Zadanie: " + z1.name1 + "  Plakatow: " + Posters + "\nCzas trwania programu: " + myTime.TotalSeconds + "s");
            sw.Close();
            Console.WriteLine("Czas trwania programiu:" + myTime.TotalSeconds + "s");

            Console.ReadKey();
        }
    }
}
