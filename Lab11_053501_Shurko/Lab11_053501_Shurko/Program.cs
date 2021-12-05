using System;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary;

namespace Lab11_053501_Shurko {
    class Program {
        public static void DisplayInfo(TimeSpan ts, double res,string name) {
            Console.WriteLine($"Time in seconds: {ts.TotalSeconds}");
            Console.WriteLine($"Result: {res}");
            Console.WriteLine($"Thread name: {name}");
        }
        static void Main() {
            Integral.Calculation += DisplayInfo;
            Container c2 = new (0, 1);
            Thread thread2 = new (() => {
                Task t1 = Integral.CountIntegralAsync(c2);
                t1.Wait();

            });
            thread2.Priority = ThreadPriority.Lowest;
            thread2.Name = "Thread2";
            Thread thread1 = new (()=>Integral.CountIntegral(c2));
            thread1.Priority = ThreadPriority.Highest;
            thread1.Name = "Thread1";
            Console.WriteLine($"Starts: {thread2.Name}");
            thread2.Start();
            Console.WriteLine($"Starts: {thread1.Name}");
            thread1.Start();
        }
    }
}
