using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KargoAracHızTakip
{

    class Program
    {
        public delegate void SpeedHandler(string plaka_bilgi,string marka_bilgi, int hiz_bilgi);

        public static void kargo_aracı_SpeedExceeded(string Plaka,string Marka, int Speed)
        {
           DateTime tarih = DateTime.Now;
           Console.WriteLine("ALARM: " + Plaka + " Plakalı "+ Marka + " marka kargo aracı hız limitini aştı " + tarih + " anindaki hizi = " + Speed);
        }

        static void Main(string[] args)
        {
            CargoVehicle kargo_araci1 = new CargoVehicle("42SU1975","Fiat");
            CargoVehicle kargo_araci2 = new CargoVehicle("59AKS805","Peugeout");

            kargo_araci1.SpeedExceeded += new SpeedHandler(kargo_aracı_SpeedExceeded);
            kargo_araci2.SpeedExceeded += new SpeedHandler(kargo_aracı_SpeedExceeded);
            int j = 0;
            for (byte i = 85; i < 130; i += 5)
            {
                
                kargo_araci1.Hiz = i;
                kargo_araci2.Hiz = (byte)(85 + j);
                Console.WriteLine(kargo_araci1.Plaka + " plakalı aracın hızı = " + kargo_araci1.Hiz);
                Console.WriteLine(kargo_araci2.Plaka + " plakalı aracın hızı = " + kargo_araci2.Hiz);
               
                Thread.Sleep(1000);
                j += 8;
            }
            Console.ReadKey();

        }

        public class CargoVehicle
        {
            private int hiz;
            private string plaka;
            private string marka;
            public event SpeedHandler SpeedExceeded;

            public int Hiz
            {
                get
                {
                    return hiz;
                }

                set
                {
                    if (Hiz > 110)
                    {
                        hiz = value;
                        SpeedExceeded(Plaka,Marka, Hiz);
                    }
                    else
                    {
                        hiz = value;
                    }

                }
            }

            public string Plaka
            {
                get
                {
                    return plaka;
                }

                set
                {

                    plaka = value;
                }
            }

            public string Marka
            {
                get
                {
                    return marka;
                }

                set
                {
                    marka = value;
                }
            }

            public CargoVehicle(string plaka, string marka)
            {
                Plaka = plaka;
                Marka = marka;
            }
        }
    }
 
   
   

}
