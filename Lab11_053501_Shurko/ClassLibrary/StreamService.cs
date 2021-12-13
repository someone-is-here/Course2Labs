using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary {
    public class StreamService {
        private readonly List<Galery> galeryList;
        private static int id = 0;
        public StreamService(int size) {
            galeryList = new List<Galery>(size);
            for (int i = 0; i < size; i++) {
                galeryList.Add(GenInfo());
            }
        }
        private static Galery GenInfo() {
            Random rand = new ();
            string[] names = { "Alexey", "Alexsandr", "Harry", "Nikita", "Daniil", "Ekaterina", "Violet", "Veronika" };
            return new Galery(id++, rand.Next(0, 1000), names[rand.Next(names.Length)]);
        }
        public async Task WriteToStream(Stream stream) {
            await Task.Run(() => {
                lock (stream) {
                    Console.WriteLine("WriteToStream() begin");
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    foreach (Galery gal in galeryList) {
                        byte[] arr = System.Text.Encoding.UTF8.GetBytes(gal.ToString());
                        stream.WriteAsync(arr, 0, arr.Length);
                    }
                Console.WriteLine("WriteToStream() end");
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                }
            });

        }
        public async static Task CopyFromStream(Stream stream, string fileName) {
            await Task.Run(() => {
                lock (stream) {
                    Console.WriteLine("CopyFromStream() begin");
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

                    using (FileStream fstream = new(fileName, FileMode.OpenOrCreate)) {
                        stream.Position = 0;
                        try {
                            Console.WriteLine("StreamL: "+stream.Length);
                            stream.CopyTo(fstream);
                        } catch (Exception ex) {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                Console.WriteLine("CopyFromStream() end");
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
        }
        public async static Task<int> GetStatisticsAsync(string fileName, Func<Galery, bool> filter) {       
            int res = 0;
            Console.WriteLine("GetStatistic");
            var text = await File.ReadAllTextAsync(fileName);
            string[] arrayWithValues = text.Split('\n');
            List<Galery> galery = new();
            for (int i = 0; i < arrayWithValues.Length - 3; i += 3)
            {
                Galery obj = Galery.Parse(arrayWithValues[i], arrayWithValues[i + 2], arrayWithValues[i + 1]);
                galery.Add(obj);
            }
            Console.WriteLine("---------------");
            foreach (Galery g in galery)
            {
                Console.WriteLine(g);
            }
            res = ((IEnumerable<Galery>)galery).Count<Galery>(filter);
            Console.WriteLine(res);
            return res;
        }
    }
}
