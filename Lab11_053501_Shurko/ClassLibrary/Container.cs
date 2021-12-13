using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary {
    public class Container {
        public Container(double start, double end) {
            if (start < end) {
                this.Start = start;
                this.End = end;
            }
            else {
                throw new Exception("Wrong paramentrs!(start > end)");
            }
        }
        public readonly double Start;
        public readonly double End;
    }
}
