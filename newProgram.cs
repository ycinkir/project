using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogru_sonuc =0;
            int epok = 50;
            Neural_Network sinir_agi = new Neural_Network();
            sinir_agi.Train(sinir_agi.FileRead(), 0.01, epok);
            dogru_sonuc = sinir_agi.dogruluk_hesapla(sinir_agi.FileRead()) ;
            double dogruluk_orani = dogru_sonuc/150.0;
            dogruluk_orani *= 100;
            Console.WriteLine("Dogruluk Oranı: " + "%" + dogruluk_orani);
            Console.ReadKey();
        }
    }
}
