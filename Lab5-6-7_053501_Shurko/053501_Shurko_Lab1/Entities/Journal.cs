using System;
using System.Collections.Generic;
using System.Text;

namespace _053501_Shurko_Lab1.Entities {
    class Journal {
        Collections.MyCustomCollection<MyEvent> listWithEvents;
        public Journal() {
            listWithEvents = new Collections.MyCustomCollection<MyEvent>();
        }
        public void ShowAllJournal() {
            for (int i = 0; i < listWithEvents.Count; i++) {
                Console.WriteLine($"{i}) ");
                Console.WriteLine(listWithEvents[i]);
            }
            if (listWithEvents.Count == 0) {
                Console.WriteLine("Journal is empty!!!");
            }
        }
        public void AddEvent(MyEvent newEvent) {
            listWithEvents.Add(newEvent);
        }
        public void AddEventForChangingData(string name,string info) {
            AddEvent(new Entities.MyEvent(name, info));            
        }
    }
}
