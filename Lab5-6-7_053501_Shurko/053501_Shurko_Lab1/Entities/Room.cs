using System;
using System.Collections.Generic;
using System.Text;

namespace _053501_Shurko_Lab1.Entities {
    class Room {
        private static int id = 0;
        private int roomNumber;
        private Client clientLiving;
        private int cost;
        public int RoomNumber { get; set; }
        public Client ClientLiving{ get; set; }
        public int Cost { get; set; }
        public Room() {
            ClientLiving = null;
            RoomNumber = ++id;
            GenCost();
        }
        public void BookRoom(Client client) {
            ClientLiving = client;
        }
        private void GenCost() {
            Cost = new Random().Next(1000, 1005);
        }

    }
}
