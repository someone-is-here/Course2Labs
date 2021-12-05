using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _053501_Shurko_Lab4 {
    class Program {
        static void Main(string[] args) {
            List<Employee> listWithEmployees = new List<Employee>();
            string[] names = { "Alexsandr", "Alexey", "Kirill", "Nikita", "Daniil" };
            Random rand = new Random();
            for (int i = 0; i < 6; i++) {
                listWithEmployees.Add(new Employee(names[rand.Next(names.Length)], rand.Next(45) + 18, rand.Next(2) == 1 ? true : false));
            }
            foreach (Employee emp in listWithEmployees) {
                Console.WriteLine(emp.ToString());
            }
            FileService fileService = new FileService();
            fileService.SaveData(listWithEmployees, "file");

            File.Move("file","newFile");

            List<Employee> freeWithEmployees = new List<Employee>();

            foreach (Employee empl in fileService.ReadFile("newFile")) {
                freeWithEmployees.Add(empl);
                Console.WriteLine(empl);
            }
            Console.WriteLine();
            Console.WriteLine();

            var workers = (from employee in freeWithEmployees orderby employee.Name select employee).ToList<Employee>();
            IEnumerable<Employee> orderFreeWithEmployees = freeWithEmployees.OrderBy(s => s, new EmployeeComparer());

            foreach (Employee empl in orderFreeWithEmployees) {
                Console.WriteLine(empl);
            }
            File.Delete("newFile");
        }
    }
}
