using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Neural_Network
    {
        Neuron neuron1 = new Neuron();
        Neuron neuron2 = new Neuron();
        Neuron neuron3 = new Neuron();
        

        public List<string> FileRead() //liste şeklinde 150 satır döndürüyor.
        {
            string[] data = new string[150];
            int counter = 0;
            List<string> lines = new List<string>();
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\yusuf\source\repos\Project2\Project2\iris.data"))
            {
                //System.Console.WriteLine(line);
                lines.Add(line);
                counter++;
            }
            return lines;
        }
        public void weight_atama()
        {
            neuron1.random_weight();
            neuron2.random_weight();
            neuron3.random_weight();
        }

        
        public int Train(List<string> lines, double ogrenme_katsayi,int dogru_sonuc,int tekrar_sayisi)
        {
            for(int i=0; i<tekrar_sayisi; i++)
            {
                foreach (string line in lines)
                {
                    string[] inputs = line.Split(',');
                    neuron1.canak_uzunluk = Convert.ToDouble(inputs[0]) / 100;
                    neuron1.canak_genislik = Convert.ToDouble(inputs[1]) / 100;
                    neuron1.tac_uzunluk = Convert.ToDouble(inputs[2]) / 100;
                    neuron1.tac_genislik = Convert.ToDouble(inputs[3]) / 100;
                    neuron1.calculator();

                    neuron2.canak_uzunluk = Convert.ToDouble(inputs[0]) / 100;
                    neuron2.canak_genislik = Convert.ToDouble(inputs[1]) / 100;
                    neuron2.tac_uzunluk = Convert.ToDouble(inputs[2]) / 100;
                    neuron2.tac_genislik = Convert.ToDouble(inputs[3]) / 100;
                    neuron2.calculator();

                    neuron3.canak_uzunluk = Convert.ToDouble(inputs[0]) / 100;
                    neuron3.canak_genislik = Convert.ToDouble(inputs[1]) / 100;
                    neuron3.tac_uzunluk = Convert.ToDouble(inputs[2]) / 100;
                    neuron3.tac_genislik = Convert.ToDouble(inputs[3]) / 100;
                    neuron3.calculator();

                    if (Equals(inputs[4], "Iris-setosa"))
                    {
                        Console.WriteLine(neuron1.output + " " + neuron2.output + " " + neuron3.output);
                        if (highest(neuron1, neuron2, neuron3) == neuron2)
                        {
                            neuron2 = weight_degistir(neuron2, false, ogrenme_katsayi);
                            neuron1 = weight_degistir(neuron1, true, ogrenme_katsayi);
                        }
                        else if (highest(neuron1, neuron2, neuron3) == neuron3)
                        {
                            neuron3 = weight_degistir(neuron2, false, ogrenme_katsayi);
                            neuron1 = weight_degistir(neuron1, true, ogrenme_katsayi);
                        }
                        else { dogru_sonuc++; }
                    }
                    else if (Equals(inputs[4], "Iris-versicolor"))
                    {
                        if (highest(neuron1, neuron2, neuron3) == neuron1)
                        {
                            neuron1 = weight_degistir(neuron1, false, ogrenme_katsayi);
                            neuron2 = weight_degistir(neuron2, true, ogrenme_katsayi);
                        }
                        else if (highest(neuron1, neuron2, neuron3) == neuron3)
                        {
                            neuron3 = weight_degistir(neuron3, false, ogrenme_katsayi);
                            neuron2 = weight_degistir(neuron2, true, ogrenme_katsayi);
                        }
                        else { dogru_sonuc++; }
                    }
                    else
                    {
                        if (highest(neuron1, neuron2, neuron3) == neuron1)
                        {
                            neuron1 = weight_degistir(neuron1, false, ogrenme_katsayi);
                            neuron3 = weight_degistir(neuron3, true, ogrenme_katsayi);
                        }
                        else if (highest(neuron1, neuron2, neuron3) == neuron2)
                        {
                            neuron2 = weight_degistir(neuron2, false, ogrenme_katsayi);
                            neuron3 = weight_degistir(neuron3, true, ogrenme_katsayi);
                        }
                        else { dogru_sonuc++; }
                    }

                }
            }
            return dogru_sonuc;
        }
        public Neuron weight_degistir(Neuron neuron, bool x, double ogrenme_katsayi)
        {
            if (x) //weight arttır
            {
                neuron.weight1 += ogrenme_katsayi * neuron.canak_uzunluk;
                neuron.weight2 += ogrenme_katsayi * neuron.canak_genislik;
                neuron.weight3 += ogrenme_katsayi * neuron.tac_uzunluk;
                neuron.weight4 += ogrenme_katsayi * neuron.tac_genislik;
            }
            else
            {
                neuron.weight1 -= ogrenme_katsayi * neuron.canak_uzunluk;
                neuron.weight2 -= ogrenme_katsayi * neuron.canak_genislik;
                neuron.weight3 -= ogrenme_katsayi * neuron.tac_uzunluk;
                neuron.weight4 -= ogrenme_katsayi * neuron.tac_genislik;
            }
            return neuron;
        }
        public Neuron highest(Neuron neuron1, Neuron neuron2, Neuron neuron3)
        {
            if(neuron1.output > neuron2.output && neuron1.output > neuron3.output) { return neuron1; }
            else if(neuron2.output > neuron1.output && neuron2.output > neuron3.output) { return neuron2; }
            else { return neuron3; }
        }
    }

}
