using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ClassLibrary {
    public class Galery {
        public Galery(int Id, int numberOfWorks, string name) {
            this.Id = Id;
            NumberOfWorks = numberOfWorks;
            this.Name = name;
        }
        public int Id { get; set; }
        public static int NumberOfWorks{ get; set; }
        public string Name { get; set; }
        public override string ToString() {
            return $"Id: {Id}\nName: {Name}\nNumber of works: {NumberOfWorks}\n";
        }
        public static Galery Parse(string strId, string works, string name) {
            Galery obj = null;
            try {
                strId=strId[(strId.IndexOf("Id: ") + 4)..];
                works = works[(works.IndexOf("Number of works: ") + 17)..];
                name = name[(name.IndexOf("Name: ") + 6)..];
                obj = new Galery(int.Parse(strId), int.Parse(works), name);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(strId);
            }
            return obj;
        }
    }
}
