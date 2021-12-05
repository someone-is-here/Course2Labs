using System;

namespace Lab.Domain {
    public class Kitchen {
        public Kitchen() { }
        public Kitchen(double square, int people, int TechSupplies, bool masterChef) {
            Square = square;
            People = people;
            TechnologicalSupplies = TechSupplies;
            MasterChef = masterChef;
        }
/*        public Kitchen(string kitchen) {
            try {
                Square = double.Parse(kitchen[(kitchen.IndexOf("Square")+8)..kitchen.IndexOf("People")]);
                People = int.Parse(kitchen[(kitchen.IndexOf("People") + 8)..kitchen.IndexOf("People")]);
                Square = double.Parse(kitchen[(kitchen.IndexOf("Square") + 7)..kitchen.IndexOf("People")]);
                Square = double.Parse(kitchen[(kitchen.IndexOf("Square") + 7)..kitchen.IndexOf("People")]);

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }*/
        public double Square { get; set; }
        public int People { get; set; }
        public int TechnologicalSupplies { get; set; }
        public bool MasterChef { get; set; }
        public override String ToString() {
            return $"\nSquare: {Square}\nPeople: {People}\nTechnological supplies: {TechnologicalSupplies}\nMasterChef: {MasterChef}\n";
        }
    }
}
