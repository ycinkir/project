using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Neuron
    {
        Random random = new Random();
        public double canak_uzunluk;
        public double canak_genislik;
        public double tac_uzunluk;
        public double tac_genislik;
        public double weight1;
        public double weight2;
        public double weight3;
        public double weight4;
        public double output;
        public bool sonuc_tur;

        public void random_weight()
        {
            this.weight1 = random.NextDouble();
            this.weight2 = random.NextDouble();
            this.weight3 = random.NextDouble();
            this.weight4 = random.NextDouble();
        }
        public void calculator()
        {
            this.output = canak_uzunluk * weight1 + canak_genislik * weight2 + tac_uzunluk * weight3 + tac_genislik * weight4;
        } 
         
    }
}
