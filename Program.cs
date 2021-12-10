
using System;

namespace ysa
{
    class Program
    {
        static void Main(string[] args)
        {
            double lamda = 0.4;
            double alfa = 0.6;

            double[][] trainData = new double[24][];
            trainData[0] = new double[] { 6.3, 2.9, 5.6, 1.8, 1, 0, 0 };
            trainData[1] = new double[] { 6.9, 3.1, 4.9, 1.5, 0, 1, 0 };
            trainData[2] = new double[] { 4.6, 3.4, 1.4, 0.3, 0, 0, 1 };
            trainData[3] = new double[] { 7.2, 3.6, 6.1, 2.5, 1, 0, 0 };
            trainData[4] = new double[] { 4.7, 3.2, 1.3, 0.2, 0, 0, 1 };
            trainData[5] = new double[] { 4.9, 3, 1.4, 0.2, 0, 0, 1 };
            trainData[6] = new double[] { 7.6, 3, 6.6, 2.1, 1, 0, 0 };
            trainData[7] = new double[] { 4.9, 2.4, 3.3, 1, 0, 1, 0 };
            trainData[8] = new double[] { 5.4, 3.9, 1.7, 0.4, 0, 0, 1 };
            trainData[9] = new double[] { 4.9, 3.1, 1.5, 0.1, 0, 0, 1 };
            trainData[10] = new double[] { 5, 3.6, 1.4, 0.2, 0, 0, 1 };
            trainData[11] = new double[] { 6.4, 3.2, 4.5, 1.5, 0, 1, 0 };
            trainData[12] = new double[] { 4.4, 2.9, 1.4, 0.2, 0, 0, 1 };
            trainData[13] = new double[] { 5.8, 2.7, 5.1, 1.9, 1, 0, 0 };
            trainData[14] = new double[] { 6.3, 3.3, 6, 2.5, 1, 0, 0 };
            trainData[15] = new double[] { 5.2, 2.7, 3.9, 1.4, 0, 1, 0 };
            trainData[16] = new double[] { 7, 3.2, 4.7, 1.4, 0, 1, 0 };
            trainData[17] = new double[] { 6.5, 2.8, 4.6, 1.5, 0, 1, 0 };
            trainData[18] = new double[] { 4.9, 2.5, 4.5, 1.7, 1, 0, 0 };
            trainData[19] = new double[] { 5.7, 2.8, 4.5, 1.3, 0, 1, 0 };
            trainData[20] = new double[] { 5, 3.4, 1.5, 0.2, 0, 0, 1 };
            trainData[21] = new double[] { 6.5, 3, 5.8, 2.2, 1, 0, 0 };
            trainData[22] = new double[] { 5.5, 2.3, 4, 1.3, 0, 1, 0 };
            trainData[23] = new double[] { 6.7, 2.5, 5.8, 1.8, 1, 0, 0 };

            Console.WriteLine("\nGeri Yayılım ile Yapay Sinir Ağı Eğitimine Başlıyoruz.\n");
            Console.WriteLine("Verilerimiz, ünlü Iris çiçeği setinin 30 maddelik bir alt kümesidir.\n");
            Console.WriteLine("İlk 4 verimiz sırasıyla; Sepal Uzunluk, Sepal Genişlik, Petal Uzunluk, Petal Genişlik değerleridir.\n");
            Console.WriteLine("Son 3 verimiz; ünlü İris Çiçeğinin türünü belirtmektedir.\n");
            Console.WriteLine("Bu değerler; \n 0 0 1 ise tür Iris setosa; , \n 0 1 0 ise tür Iris versicolor;,\n1 0 0 ise tür Iris virginica'dır. \n");

            Console.WriteLine("Veri Setimiz");
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(trainData[i][j]);
                    Console.Write("\t");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            double[][] testData = new double[6][];
            testData[0] = new double[] { 4.6, 3.1, 1.5, 0.2, 0, 0, 1 };
            testData[1] = new double[] { 7.1, 3, 5.9, 2.1, 1, 0, 0 };
            testData[2] = new double[] { 5.1, 3.5, 1.4, 0.2, 0, 0, 1 };
            testData[3] = new double[] { 6.3, 3.3, 4.7, 1.6, 0, 1, 0 };
            testData[4] = new double[] { 6.6, 2.9, 4.6, 1.3, 0, 1, 0 };
            testData[5] = new double[] { 7.3, 2.9, 6.3, 1.8, 1, 0, 0 };

            Console.WriteLine("Test Setimiz");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(testData[i][j]);
                    Console.Write("\t");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            Console.WriteLine("\n4 Girişli;4 Gizli Katmanlı;3 Çıkışlı Sinir Ağı Oluşturuluyor.\n");

            int iNeuronCount = 4;
            int hNeuronCount = 4;
            int oNeuronCount = 3;

            double[] input = new double[4];
            double[] output = new double[3];
            double[] target = new double[3];
            double[] hidden = new double[4];

            double[] gercekDegerler = new double[18];
            double[] tahminiDegerler = new double[18];

            Random r = new Random();

            double[][] ihWeihgts = new double[4][];
            double[] hBiases = new double[4];

            for (int i = 0; i < ihWeihgts.Length; i++)
            {
                ihWeihgts[i] = new double[4];
                for (int j = 0; j < ihWeihgts[i].Length; j++)
                {
                    ihWeihgts[i][j] = -1 + r.NextDouble() * 2;
                }
            }

            Console.WriteLine("Giriş Katmanındaki Nöronların Ağırlıkları");
            for (int i = 0; i < ihWeihgts.Length; i++)
            {
                ihWeihgts[i] = new double[4];
                for (int j = 0; j < ihWeihgts[i].Length; j++)
                {
                    Console.Write(testData[i][j]);
                    Console.Write("\t");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            for (int i = 0; i < hNeuronCount; i++)
            {
                hBiases[i] = -1 + r.NextDouble() * 2;

            }

            Console.WriteLine("Giriş Katmanındaki Nöronların Bias Ağırlıkları");
            for (int i = 0; i < hNeuronCount; i++)
            {
                Console.Write(hBiases[i]);
                Console.Write("\t");
            }
            Console.Write("\n");
            Console.Write("\n");

            double[][] hoWeihgts = new double[4][];
            double[] oBiases = new double[3];

            for (int i = 0; i < hoWeihgts.Length; i++)
            {
                hoWeihgts[i] = new double[3];
                for (int j = 0; j < hoWeihgts[i].Length; j++)
                {
                    hoWeihgts[i][j] = -1 + r.NextDouble() * 2;
                }

            }

            Console.WriteLine("Ara katman ile Çıkış katmanı arasındaki ağırlıklarımız");
            for (int i = 0; i < hoWeihgts.Length; i++)
            {
                hoWeihgts[i] = new double[3];
                for (int j = 0; j < hoWeihgts[i].Length; j++)
                {
                    Console.Write(hoWeihgts[i][j]);
                    Console.Write("\t");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            for (int i = 0; i < oNeuronCount; i++)
            {
                oBiases[i] = -1 + r.NextDouble() * 2;
            }

            Console.WriteLine("Çıkış Katmanındaki Nöronların Bias Ağırlıkları");
            for (int i = 0; i < oNeuronCount; i++)
            {
                Console.Write(oBiases[i]);
                Console.Write("\t");
            }
            Console.Write("\n");
            Console.Write("\n");

            for (int run = 0; run < 1000; run++) //1000 iterasyon gerçekleşecek.
            {
                for (int i = 0; i < trainData.Length; i++) // 1 EPOCH
                {
                    for (int j = 0; j < 4; j++)
                    {
                        input[j] = trainData[i][j]; // 7.3, 2.9, 6.3, 1.8
                    }

                    int sayac = 0;
                    for (int j = 4; j < trainData[i].Length; j++)
                    {
                        target[sayac++] = trainData[i][j]; // 1, 0, 0
                    }

                    double[] hSum = new double[hNeuronCount];

                    for (int j = 0; j < hNeuronCount; j++) //ara katmanımızın değerlerini hesaplıyoruz.
                    {
                        for (int k = 0; k < iNeuronCount; k++)
                        {
                            hSum[j] += input[k] * ihWeihgts[k][j];
                        }
                        hSum[j] += hBiases[j]; //hesaplanan değerlere bias değerlerini ekliyoruz.
                        hSum[j] = Sigmoid(hSum[j]); //sigmoid fonksiyonu kullandığımız için sigmoid fonksiyonuna gönderiyoruz.
                    }


                    double[] oSum = new double[oNeuronCount];

                    for (int j = 0; j < oNeuronCount; j++) //çıkış katmanımızın değerlerini hesaplıyoruz.
                    {
                        for (int k = 0; k < hNeuronCount; k++)
                        {
                            oSum[j] += hSum[k] * hoWeihgts[k][j];
                        }
                        oSum[j] += oBiases[j]; //hesaplanan değerlere bias değerlerini ekliyoruz.
                        output[j] = Sigmoid(oSum[j]); //sigmoid fonksiyonu kullandığımız için sigmoid fonksiyonuna gönderiyoruz.
                    }

                    //değerlerimizi hesapladıktan sonra hatamızı hesaplıyoruz.
                    double[] hatalar = new double[oNeuronCount];
                    double TH = 0;
                    for (int j = 0; j < oNeuronCount; j++)
                    {
                        hatalar[j] = target[j] - output[j];
                        TH += (hatalar[j] * hatalar[j]) / 2; //toplam hatayı hesaplıyoruz.
                    }


                    // GERİ YAYILIM

                    double[] sigma = new double[oNeuronCount];
                    for (int j = 0; j < oNeuronCount; j++)
                    {
                        sigma[j] = output[j] * (1 - output[j]) * hatalar[j]; //sigma;çıktı ünitesinin hatasını göstermektedir. bunu hesaplamak için bu formül kullanılır.
                    }

                    double[][] hoDelta = new double[hNeuronCount][];
                    double[] hoDeltaBias = new double[oNeuronCount];

                    for (int j = 0; j < hNeuronCount; j++)
                    {
                        hoDelta[j] = new double[oNeuronCount];
                        for (int m = 0; m < oNeuronCount; m++)
                        {
                            hoDelta[j][m] = lamda * sigma[m] * hSum[j] + alfa * hoDelta[j][m]; //ara katmanla çıkış katmanı arasındaki ağırlıkların değiştirilmesi
                        }
                    }

                    for (int j = 0; j < hNeuronCount; j++)
                    {
                        for (int m = 0; m < oNeuronCount; m++)
                        {
                            hoWeihgts[j][m] += hoDelta[j][m]; //yeni ağırlıkları güncelliyoruz.
                        }
                    }


                    for (int m = 0; m < oNeuronCount; m++)
                    {
                        hoDeltaBias[m] = lamda * sigma[m] + alfa * hoDeltaBias[m];
                        oBiases[m] += hoDeltaBias[m];
                    }



                    double[] sigmaAra = new double[hNeuronCount];
                    for (int j = 0; j < hNeuronCount; j++)
                    {
                        sigmaAra[j] = hSum[j] * (1 - hSum[j]);
                        double tmp = 0;
                        for (int m = 0; m < oNeuronCount; m++)
                        {
                            tmp += (sigma[m] * hoWeihgts[j][m]);
                        }
                        sigmaAra[j] *= tmp;
                    }


                    double[][] ihDelta = new double[iNeuronCount][];
                    double[] ihDeltaBias = new double[hNeuronCount];


                    for (int k = 0; k < iNeuronCount; k++)
                    {
                        ihDelta[k] = new double[hNeuronCount];
                        for (int j = 0; j < hNeuronCount; j++)
                        {
                            ihDelta[k][j] = lamda * sigmaAra[j] * input[k] + alfa * ihDelta[k][j]; //aynı şekilde giriş katmanı ile ara katman arasındaki ağırlıkların güncellenmesi
                        }
                    }

                    for (int k = 0; k < iNeuronCount; k++)
                    {
                        for (int j = 0; j < hNeuronCount; j++)
                        {
                            ihWeihgts[k][j] += ihDelta[k][j];
                        }
                    }


                    for (int j = 0; j < hNeuronCount; j++)
                    {
                        ihDeltaBias[j] = alfa * sigmaAra[j] + alfa * ihDeltaBias[j];
                        hBiases[j] += ihDeltaBias[j];
                    }

                }

            } // ITERASYON

            //ağ eğitildi.iterasyonumuz sona erdi.şimdi test edeceğiz.

            int say = 0;
            int say1 = 0;

            for (int i = 0; i < testData.Length; i++)  //test veri setimiz ile ağımızı test ediyoruz.
            {
                for (int j = 0; j < 4; j++)
                {
                    input[j] = testData[i][j]; // 7.3, 2.9, 6.3, 1.8
                }
                int sayac = 0;
                for (int j = 4; j < testData[i].Length; j++)
                {
                    target[sayac++] = testData[i][j]; // 1, 0, 0
                }



                double[] hSum = new double[hNeuronCount];

                for (int j = 0; j < hNeuronCount; j++)
                {
                    for (int k = 0; k < iNeuronCount; k++)
                    {
                        hSum[j] += input[k] * ihWeihgts[k][j]; //ara katmandaki nöronların değerlerini hesapladık.
                    }
                    hSum[j] += hBiases[j];
                    hSum[j] = Sigmoid(hSum[j]);
                }


                double[] oSum = new double[oNeuronCount];

                for (int j = 0; j < oNeuronCount; j++)
                {
                    for (int k = 0; k < hNeuronCount; k++)
                    {
                        oSum[j] += hSum[k] * hoWeihgts[k][j]; //çıkış katmanındaki nöronlarımızın değerlerini hesapladık.
                    }
                    oSum[j] += oBiases[j];
                    output[j] = Sigmoid(oSum[j]);
                }

                double[] hatalar = new double[oNeuronCount];
                /*
               
                Console.WriteLine("HESAPLANAN ÇIKTILARIMIZ VE VERİ SETİNDEKİ ÇIKTILARIMIZ");
                
                for (int j = 0; j < oNeuronCount; j++)
                {
                    Console.Write(output[j] + " "+" "+" ");
                }
                Console.Write("\t");
                Console.Write("\t");

                for (int j = 0; j < oNeuronCount; j++)
                {
                    Console.Write(target[j] + " ");
                }
                
                Console.WriteLine();*/

                Console.WriteLine("\nHESAPLANAN ÇIKTILARIMIZ VE VERİ SETİNDEKİ ÇIKTILARIMIZ");
                for (int j = 0; j < oNeuronCount; j++) //tahmini değerler
                {
                    Console.Write(output[j] + " " + " " + " ");
                    tahminiDegerler[say1] = target[j];
                    say1++;
                }
                Console.Write("\t");
                Console.Write("\t");

                for (int j = 0; j < oNeuronCount; j++) //ana değerler
                {
                    Console.Write(target[j] + " ");
                    gercekDegerler[say] = output[j];
                    say++;
                }
                Console.WriteLine();

                int[] outputINT = new int[output.Length];
                for (int j = 0; j < output.Length; j++)
                {
                    outputINT[j] = 0;
                }

                int maxSayac = 0;
                double max = Double.MinValue;

                for (int j = 0; j < output.Length; j++)
                {
                    if (output[j] > max)
                    {
                        max = output[j];
                        maxSayac = j;
                    }
                }
                outputINT[maxSayac] = 1;

                for (int j = 0; j < oNeuronCount; j++)
                {
                    Console.Write(outputINT[j] + " ");
                }
                Console.Write("\t" + "---->  ");
                for (int j = 0; j < oNeuronCount; j++)
                {
                    Console.Write(target[j] + " ");
                }
            } //allllllll

            double gdegerler = 0;
            double gdegerlerort = 0;

            for (int j = 0; j < oNeuronCount; j++) //ana değerler
            {
                gdegerler += gercekDegerler[j];
            }
            gdegerlerort = gdegerler / gercekDegerler.Length;

            double r2pay = 0;
            for (int j = 0; j < oNeuronCount; j++) //ana değerler
            {
                r2pay += (gercekDegerler[j] - tahminiDegerler[j]) * (gercekDegerler[j] - tahminiDegerler[j]);
            }

            double r2payda = 0;
            for (int j = 0; j < oNeuronCount; j++) //ana değerler
            {
                r2payda += (gercekDegerler[j] - gdegerlerort) * (gercekDegerler[j] - gdegerlerort);
            }

            double r2degeri = 1 - (r2pay / r2payda);

            Console.WriteLine("\n\nR^2 Değeri = " + r2degeri);

            double rmse = Math.Sqrt(r2pay / 18);

            Console.WriteLine("\nRMSE Değeri = " + rmse);

            Console.ReadLine();

        }//main

        private static double Sigmoid(double v)
        {
            return 1 / (1 + (Math.Pow(Math.E, v * -1)));
        }
    }
}



