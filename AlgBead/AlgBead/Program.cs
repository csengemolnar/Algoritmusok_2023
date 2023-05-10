
using System.Collections.Generic;
using System;

namespace AlgBead
{
    class Program
    {

        class Tavolsag
        {
            int varosszam;
            public List<int> MaxTavolsag = new List<int>();


            public Tavolsag(int varosszam)
            {
                this.varosszam = varosszam;
            }



            int minTavolsag(int[] tavolsag, bool[] bennevan)
            {
                int minimum = int.MaxValue;
                int minind = -1;


                for (int i = 0; i < varosszam; i++)
                {
                    if (bennevan[i] == false && tavolsag[i] <= minimum)
                    {
                        minimum = tavolsag[i];
                        minind = i;

                    }
                }
                return minind;
            }

            public void Kiir(int[] tavolsag, int n)
            {

                Console.Write("Csúcs     Legrövidebb út\n");
                for (int i = 0; i < varosszam; i++)
                {
                    Console.Write((i + 1) + " \t\t " + tavolsag[i] + "\n");
                }


            }

            //Legmesszebb lévő városok kiválasztása
            public void MaxTav(int[] tavolsag)
            {
                // Az osszesen vegig kell menni , megnezni a legrovidebb utakat
                // mindegyik legrovidebb utnal ki kell valasztani a max utat(tehat ami a legmeszzebb van )
                // és ezek közül kell kiválasztani , azt az indexet és sulyt ami a legkisebb!

                int maximum = int.MinValue;
                int maxind = -1;
                for(int i=0; i<tavolsag.Length; i++)
                {
                    if (tavolsag[i] > maximum)
                    {
                        maximum = tavolsag[i];
                        maxind = i;
                    }

                }
                //próbálom hozzáadni egy listához amit megkap a főprogram
                //és akkor a főprogramban kiválasztjuk a legkisebbet
                this.MaxTavolsag.Add(maximum);
            }


            public void LegrovidebbUt(int[,] csucsmatrix, int ut)
            {
                int[] tavolsag = new int[varosszam];
                bool[] bennevan = new bool[varosszam];

                for (int i = 0; i < varosszam; i++)
                {
                    tavolsag[i] = int.MaxValue;
                    bennevan[i] = false;

                }
                tavolsag[ut] = 0;

                for (int s = 0; s < varosszam - 1; s++)
                {
                    int e = minTavolsag(tavolsag, bennevan);
                    bennevan[e] = true;

                    for (int j = 0; j < varosszam; j++)
                    {
                        if (!bennevan[j] && csucsmatrix[e, j] != 0 && tavolsag[e] != int.MaxValue && tavolsag[e] + csucsmatrix[e, j] < tavolsag[j])
                            tavolsag[j] = tavolsag[e] + csucsmatrix[e, j];
                    }


                }

                //Kiir(tavolsag, varosszam);
                MaxTav(tavolsag);
                
                


            }



        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var result = input.Split(' ');

            int varosszam = int.Parse(result[0]);
            int utszam = int.Parse(result[1]);

            int[,] csucsmatrix = new int[varosszam, varosszam];

            for (int i = 0; i < utszam; i++)
            {
                var line = Console.ReadLine();
                char[] tokens = new char[] { ' ', '\n' };
                var res = line.Split(tokens, StringSplitOptions.RemoveEmptyEntries);

                int a = int.Parse(res[0]);
                int b = int.Parse(res[1]);
                int weight = int.Parse(res[2]);

                csucsmatrix[a - 1, b - 1] = weight;
                csucsmatrix[b - 1, a - 1] = weight;

            }

           

            //Legrövidebb út megkeresése
            Tavolsag t = new Tavolsag(varosszam);
            // Az osszesen vegig kell menni , megnezni a legrovidebb utakat
            // mindegyik legrovidebb utnal ki kell valasztani a max utat(tehat ami a legmeszzebb van )
            // és ezek közül kell kiválasztani , azt az indexet és sulyt ami a legkisebb!

            for (int i = 0; i < varosszam; i++)
            {
                t.LegrovidebbUt(csucsmatrix, i);

            }
            //Tavolsag obj = new Tavolsag(varosszam);
            
            int minind = -1;
            int mintav = int.MaxValue;

            for (int i = 0; i < t.MaxTavolsag.Count; i++)
            {
                if (t.MaxTavolsag[i] < mintav)
                {
                    mintav = t.MaxTavolsag[i];
                    minind= i;
                }

            }
            Console.WriteLine(minind+1);
            Console.WriteLine(mintav);






        }
    }
}