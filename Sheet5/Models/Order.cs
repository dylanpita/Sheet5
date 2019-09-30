using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sheet5.Models
{
    public class Order
    {
        public MealDeal mealDeal { get; set; }
        public SubTypes SubTypes { get; set; }
        public SubSizes SubSizes { get; set; }

        public int AmountWanted { get; set; } = 1;
    }

    public enum SubTypes
    {
        TheMichaelJackson,
        ThePrince,
        TheBackstreetBoys,
        TheBeyonce
    }
    public enum SubSizes
    {
        TheOneHitWonder,
        AList,
        BList,
        Superstar
    }
    public enum MealDeal
    {
        None,
        DrinkAndCookie,
        DrinkAndChips
    }
}