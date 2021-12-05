using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _053501_Shurko_Lab4 {
    class FileService:IFileService {
        public IEnumerable<Employee> ReadFile(string fileName) {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open))) {
                while (reader.PeekChar() != -1) {
                    Employee employee = null;
                    try {
                        employee = new Employee(reader.ReadString(), reader.ReadInt32(), reader.ReadBoolean());
                        Console.WriteLine(employee);
                    } catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        yield break;
                    }
                    yield return employee;
                }
            }
        
        }
        public void SaveData(IEnumerable<Employee> data, string fileName) {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName,FileMode.Create))) {
                foreach (Employee empl in data) {
                    writer.Write(empl.Name);
                    writer.Write(empl.Age);
                    writer.Write(empl.Job);
                }
            }
        }
    }
}
