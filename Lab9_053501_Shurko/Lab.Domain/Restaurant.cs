using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Domain {
    public class Restaurant {
        public Restaurant() { }
        public Restaurant(String title, double rating, int staff, List<String> menu,Kitchen kitchen) {
            Title = title;
            Rating = rating;
            Staff = staff;
            Menu = menu;
            RestaurantKitchen = kitchen;
        }
        public String Title { get; set; }
        public Kitchen RestaurantKitchen { get; set; }
        public double Rating { get; set; }
        public int Staff { get; set; }
        public List<String> Menu { get; set; }
        public override String ToString() {
            StringBuilder strB = new StringBuilder();
            strB.Append($"Title: {Title}\n");
            strB.Append($"Rating: {Rating}\n");
            strB.Append($"Staff: {Staff}\n");
            strB.Append($"Kitchen: {RestaurantKitchen}\n");
            strB.Append("Menu: \n");
            foreach (string str in Menu) {
                strB.Append(str + "\n");
            }
            return strB.ToString();
        }
    }
}
