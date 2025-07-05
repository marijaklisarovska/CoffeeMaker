using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CoffeeMaker
{
    public partial class FormBillAndProgress : Form
    {
        // initial values of selected coffee option and sugar amount
        CoffeeOption selectedCoffee = new CoffeeOption(null, 0);
        int sugar = 0;
        bool addSugar = false;
        

        public FormBillAndProgress(string selectedCoffee, bool addSugar, int sugar)
        {
            InitializeComponent();
            this.Paint += FormBillAndProgress_Paint;
            this.selectedCoffee.CoffeeName = selectedCoffee;
            this.sugar = sugar;
            this.addSugar = addSugar;
        }


        //Ingredient Colors
        public static readonly Dictionary<string, Color> SegmentColors = new Dictionary<string, Color>()
        {
            ["espresso"] = Color.SaddleBrown,
            ["water"] = Color.SkyBlue,
            ["milk"] = Color.Bisque,
            ["foam"] = Color.LightGreen,
            ["cream"] = Color.MintCream,
            ["chocolate syrup"] = Color.Chocolate,
            ["sugar"] = Color.SandyBrown
        };

        public static readonly Dictionary<string, int[]> Recipes = new Dictionary<string, int[]>()
        {
            // 100% of cup fill is 221 px in height, the recipes are given in 85% of 221 (187.85), which is 100% fill of coffee, leaving 15% for sugar (5% each teaspoon)
            // max width of cup is 340 px
            ["Espresso"] = new[] { 56 }, // 30% espresso, 30% fill
            ["Americano"] = new[] { 56, 120 }, // 30% espresso, 70% water, 90% fill
            ["Macchiato"] = new[] { 56, 38}, // 30% espresso, 20% foam, 50% fill
            ["Latte"] = new[] {56, 85, 30}, // 30% espresso, 50% milk, 20% foam,  90% fill 
            ["Mocha"] = new[] { 56, 30, 56, 30 }, // 30% espresso, 20% chocolate syrup, 30% milk, 20% cream, 90% fill
            ["Cappuccino"] = new[] { 56, 53, 62 }, // 30% espresso, 30% milk, 40% foam, 90% fill
            ["Sugar"] = new[] { 5 } // sugar teaspoon 5%
        };

        public void FormBillAndProgress_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            CoffeeOrder order = new CoffeeOrder(selectedCoffee.CoffeeName, addSugar, sugar);

            double previous_y = 0.0;
            if (order.Option.CoffeeName == "Espresso")
            {
                previous_y = 0.0;
                Animation.fillSegment(e.Graphics, "espresso", 0.0, Recipes["Espresso"].ElementAt(0), SegmentColors["espresso"]);
                previous_y = Recipes["Espresso"].ElementAt(0);
            }
            else if (order.Option.CoffeeName == "Americano")
            {
                previous_y = 0.0;
                Animation.fillSegment(e.Graphics, "espresso", 0.0, Recipes["Americano"].ElementAt(0), SegmentColors["espresso"]);
                previous_y = Recipes["Americano"].ElementAt(0);
                Animation.fillSegment(e.Graphics, "water", previous_y, Recipes["Americano"].ElementAt(1), SegmentColors["water"]);
                previous_y += Recipes["Americano"].ElementAt(1);
            }
            else if (order.Option.CoffeeName == "Macchiato")
            {
                previous_y = 0.0;
                Animation.fillSegment(e.Graphics, "espresso", 0.0, Recipes["Macchiato"].ElementAt(0), SegmentColors["espresso"]);
                previous_y = Recipes["Macchiato"].ElementAt(0);
                Animation.fillSegment(e.Graphics, "foam", previous_y, Recipes["Macchiato"].ElementAt(1), SegmentColors["foam"]);
                previous_y += Recipes["Macchiato"].ElementAt(1);
            }
            else if (order.Option.CoffeeName == "Latte")
            {
                previous_y = 0.0;
                Animation.fillSegment(e.Graphics, "espresso", 0.0, Recipes["Latte"].ElementAt(0), SegmentColors["espresso"]);
                previous_y = Recipes["Latte"].ElementAt(0);
                Animation.fillSegment(e.Graphics, "milk", previous_y, Recipes["Latte"].ElementAt(1), SegmentColors["milk"]);
                previous_y += Recipes["Latte"].ElementAt(1);
                Animation.fillSegment(e.Graphics, "foam", previous_y, Recipes["Latte"].ElementAt(2), SegmentColors["foam"]);
                previous_y += Recipes["Latte"].ElementAt(2);
            }
            else if (order.Option.CoffeeName == "Cappuccino")
            {
                previous_y = 0.0;
                Animation.fillSegment(e.Graphics, "espresso", 0.0, Recipes["Cappuccino"].ElementAt(0), SegmentColors["espresso"]);
                previous_y = Recipes["Cappuccino"].ElementAt(0);
                Animation.fillSegment(e.Graphics, "milk", previous_y, Recipes["Cappuccino"].ElementAt(1), SegmentColors["milk"]);
                previous_y += Recipes["Cappuccino"].ElementAt(1);
                Animation.fillSegment(e.Graphics, "foam", previous_y, Recipes["Cappuccino"].ElementAt(2), SegmentColors["foam"]);
                previous_y += Recipes["Cappuccino"].ElementAt(2);
            }
            else if (order.Option.CoffeeName == "Mocha")
            {
                previous_y = 0.0;
                Animation.fillSegment(e.Graphics, "espresso", 0.0, Recipes["Mocha"].ElementAt(0), SegmentColors["espresso"]);
                previous_y = Recipes["Mocha"].ElementAt(0);
                Animation.fillSegment(e.Graphics, "chocolate syrup", previous_y, Recipes["Mocha"].ElementAt(1), SegmentColors["chocolate syrup"]);
                previous_y += Recipes["Mocha"].ElementAt(1);
                Animation.fillSegment(e.Graphics, "milk", previous_y, Recipes["Mocha"].ElementAt(2), SegmentColors["milk"]);
                previous_y += Recipes["Mocha"].ElementAt(2);
                Animation.fillSegment(e.Graphics, "cream", previous_y, Recipes["Mocha"].ElementAt(3), SegmentColors["cream"]);
                previous_y += Recipes["Mocha"].ElementAt(3);
            }

            if (order.AddSugar)
            {
                Animation.fillSegment(e.Graphics, "sugar", previous_y, Recipes["Sugar"].ElementAt(0) * sugar, SegmentColors["sugar"]);
            }
        }

        private void btnOrderAgain_Click(object sender, EventArgs e)
        {
            FormBillAndProgress.ActiveForm.Close();
            Form1 form = new Form1();
        }
    }
}
