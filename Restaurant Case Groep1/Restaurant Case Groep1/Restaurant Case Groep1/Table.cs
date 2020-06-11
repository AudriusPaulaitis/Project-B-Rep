using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Case_Groep1 {

    public class Table
    {
        public List<Dish> dishes = new List<Dish>();
        public int id;
        public int TotalCost()
        {
            int costTotal = 0;
            foreach (Dish dish in dishes)
            {
                costTotal += dish.Prijs;
            }
            return costTotal;
        }
        public  Table(int x){
            this.id = x;
        }
    }
}