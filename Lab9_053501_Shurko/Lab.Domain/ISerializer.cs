using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Domain {
    public interface ISerializer {
        IEnumerable<Restaurant> DeSerializeByLINQ(string fileName);
        IEnumerable<Restaurant> DeSerializeByXML(string fileName);
        IEnumerable<Restaurant> DeSerializeByJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Restaurant> restaurant, string fileName);
        void SerializeXML(IEnumerable<Restaurant> restaurant, string fileName);
        void SerializeJSON(IEnumerable<Restaurant> restaurant, string fileName);
    }
}
