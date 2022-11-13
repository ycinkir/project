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
            Neural_Network sinir_agi = new Neural_Network();
            dogru_sonuc = sinir_agi.Train(sinir_agi.FileRead(), 0.01, dogru_sonuc, 50);
            Console.WriteLine("Dogruluk Oranı: " + "%" + dogru_sonuc/50*150*100);
            Console.ReadKey();
        }
    }
}
