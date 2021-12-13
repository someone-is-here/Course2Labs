using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ClassLibrary {
    public class Integral {
        public delegate void HandlerForCalc(TimeSpan ts, double res,string name);
        public static event HandlerForCalc Calculation;

        private static readonly double step = 0.0000001;
        public static void CountIntegral(object obj) {
            Console.WriteLine("CountIntegral");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Container container = (Container)obj;
            double start = container.Start;
            double end = container.End;
            Stopwatch stopWatch = new();
            stopWatch.Start();
            double sum = 0;
            for (double i = start; i < end; i += step) {
                sum += (i * Math.Sin(i));
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Calculation?.Invoke(ts, sum, Thread.CurrentThread.Name);
        }
        public static async Task CountIntegralAsync(object obj) {
            await Task.Run(() => {
                Console.WriteLine("CountIntegralAsync");
                CountIntegral(obj);
            });
        }
    }
}
