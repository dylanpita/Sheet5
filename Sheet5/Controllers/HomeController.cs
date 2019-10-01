using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sheet5.Models;

namespace Sheet5.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Receipt(Order newOrder)
        {
            Receipt receipt = new Receipt();

            double[] typePrices = new double[] { 5.00, 6.00, 7.00, 8.00 };
            receipt.SubType = Enum.GetName(typeof(SubTypes), newOrder.SubTypes);
            var priceOfSelectedSubType = typePrices[(int)newOrder.SubTypes];

            double[] sizePrices = new double[] { 2.00, 2.50, 3.00, 3.50 };
            receipt.SubSize = Enum.GetName(typeof(SubSizes), newOrder.SubSizes);
            var priceOfSelectedSubSize = sizePrices[(int)newOrder.SubTypes];

            double[] mealDealPrices = new double[] { 0.00, 1.00, 2.50 };
            receipt.MealDeal = Enum.GetName(typeof(MealDeal), newOrder.mealDeal);
            var priceOfSelectedMealDeal = mealDealPrices[(int)newOrder.mealDeal];
            receipt.mealDealPrice = priceOfSelectedMealDeal;

            receipt.AmountWanted = newOrder.AmountWanted;

            receipt.totalSubPrice = Math.Round(priceOfSelectedSubType * priceOfSelectedSubSize, 2);
            receipt.totalReceiptCost = Math.Round((receipt.totalSubPrice + priceOfSelectedMealDeal) * receipt.AmountWanted, 2);

            var receipts = new List<Receipt>();


            if (Session["Receipts"] != null)
            {
                receipts = (List<Receipt>) Session["Receipts"]; 
            }

            receipts.Add(receipt);
            Session["Receipts"] = receipts;
            return View(receipt);
        }

        public ActionResult DailyTotal()
        {
            var receipts = new List<Receipt>();


            if (Session["Receipts"] != null)
            {
                receipts = (List<Receipt>)Session["Receipts"];
            }

            double taxesTotal = 0;
            double incomeTotal = 0;
            foreach (var receipt in receipts)
            {
                taxesTotal += receipt.getTaxes();
                incomeTotal += receipt.getTotalPrice();
            }
            ViewData["receipts"] = receipts;
            ViewData["taxesTotal"] = taxesTotal;
            ViewData["incomeTotal"] = incomeTotal;
            return View();
        }
    }
}