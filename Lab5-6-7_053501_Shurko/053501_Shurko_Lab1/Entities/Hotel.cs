using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _053501_Shurko_Lab1.Entities {
    class Hotel<T> where T : Room, new() {
        private Dictionary<int, T> listOfRooms;
        private List<T> bookingByClientsList;

        public delegate void DataChangingHandler(string arg1, string arg2);
        public event DataChangingHandler DataChanged;
        public Hotel(int rooms) {
            listOfRooms = new Dictionary<int, T>(rooms);
            bookingByClientsList = new List<T>(rooms);
            for (int i = 0; i < rooms; i++) {
                listOfRooms.Add(i + 1, new T());
            }
        }
        public void EmptyRooms() {
            foreach (var item in listOfRooms) { 
                if (item.Value.ClientLiving == null) {
                    Console.Write(item.Value.RoomNumber + " ");
                }
            }
        }
        private bool isRoomEmpty(int roomNum) {
            return listOfRooms[roomNum].ClientLiving == null;
        }
        private int RoomsIndex(int roomNum) {
            foreach (var item in listOfRooms) {
                if (item.Value.RoomNumber == roomNum) {
                    return item.Key - 1;
                }
            }
            return -1;
        }
        public void ShowRoomsInfo() {
            foreach (var item in listOfRooms) {
                if (item.Value.ClientLiving == null) {
                    Console.WriteLine("Room number " + item.Value.RoomNumber + " is free.");
                    Console.WriteLine("Room's cost is " + item.Value.Cost + ".");
                } else {
                    Console.WriteLine("Room number " + item.Value.RoomNumber + " is taken.");
                    Console.WriteLine("Room's cost is " + item.Value.Cost + ".");
                }
            }            
        }
        public void ChangeListNumbers() {
            listOfRooms.Add(listOfRooms.Count + 1, new T());
            DataChanged?.Invoke(this.GetType().ToString(), "ChangeListNumbers");
        }
        public void ChangeClientsNumber() {
            this.BookApartment();
            DataChanged?.Invoke(this.GetType().ToString(), "ChangeClientNumber");
        }
        public void Booking() {
            BookApartment();
            DataChanged?.Invoke(this.GetType().ToString(), "Booked apartment");
        }
        private bool BookApartment() {
            Console.WriteLine("Enter room's number: ");
            try {
                int roomNum = Int32.Parse(Console.ReadLine());
                Console.WriteLine("You choose " + roomNum + " apartment.");
                if (this.isRoomEmpty(roomNum)) {
                    Console.WriteLine("Apartment is free, you can booked it.");
                    Client newClient = new Client();
                    newClient.AddClient();
                    this.listOfRooms[RoomsIndex(roomNum) +1].BookRoom(newClient);
                    this.bookingByClientsList.Add(listOfRooms[RoomsIndex(roomNum) + 1]);
                    Console.WriteLine("You successfully booked it!");
                    return true;
                } else {
                    Console.WriteLine("Apartment is busy, you can't booked it. Please choose another apartment.");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
            return false;
        }
        public void CalculateCostForLiving(String surname) {
            for (int i = 0; i < listOfRooms.Count; i++) {
                if (listOfRooms[i + 1].ClientLiving != null && listOfRooms[i + 1].ClientLiving.Surname == surname) {
                    Console.WriteLine("You need to pay " + (listOfRooms[i + 1]).Cost + " per day");
                    break;
                }
            }
        }
        public void CalculateCostForLivingDuringPeriod(String surname, int daysNum) {
            for (int i = 0; i < listOfRooms.Count; i++) {
                if (listOfRooms[i + 1].ClientLiving != null && listOfRooms[i + 1].ClientLiving.Surname == surname) {
                    Console.WriteLine("The whole cost is " + (listOfRooms[i + 1]).Cost * daysNum);
                    break;
                }
            }
        }
        public void SortRoomsByCost() {
            // listOfRooms = listOfRooms.OrderBy(pair => pair.Value.Cost).ToDictionary(pair => pair.Key, pair => pair.Value);
            listOfRooms = (from pair in listOfRooms orderby pair.Value.Cost select pair).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public double FullIncome() {
            var income = ((from value in bookingByClientsList where value.ClientLiving != null select value).ToList()).Sum(val => val.Cost);
            return income;
        }
        public String GetMaxIncomeInhabitant() {
            var maxIncome = (from res in bookingByClientsList where res.Cost==(((from value in bookingByClientsList where value.ClientLiving != null select value).ToList()).Max(val => val.Cost)) select res.ClientLiving.Name).ToList();
            return maxIncome[0];
        }
        public int GetClientsNumber(int sum) {
            int resultClientNumber = bookingByClientsList.Aggregate(0, ( x, z) => (z.Cost > sum ? ++x : x += 0),z=>z);
            return resultClientNumber;

        }
        public Dictionary<int, int> GroupByCost() {
            Dictionary<int, List<int>> group =
                   listOfRooms.GroupBy(r => r.Value.Cost)
                  .ToDictionary(t => t.Key, t => t.Select(r => r.Key).ToList());
            Dictionary<int, int> result = new Dictionary<int, int>();
            foreach (var value in group) {
                result.Add(value.Key, value.Value.Count);
            }
            return result;
        }
    }
}

