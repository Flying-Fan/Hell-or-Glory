using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNS
{
   public class Drink
    {
        //Would need to code accessors and mutators for program
        private string drinkName;
        public string DrinkName
        {
            get
            {
                return drinkName;
            }
        }

        private decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
        }


        public Drink(string inDrinkName, decimal inDrinkPrice)
        {
            drinkName = inDrinkName;
            price = inDrinkPrice;
        }

    }


}
