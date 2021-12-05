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
            Thread thread = new(() => {
                Task t1 = strService.WriteToStream(str);
                t1.Wait();
                });
            thread.Name = "Thread";
            Console.WriteLine($"Starts: {thread.Name}");
            thread.Start();
            Thread thread1 = new( () => {
                Task t2 = StreamService.CopyFromStream(str, "result.txt");
                t2.Wait();
            });
            thread1.Name = "Thread1";
            Console.WriteLine($"Starts: {thread1.Name}");
            thread1.Start();
            await Task.WhenAll(StreamService.GetStatisticsAsync("result.txt", (obj) => obj?.Name.Length > 5));
        }
    }
}
