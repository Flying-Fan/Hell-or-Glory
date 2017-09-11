using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNS
{
   public class Purchase
    {
  
        private Drink drink;
        public Drink Drink
        {
            get
            {
                return drink;
            }
        }

        private string blend;

        public String Blend
        {
            get
            {
                return blend;
            }
        }

        private int quantity;

        public int Quantity
        {
            get
            {
                return quantity;
            }
        }


        private string extra;

        public string Extra
        {
            get
            {
                return extra;
            }
        }


        public Purchase(Drink inDrinkName, string inBlend,int inQuantity,string inExtra)
        {
            drink = inDrinkName;
            blend = inBlend;
            quantity = inQuantity;
            extra = inExtra;
        }


    }

}
