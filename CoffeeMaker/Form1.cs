using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<CoffeeOption> coffees = new List<CoffeeOption>
            {
                new CoffeeOption("Espresso", 1.50m),
                new CoffeeOption("Americano", 1.50m),
                new CoffeeOption("Macchiato", 2.00m),
                new CoffeeOption("Cappuccino", 2.50m),
                new CoffeeOption("Latte", 2.50m),
                new CoffeeOption("Mocha", 3.00m)
            };

            rbEspresso.Tag = coffees[0];
            rbAmericano.Tag = coffees[1];
            rbMacchiato.Tag = coffees[2];
            rbCappuccino.Tag = coffees[3];
            rbLatte.Tag = coffees[4];
            rbMocha.Tag = coffees[5];

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMakeCoffee_Click(object sender, EventArgs e)
        {
            CoffeeOption selectedCoffee = null;

            if (rbEspresso.Checked)
                selectedCoffee = (CoffeeOption)rbEspresso.Tag;
            else if (rbAmericano.Checked)
                selectedCoffee = (CoffeeOption)rbAmericano.Tag;
            else if (rbMacchiato.Checked)
                selectedCoffee = (CoffeeOption)rbMacchiato.Tag;
            else if (rbCappuccino.Checked)
                selectedCoffee = (CoffeeOption)rbCappuccino.Tag;
            else if (rbLatte.Checked)
                selectedCoffee = (CoffeeOption)rbLatte.Tag;
            else if (rbMocha.Checked)
                selectedCoffee = (CoffeeOption)rbMocha.Tag;

            if (selectedCoffee == null)
            {
                MessageBox.Show("Please select a coffee.");
                return;
            }

            using (var moneyForm = new InsertMoneyForm())
            {
                var result = moneyForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    decimal insertedMoney = moneyForm.InsertedMoney;

                    if (insertedMoney < selectedCoffee.CoffeePrice)
                    {
                        MessageBox.Show("Not enough money. Please insert more.");
                        return; 
                    }

                    decimal change = insertedMoney - selectedCoffee.CoffeePrice;

                    MessageBox.Show($"Thank you! Change: ${change:F2}");

                    var progress = new FormBillAndProgress(); //todo
                    progress.Show();

                }
            }

        }

        private void CoffeeSelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void rbEspresso_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
