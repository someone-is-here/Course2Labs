using System;
using Lab.Domain;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using System.Linq;
using System.Xml.Linq;

namespace Serializer1 {
    public class Serializer : ISerializer {
        static Type type = null;

        public IEnumerable<Restaurant> DeSerializeByLINQ(string fileName) {
            XDocument doc = XDocument.Load(fileName);
            var items = from item in doc.Element("Restaurants").Elements("Restaurant")
                        select new Restaurant (
                            item.Element("Title").Value.ToString(),
                            double.Parse(item.Element("Rating").Value.ToString().Replace(".", ",")),
                            int.Parse(item.Element("Staff").Value.ToString()),
                            item.Element("Menu").Value.ToString().Split(',').Select(x => x).ToList(),//List
                            new Kitchen(double.Parse(item.Element("Kitchen").Element("Square").Value.ToString().Replace(".", ",")), int.Parse(item.Element("Kitchen").Element("People").Value.ToString()), int.Parse(item.Element("Kitchen").Element("TechnologicalSupplies").Value.ToString()), bool.Parse(item.Element("Kitchen").Element("MasterChef").Value.ToString()))//Kitchen
                        );
            Console.WriteLine("DeserializeLINQ");
            return items;
        }
        public IEnumerable<Restaurant> DeSerializeByXML(string fileName) {
            IEnumerable<Restaurant> obj = null;
            using (FileStream fileStrteam = new FileStream(fileName, FileMode.OpenOrCreate)) {
                try {
                    XmlSerializer serializer = new XmlSerializer(type);
                    obj = (IEnumerable<Restaurant>)serializer.Deserialize(fileStrteam);
                    Console.WriteLine("DeserializeXML");
                }catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            return obj;
        }
        public IEnumerable<Restaurant> DeSerializeByJSON(string fileName) {
            IEnumerable<Restaurant> obj = null;
            try {
                obj = JsonSerializer.Deserialize<IEnumerable<Restaurant>>(File.ReadAllText(fileName));
                Console.WriteLine("DeserializeJSON");
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return obj;
        }
        public void SerializeByLINQ(IEnumerable<Restaurant> restaurant, string fileName) {
            try {
                restaurant.ToList();
                XDocument doc = new XDocument();
                XElement xElRoot = new XElement("Restaurants");
                foreach (var item in restaurant) {
                    XElement xEl1 = new XElement("Restaurant");
                    XElement xEl = new XElement("Title", item.Title);
                    xEl1.Add(xEl);
                    xEl = new XElement("Staff", item.Staff);
                    xEl1.Add(xEl);
                    xEl = new XElement("Kitchen");

                    XElement xEl0 = new XElement("Square", item.RestaurantKitchen.Square);
                    xEl.Add(xEl0);
                    xEl0 = new XElement("People", item.RestaurantKitchen.People);
                    xEl.Add(xEl0);
                    xEl0 = new XElement("MasterChef", item.RestaurantKitchen.MasterChef);
                    xEl.Add(xEl0);
                    xEl0 = new XElement("TechnologicalSupplies", item.RestaurantKitchen.TechnologicalSupplies);
                    xEl.Add(xEl0);

                    xEl1.Add(xEl);
                    xEl = new XElement("Rating", item.Rating);
                    xEl1.Add(xEl);
                    xEl = new XElement("Menu", string.Join(",", item.Menu.Select(r => r)));
                    xEl1.Add(xEl);
                    xElRoot.Add(xEl1);
                }
                doc.Add(xElRoot);
                doc.Save(fileName);
                Console.WriteLine("SerializeLINQ");
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        public void SerializeXML(IEnumerable<Restaurant> restaurant, string fileName) {
            using (FileStream fileStrteam = new FileStream(fileName, FileMode.OpenOrCreate)) {
                try {
                    type = restaurant.GetType();
                    XmlSerializer serializer = new XmlSerializer(restaurant.GetType());
                    serializer.Serialize(fileStrteam, restaurant);
                    Console.WriteLine("SerializeXML");
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void SerializeJSON(IEnumerable<Restaurant> restaurant, string fileName) {
            try {
                File.WriteAllText(fileName, JsonSerializer.Serialize(restaurant, restaurant.GetType()));
                Console.WriteLine("SerializeJSON");
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

