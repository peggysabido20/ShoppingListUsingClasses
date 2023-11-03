using Microsoft.VisualBasic;
using System.Linq.Expressions;

namespace ShoppingListUsingClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int itemCount = 0;
            List<MenuItems> items = new List<MenuItems>();
            List<MenuItems> cartItems = new List<MenuItems>();
            Console.WriteLine("Welcome to Chirpus Market!");
            Console.Write("How many items do you want to enter? ");
            int numberInputItems = int.Parse(Console.ReadLine());
            Console.WriteLine($"Please enter {numberInputItems} items: ");
            while (itemCount < numberInputItems)
            {
                MenuItems menu = new MenuItems();
                itemCount++;
                Console.Write($"Enter item {itemCount} ID: ");
                string itemNmbr = Console.ReadLine();
                Console.Write($"Enter item {itemCount} Name: ");
                string itemNmbrName = Console.ReadLine();
                Console.Write($"Enter item {itemCount} Price: ");
                decimal itemNmbrPrice = decimal.Parse(Console.ReadLine());
                menu.itemID = itemNmbr;
                menu.itemName = itemNmbrName;
                menu.itemPrice = itemNmbrPrice;
                items.Add(menu);
            } // while (itemCount < 8)

            while (true)
            {
                printMenuList(items);
                Console.WriteLine();
                Console.Write("What item would you like to order? Please enter the item code or the item name: ");
                string userItem = Console.ReadLine().ToLower();

                

                var unitPrice1 = items.Where(x => x.itemID.ToLower() == userItem).Select(x => x.itemPrice);
                var unitPrice2 = items.Where(x => x.itemName.ToLower() == userItem).Select(x => x.itemPrice);
                Console.WriteLine(unitPrice1);
                Console.WriteLine(unitPrice2);

                // cartItems.Add( cartMenu );

                // OR

                bool itemExists = false;
                foreach (MenuItems item in items)
                {
                    if ((item.itemID.Trim().ToLower() == userItem.Trim().ToLower()) || (item.itemName.Trim().ToLower() == userItem.Trim().ToLower()))
                    {
                        createPurchaseList(cartItems, item);
                        itemExists = true;
                        break;
                    }
                }

                //var itemMax = items.Where(x => x.itemID == userItem).Max();
                //var itemMin = items.Where(x => x.itemID == userItem).Min();
                //var itemSum = items.Where(x => x.itemID == userItem).Sum();

                //var displayPrice = items.Where(x => x.itemID == userItem).Select(x => x.itemPrice).Max();

                var MaxPrice = items.Select(x => x.itemPrice).Max();

                if (!itemExists)
                {
                    Console.WriteLine("Sorry, we don't have those. Please try again");
                }

                if (!wantToContinue())
                {
                    break;
                }
            }

            foreach (MenuItems cart in cartItems)
            {
                Console.WriteLine($"{cart.itemID} {cart.itemName} {cart.itemPrice}");
            }

            //decimal sumItems = cartItems.Sum();
            //cartItems.Max(x => cartItems.(x));
            //int indexItem = 0;
            //if (sumItems > 0)
            //{
            //    Console.WriteLine("Thanks for your order!");
            //    Console.WriteLine("Here's what you got:");

            //    foreach (string item in menuItems)
            //    {
            //        indexItem = menuItems.IndexOf(item);
            //        sortedPurchaseList.Add(menuAmounts[indexItem], item);
            //    }

            //    foreach (KeyValuePair<double, string> kvp in sortedPurchaseList)
            //    {
            //        Console.WriteLine($"{kvp.Value,-14}${kvp.Key:F2}");
            //    }

            //    Console.WriteLine($"The total of your order is : {sumItems:F2}");
            //    indexItem = sortedPurchaseList.Count - 1;
            //    Console.WriteLine($"The more expensive item your ordered is : {sortedPurchaseList.Values[indexItem]} at ${sortedPurchaseList.Keys[indexItem]}");
            //    Console.WriteLine($"The more expensive item your ordered is : {sortedPurchaseList.Values[0]} at ${sortedPurchaseList.Keys[0]}");
            //    Console.WriteLine($"The total of your order is : ${menuAmounts.Sum():F2}");
            //    Console.WriteLine($"Average price per item in order was: ${menuAmounts.Average():F2}");



            //}

            static void printMenuList(List<MenuItems> menuList)
            {
                const int PADDING = -14;
                Console.WriteLine();
                Console.WriteLine($"{"ItemCode",PADDING}{"ItemName",PADDING}Price");
                Console.WriteLine($"{new string('-', 35)}");

                foreach (MenuItems item in menuList)
                {
                    Console.WriteLine($"{item.itemID,PADDING}{item.itemName,PADDING}{item.itemPrice}");
                }
            }

            static bool wantToContinue()
            {
                while (true)
                {
                    Console.Write("Would you like to order anything else (y/n)? ");
                    string answer = Console.ReadLine();
                    if (!string.IsNullOrEmpty(answer) && (answer.Trim().ToLower() == "n" || answer.Trim().ToLower() == "y"))
                    {
                        return (answer.Trim().ToLower() == "y");
                    }
                    Console.Write("Invalid entry, please enter y/n. Press any key .....");
                    string AnyKey = Console.ReadLine();
                }
            }

            static void createPurchaseList(List<MenuItems> cartItem, MenuItems item)
            {
                int itemIndex = cartItem.IndexOf(item);
                if (itemIndex < 0)
                {
                    cartItem.Add(item);
                }
                else
                {
                    cartItem[itemIndex].itemPrice += item.itemPrice;
                }
                Console.WriteLine($"Adding {item.itemName} to cart at ${item.itemPrice}");
            } // static void createPurchaseList
        }
    }
}