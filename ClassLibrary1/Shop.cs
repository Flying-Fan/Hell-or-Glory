using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopNS
{
    public class Shop
    {
        // Shop consists of list of Drinks and Purchases
        private List<Drink> DrinkList = new List<Drink>();
        private List<Purchase> PurchaseList = new List<Purchase>();


    public Shop(List<Drink> inDrink,List<Purchase> inPurchase)
        {
            DrinkList = inDrink;
            PurchaseList = inPurchase;  
        }


        public string MostPopularBlend()
        {
            string MostPopBlend = null;
            int totalFullCity = 0;
            int totalVienna = 0;
            int totalHullHill = 0;
            int totalNewOrleans = 0;

            for (int i = 0; i < PurchaseList.Count; i++)
            {
               
                switch (PurchaseList[i].Blend)
                {
                    case "Full-City Roast":
                        totalFullCity=totalFullCity + PurchaseList[i].Quantity;
                        break;

                    case "Vienna Roast":
                        totalVienna=totalVienna + PurchaseList[i].Quantity;
                        break;

                    case "Hull Hill":
                        totalHullHill=totalHullHill + PurchaseList[i].Quantity;
                        break;

                    case "New Orleans Roast":
                        totalNewOrleans=totalNewOrleans + PurchaseList[i].Quantity;
                        break;

                }

            }
            //There is no assumption that 2 Blends are equal, so no test needed
            //Would convert to list if more than one equal
            //if (totalFullCity == totalVienna && totalVienna == totalHullHill && totalHullHill == totalNewOrleans)
            //{
            //    //All of them

            //}
            if (totalFullCity > totalVienna && totalFullCity > totalHullHill && totalFullCity > totalNewOrleans)
            {
                MostPopBlend = "Full-City Roast";
                return MostPopBlend;
            }
            if (totalVienna > totalFullCity && totalVienna > totalHullHill && totalVienna > totalNewOrleans)
            {
                MostPopBlend = "Vienna Roast";
                return MostPopBlend;
            }
            if (totalHullHill > totalVienna && totalHullHill > totalFullCity && totalHullHill > totalNewOrleans)
            {
                MostPopBlend = "Hull Hill";
                return MostPopBlend;
            }
            if (totalNewOrleans > totalVienna && totalNewOrleans > totalHullHill && totalNewOrleans > totalFullCity)
            {
                MostPopBlend = "New Orleans Roast";
                return MostPopBlend;
            }

            throw new System.InvalidOperationException("Error One or more drinks equal");

        }

        public decimal DaysTakings()
        {
            decimal daysTakings = 0;
            for (int i = 0; i < PurchaseList.Count; i++)
            {
                daysTakings = daysTakings + PurchaseList[i].Drink.Price * PurchaseList[i].Quantity;
            }

            return daysTakings;
        }

        public List<string> MostPopularExtra()
        {
            List<string> MostPopExtras = new List<string>();
            int soyTotal = 0;
            int coconutTotal = 0;
            for(int i = 0; i < PurchaseList.Count; i++)
            {
                switch(PurchaseList[i].Extra)
                {
                    case "coconut milk":
                        coconutTotal = coconutTotal + PurchaseList[i].Quantity;
                        break;

                    case "soy":
                        soyTotal = soyTotal + PurchaseList[i].Quantity;
                        break;
                }

            }

            if (coconutTotal == soyTotal)
            {
                MostPopExtras.Add("soy");
                MostPopExtras.Add("coconut Milk");
            }
            if (coconutTotal > soyTotal)
            {
                MostPopExtras.Add("coconut Milk");
            }
            if (coconutTotal < soyTotal)
            {
                MostPopExtras.Add("soy");
            }

            return MostPopExtras;


        }

        public decimal CustomerExtraPercent()
        {
            int numberOfCustomers = 0;
            int numberOfExtrasSold = 0;
            decimal percentageSold = 0;

            for (int i = 0; i < PurchaseList.Count; i++)
            {
                numberOfCustomers = numberOfCustomers + PurchaseList[i].Quantity;

                if (PurchaseList[i].Extra != "null")
                {
                    numberOfExtrasSold = numberOfExtrasSold + PurchaseList[i].Quantity;
                }
            }

            percentageSold = (decimal)numberOfExtrasSold / (decimal)numberOfCustomers * 100;
            percentageSold = Math.Round(percentageSold,1);
            return percentageSold;
      
        }
    }
}
