using System;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary;
using System.IO;

namespace Lab11_Task2 {
    class Program {
        static async Task Main() {
            Console.WriteLine("Start writting");
            StreamService strService = new(100);
            MemoryStream str = new();
            Task t1 = strService.WriteToStream(str);
            await Task.Delay(100);
            Task t2 = StreamService.CopyFromStream(str, "result.txt");
            await Task.WhenAll(new Task[] { t1, t2 });
            await StreamService.GetStatisticsAsync("result.txt", (obj) => obj?.Name.Length > 5);
        }
    }
}
