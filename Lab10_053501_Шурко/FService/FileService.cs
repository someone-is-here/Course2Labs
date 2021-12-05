using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Lab10_053501_Шурко;

namespace FService {
    public class FileService<T> : IFileService<T> where T : class {
        public IEnumerable<T> ReadFile(string fileName) {
            IEnumerable<T> obj = null;
            try {
                obj = JsonSerializer.Deserialize<IEnumerable<T>>(File.ReadAllText(fileName));
                Console.WriteLine("Read file JSON");
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return obj;
        }
        public void SaveData(IEnumerable<T> data, string fileName) {
            try {
                File.WriteAllText(fileName, JsonSerializer.Serialize(data, data.GetType()));
                Console.WriteLine("SerializeJSON");
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
