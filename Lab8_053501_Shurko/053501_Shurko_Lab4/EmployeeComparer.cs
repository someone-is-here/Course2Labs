using System;
using System.Collections.Generic;
using System.Text;

namespace _053501_Shurko_Lab4 {
    class EmployeeComparer :IComparer<Employee> {
        public int Compare(Employee empl1, Employee empl2) {
           return string.Compare(empl1.Name, empl2.Name, true);
        }
    }
}
