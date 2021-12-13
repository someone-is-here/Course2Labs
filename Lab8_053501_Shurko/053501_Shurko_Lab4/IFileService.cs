using System;
using System.Collections.Generic;
using System.Text;

namespace _053501_Shurko_Lab4 {
    interface IFileService {
        IEnumerable<Employee> ReadFile(string fileName);
        void SaveData(IEnumerable<Employee> data, string fileName);
    }
}
