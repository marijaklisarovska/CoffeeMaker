using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    // Customer's coffee order, if sugar selected, add 1,2 or 3 teaspoons
    public class CoffeeOrder {
        public CoffeeOption Option { get; set; }
        public bool AddSugar { get; set; }
        public int SugarTeaspoons { get; set; }

        public CoffeeOrder(string Optionname, bool AddSugar, int SugarTeaspoons)
        {
            this.Option = new CoffeeOption(Optionname, 0); // Initialize with default price
            this.Option.CoffeePrice = Option.CoffeePrice;
            this.AddSugar = AddSugar;
            if (AddSugar) this.SugarTeaspoons = 0;
            else this.SugarTeaspoons = SugarTeaspoons;
        }
    }
}
