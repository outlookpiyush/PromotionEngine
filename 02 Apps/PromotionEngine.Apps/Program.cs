using PromotionEngine.Logic.Entities.Transactions;
using PromotionEngine.Logic.Implementations.DataTags.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Logic.Implementations.DataUnits;

namespace PromotionEngine.Apps
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataUnitDetails = new DataUnitDetails(); // Declare Data Unit Details For Printing
            var cartItemDetails = new List<CartItemDetails>(); // Declare CardItem List Object

            Main:
            Console.Clear();
            Console.WriteLine("\n\tPlease select any of the list\n\n\n");
            Console.WriteLine("\t1. Add Product To Cart");
            Console.WriteLine("\t2. View Cart Item");
            Console.WriteLine("\t3. Print Bill");
            Console.WriteLine("\t4. Exit");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\n\tYou Choose : Add Product To Cart\n\n\n");
                    Console.WriteLine("\tPlease Enter Product SKU (eg. A,B,C Or D :)");
                    string productSKU = Console.ReadLine();
                    Console.WriteLine("\tPlease Enter Product Qty To Buy :");
                    int productQty = Convert.ToInt32(Console.ReadLine());
                    cartItemDetails.Add(new CartItemDetails { SKUName = productSKU, SKUQty = productQty, IsApplyPromo = false });
                    goto Main;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\n\tYou Choose : View Card Item\n\n\n");
                    Console.WriteLine($"Sr#\tSKU\tQty");
                    Console.WriteLine($"---\t---\t---");
                    for (int i=0;i< cartItemDetails.Count;i++)
                    {
                        Console.WriteLine($"{i + 1}\t{cartItemDetails[i].SKUName.ToUpper()}\t{string.Format("{0:0.00}", cartItemDetails[i].SKUQty)}");
                    }
                    Console.WriteLine($"     \t   \t-----");
                    Console.WriteLine($"Total Qty.\t{string.Format("{0:0.00}", cartItemDetails.Sum(s => s.SKUQty))}");
                    Console.ReadLine();
                    goto Main;
                case 3:
                    Console.Clear();
                    Console.WriteLine("\n\tYou Choose : View Card Item\n\n\n");
                    Console.WriteLine($"Sr#\tSKU\tQty\tPrice");
                    Console.WriteLine($"---\t---\t---\t-----");
                    cartItemDetails = dataUnitDetails.GetBillDetails(cartItemDetails);
                    for (int i = 0; i < cartItemDetails.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}\t{cartItemDetails[i].SKUName.ToUpper()}\t{cartItemDetails[i].SKUQty}\t{string.Format("{0:0.00}", cartItemDetails[i].TotalAmount)}");
                    }
                    Console.WriteLine($"---\t---\t---\t-----");
                    Console.WriteLine($"   \t   \t   \t{string.Format("{0:0.00}", cartItemDetails.Sum(s => s.TotalAmount))}");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Press any key for exit");
                    Console.ReadLine();
                    break;
            }

            
        }
    }
}
