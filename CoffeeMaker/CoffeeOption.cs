using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class CoffeeOption
    {
        public string CoffeeName { get; set; }
        public decimal CoffeePrice { get; set; }

        public CoffeeOption(string coffeeName, decimal coffeePrice)
        {
            CoffeeName = coffeeName;
            CoffeePrice = coffeePrice;
        }

        public override string ToString()
        {
            return CoffeeName;
        }
    }
}
