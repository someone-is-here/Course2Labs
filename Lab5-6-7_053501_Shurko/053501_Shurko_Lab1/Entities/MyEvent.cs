using System;
using System.Collections.Generic;
using System.Text;

namespace _053501_Shurko_Lab1.Entities {
    class MyEvent {
        private string entityName;
        private string entityMessage;
        public MyEvent(string name,string message) {
            entityName = name;
            entityMessage = message;
        }
        public override String ToString() {
            return "Entity name " + entityName + "\nEntity message " + entityMessage;
        }
    }
}
