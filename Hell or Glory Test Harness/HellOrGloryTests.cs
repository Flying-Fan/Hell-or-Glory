using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopNS;

namespace Hell_or_Glory_Test_Harness

{
    [TestClass]
    public class HellOrGloryTests
    {

        public List<Drink> ReadDrinks()
        {
            List<Drink> DrinkList = new List<Drink>();
            System.IO.StreamReader csvDrinksIn = null;
            csvDrinksIn = new System.IO.StreamReader("C:\\Users\\Matthew Summerbell\\source\\repos\\Hell or Glory Test Harness\\Hell or Glory Test Harness\\Coffee shop price list.csv");

            List<string> Drinks = new List<string>();
            List<string> Prices = new List<string>();
            while (!csvDrinksIn.EndOfStream)
            {
                string line = csvDrinksIn.ReadLine();
                string[] values = new string[] { };
                values = line.Split(',');

                Drinks.Add(values[0].TrimStart());
                Prices.Add(values[1].TrimStart());

            }
            for (int i = 1; i < Drinks.Count; i++)
            {
                Drink d = new Drink(Drinks[i],Decimal.Parse(Prices[i]));
                DrinkList.Add(d);
            }
            
            csvDrinksIn.Close();
            return DrinkList;
        }

        public Drink GetDrink(string dName, List<Drink> inDrinks)
        {
            List<Drink> DrinkList = inDrinks;
            for (int i = 0; i< DrinkList.Count;i++)
            {
                if(DrinkList[i].DrinkName == dName)
                {
                    return DrinkList[i];           
                }
                
            }

             throw new System.InvalidOperationException("No drink found");
        }

        public List<Purchase> ReadPurchases(List<Drink> inDrinks)
        {
            List<Drink> DrinkList = inDrinks;
            List<Purchase> PurchaseList = new List<Purchase>();

            System.IO.StreamReader csvPurchasesIn = null;
            csvPurchasesIn = new System.IO.StreamReader("C:\\Users\\Matthew Summerbell\\source\\repos\\Hell or Glory Test Harness\\Hell or Glory Test Harness\\coffee shop monday sales.csv" );

            List<string> Drink = new List<string>();
            List<string> Roast = new List<string>();
            List<string> Quantity = new List<string>();
            List<string> Extra = new List<string>();

            while (!csvPurchasesIn.EndOfStream)
            {
                string line = csvPurchasesIn.ReadLine();
                string[] values = new string[] { };
                values = line.Split(',');
                

                Drink.Add(values[0].TrimStart());
                Roast.Add(values[1].TrimStart());
                Quantity.Add(values[2].TrimStart());
                Extra.Add(values[3].TrimStart());
            
            }
            csvPurchasesIn.Close();

            for (int i = 1; i < Drink.Count; i++)
            {
                switch (Drink[i])
                {
                    case "Espresso":

                        Drink Espresso = GetDrink("Espresso",DrinkList);
                        Purchase pEspresso = new Purchase(Espresso, Roast[i], int.Parse(Quantity[i]), Extra[i]);
                        PurchaseList.Add(pEspresso);
                        break;

                    case "Flat White":

                        Drink FlatWhite = GetDrink("Flat White",DrinkList);
                        Purchase pFlatWhite = new Purchase(FlatWhite, Roast[i], int.Parse(Quantity[i]), Extra[i]);
                        PurchaseList.Add(pFlatWhite);
                        break;

                    case "Double Espresso":

                        Drink DoubleEspresso = GetDrink("Double Espresso",DrinkList);
                        Purchase pDoubleEspresso = new Purchase(DoubleEspresso, Roast[i], int.Parse(Quantity[i]), Extra[i]);
                        PurchaseList.Add(pDoubleEspresso);
                        break;

                    case "Latte":

                        Drink Latte = GetDrink("Latte",DrinkList);
                        Purchase pLatte = new Purchase(Latte, Roast[i], int.Parse(Quantity[i]), Extra[i]);
                        PurchaseList.Add(pLatte);
                        break;

                    case "Americano":

                        Drink Americano = GetDrink("Americano",DrinkList);
                        Purchase pAmericano = new Purchase(Americano, Roast[i], int.Parse(Quantity[i]), Extra[i]);
                        PurchaseList.Add(pAmericano);
                        break;

                    case "White Americano":

                        Drink WhiteAmericano = GetDrink("White Americano",DrinkList);
                        Purchase pWhiteAmericano = new Purchase(WhiteAmericano, Roast[i], int.Parse(Quantity[i]), Extra[i]);
                        PurchaseList.Add(pWhiteAmericano);
                        break;

                }

            }
            return PurchaseList;
        }

   
        [TestMethod]
        public void MostPopularBlend()
        {
            // Assumption Blend defined as the roast
            List <Drink> DrinkList = ReadDrinks();
            List <Purchase> PurchaseList = ReadPurchases(DrinkList);
            Shop HellOrGlory = new Shop(DrinkList,PurchaseList);

            string actualBlend =  HellOrGlory.MostPopularBlend();
            string expectedBlend = "Full-City Roast";

            Assert.AreEqual(expectedBlend, actualBlend);

        }


        [TestMethod]
         public void DaysTakings()
         {
            List<Drink> DrinkList = ReadDrinks();
            List<Purchase> PurchaseList = ReadPurchases(DrinkList);
            Shop HellOrGlory = new Shop(DrinkList, PurchaseList);

            decimal expectedTakings = 76.26m;
            decimal actualTakings = HellOrGlory.DaysTakings(); 

            Assert.AreEqual(expectedTakings, actualTakings);
         }

         [TestMethod]
         public void MostPopularExtra()
         {
            List<Drink> DrinkList = ReadDrinks();
            List<Purchase> PurchaseList = ReadPurchases(DrinkList);
            Shop HellOrGlory = new Shop(DrinkList, PurchaseList);

            //Assumption number of extras = ExtraTotal + Quantity
            //string expectedExtra = "Soy";
            List<string> expectedExtra = new List<string>();
            expectedExtra.Add("soy");
            List<string> actualExtra = HellOrGlory.MostPopularExtra();

            //Assert.AreEqual(expectedExtra, actualExtra);
            CollectionAssert.AreEqual(expectedExtra, actualExtra);
            //collection assert

         }

         [TestMethod]
         public void CustomerExtraPercent()
         {
            List<Drink> DrinkList = ReadDrinks();
            List<Purchase> PurchaseList = ReadPurchases(DrinkList);
            Shop HellOrGlory = new Shop(DrinkList, PurchaseList);

            // If 21 Customers , 10 Extras sold = 47.62%

            //Assumption number of customers = 33 e.g Quanitity of drinks sold
            decimal expectedPercent = 54.5m;
            decimal actualPercent = HellOrGlory.CustomerExtraPercent();

            Assert.AreEqual(expectedPercent, actualPercent);
         }

    }
}





