using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks; 

namespace ParallelArray
{
    public class Program
    {
        static Stopwatch watch = new System.Diagnostics.Stopwatch();
        static void Main(string[] args)
        {
            pokus();
        }

        public static void pokus()
        {
            int cykluu = 100000;

            watch.Start();
            {
              //  var pole = new List<string>();
                var pole2 = new ConcurrentBag<string>();

                Parallel.For(0, cykluu, index =>
                {
                   // pole.Add("index"); 
                    pole2.Add("index");
                });

                Console.WriteLine(
                   // $"Počet záznamů v poli: {pole.Count}\n" +
                                  $"Počet záznamů v poli2: {pole2.Count}" +
                                  $"");
            }
            watch.Stop();
            Console.WriteLine($"Zpracováno za: {watch.ElapsedMilliseconds} ms");
             
        }




         
    }
}
