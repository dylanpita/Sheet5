using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sheet5.Models
{
    public class Receipt
    {
        public string SubType { get; set; }
        public string SubSize { get; set; }
        public string MealDeal { get; set; }
        public int AmountWanted { get; set; }
        public double mealDealPrice { get; set; }
        public double totalSubPrice { get; set; }
        public double totalReceiptCost { get; set; }

        public static double GST = 0.05;
        public static double QST = 0.09975;

        public DateTime getDate()
        {
            return DateTime.UtcNow;
        }
        public double getTaxes()
        {
            return Math.Round(totalReceiptCost * (GST + QST), 2);
        }
        public double getTotalPrice()
        {
            return totalReceiptCost + getTaxes();
        }

    }
}