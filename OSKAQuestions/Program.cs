using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OSKAQuestions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Q1
            //Show(1, 2, 3, 4, 5, 6);

            // Q2
            //MultiGenericCollec();

            // Q3
            //SamplePersonEvent();

            // Q4
            // Using blockları içerisinde işlemi tamamladığım için, görev yerine getirildiğinde kendilerini yok edeceklerdir (disposable a gerek kalmadan).
            //GetHtmlGoogle();


            // Q5
            //1) Tutulmak istenen veri stream vb.gibi bir tür ise ve daha sonra aritmatiksel/ mantıksal işlemler yapmayacaksam hız ve veri güvenliği açısından Binary olarak tutardım.
            //2) Tutulmak istenen veri xml, json v.b gibi veri şemasına sahipse, NoSQL gibi bir DB'de tutardım.
            //3) ProtocolBuffers vs. gibi teknolojiler söz konusu fakat veri tipi/miktari ve kullanım amacına göre avantaj/dezavantaj yaratabilir.


            // Q6
            //1) "For" hepsinin atasıdır ve CPU'nun çalışma doğasına en yakınıdır.Bu sebeple
            //en az düzeyde enerji/ bellek miktarı ile en hızlı şekilde sıralar.

            //2) "Do" for için yazdıklarımın koşullu olanı.aynı düzeyde enerji, biraz daha fazla bellek miktarı kullanır(koşul için)
            //fakat her dönüşünde koşul kontrolü olduğu için mantıksal olarak "For" a göre biraz daha yavaştır.

            //3) "foreach" koleksiyonların boyutu kadar döner ve her bir eleman için bellekte yer kaplar.
            //elemanlar üzerinde işlem yapılmayacaksa(okuma / yazma vs.) "for" a göre çok az daha yavaş çalışır.
            //fakat elemanlar üzerinde işlemler yapıldığında, (elemanın tipi ve bellekteki boyutuna göre) x(yapılan işlemin türüne göre)
            //yer kaplar ve "for" a göre çok daha yavaş çalışabilir.

            //4) "Parallel.for" for'un eş zamanlı olanı, performans olarak tümünden yüksektir. Bellek miktarı yaklaşık aynı kullanır
            //fakat çok daha fazla işlemci gücü / enerjisi tüketir. (teorik olarak tüm işlemci kapasitesini kullanır.)

            // "For","Do","foreach", "Parallel.for" ortak açıklama; tutulan data tipi sabit boyutlu bir değişken ise (int,bool,enum etc.) memorynin "stack" alanında tutulacaktır. Değişken
            // boyutu dinamik ise (class,ref,pointer etc.) memory'nin "heap" bölümünde tutulacaktır. "Stack" tarafında tutulan değişkene RAM'in çalışma prensibine göre daha hızlı erişilir çünkü erişim adresleri sıralı olacaktır.
            // "Heap" bölümünde ise boyut önceden kestirilmediği ve her daim büyüme ihtimali olduğu için adresler dağınık tutulur. Datalar tekrar erişmek istediğimizde adresler dağınık ortamda tutulduğu için
            // verilere daha yavaş erişilir.


            Console.ReadKey(true);
        }


        // Q1
        static void Show(params int[] x)
        {
            for(int i  = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i]);
            }
        }


        //Q2
        static void MultiGenericCollec()
        {
 

            MultiGenericCollect<int> m1 = new MultiGenericCollect<int>();
            
            m1.Add(1);
            m1.Add(2);
            m1.Add(3);
            m1.Add(4);
            m1.Add(5);

            var res = m1.Sum();

            Console.WriteLine($"MultiGenericCollec Res: {res}"); 
        }


        //Q3
        static void SamplePersonEvent()
        {

            SamplePerson sp1 = new SamplePerson();
            sp1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler((e,o) => 
            {
                Console.WriteLine($"{DateTime.Now} Name Changed: {sp1.Name}");
            });

            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                        

        Timer t = new Timer((c) => { 
            
                sp1.Name = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());

            });

            t.Change(5000, 5000);
        }


        //Q4
        static void GetHtmlGoogle()
        {

            UriBuilder builder = new UriBuilder("https://www.google.com");
            using (HttpClient client = new HttpClient())
            {
                var contentBytes = client.GetByteArrayAsync(builder.Uri).Result;
                using (MemoryStream stream = new MemoryStream(contentBytes))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        Console.WriteLine($"Source Code: {reader.ReadToEnd()}");
                    }
                    
                }
            }
           

        }
    }
}
