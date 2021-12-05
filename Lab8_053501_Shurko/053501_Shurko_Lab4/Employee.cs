using System;
using System.Collections.Generic;
using System.Text;

namespace _053501_Shurko_Lab4 {
    class Employee {
        public String Name { get; set; }
        public int Age { get; set; }
        public bool Job { get; set; }
        public Employee() { }
        public Employee(String name, int age, bool job) {
            Name = name;
            Age = age;
            Job = job;
        }
        public override string ToString() {
            string jobWriter = ((Job == true) ? "Employed" : "Unemployed");
            return Name + "\n" + Age.ToString() + "\n" + jobWriter + "\n";
        }

    }
}
