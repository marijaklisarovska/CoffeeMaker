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
        private RadioButton _currentlySelectedCoffee = null;

        int sugar = 0;
        CoffeeOption selectedCoffee = null;
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

            // Coffee selection radio buttons
            rbEspresso.CheckedChanged += CoffeeSelectionChanged;
            rbAmericano.CheckedChanged += CoffeeSelectionChanged;
            rbMacchiato.CheckedChanged += CoffeeSelectionChanged;
            rbLatte.CheckedChanged += CoffeeSelectionChanged;
            rbCappuccino.CheckedChanged += CoffeeSelectionChanged;
            rbMocha.CheckedChanged += CoffeeSelectionChanged;

            // Sugar checkboxes
            cbSugarEspresso.CheckedChanged += cbSugarEspresso_CheckedChanged;
            cbSugarAmericano.CheckedChanged += cbSugarAmericano_CheckedChanged;
            cbSugarMacchiato.CheckedChanged += cbSugarMacchiato_CheckedChanged;
            cbSugarLatte.CheckedChanged += cbSugarLatte_CheckedChanged;
            cbSugarCappuccino.CheckedChanged += cbSugarCappuccino_CheckedChanged;
            cbSugarMocha.CheckedChanged += cbSugarMocha_CheckedChanged;

            //  Hide all sugar options at startup
            HideAllSugarControls();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private decimal GetTotalPrice()
        {

            // Get selected coffee
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
                return 0m;

            setOption(selectedCoffee);
            // Count sugar checkboxes for selected coffee

            decimal totalPrice =selectedCoffee.CoffeePrice;
            

            if (rbEspresso.Checked && cbSugarEspresso.Checked)
            {
                if (rbEspresso1.Checked) { totalPrice += 0.20m; sugar = 1; }
                if (rbEspresso2.Checked) {totalPrice += 2 * 0.20m; sugar = 2; }
                if (rbEspresso3.Checked) {totalPrice += 3 * 0.20m; sugar = 3; }
            }
            else if (rbAmericano.Checked && cbSugarAmericano.Checked)
            {
                if (rbAmericano1.Checked) { totalPrice += 0.20m; sugar = 1; }
                if (rbAmericano2.Checked) { totalPrice += 2 * 0.20m; sugar = 2; }
                if (rbAmericano3.Checked) { totalPrice += 3 * 0.20m; sugar = 3; }
            }
            else if (rbMacchiato.Checked && cbSugarMacchiato.Checked)
            {
                if (rbMacchiato1.Checked) { totalPrice += 0.20m; sugar = 1; }
                if (rbMacchiato2.Checked) { totalPrice += 2 * 0.20m; sugar = 2; }
                if (rbMacchiato3.Checked) { totalPrice += 3 * 0.20m; sugar = 3; }
            }
            else if (rbCappuccino.Checked && cbSugarCappuccino.Checked)
            {
                if (rbCappuccino1.Checked) { totalPrice += 0.20m; sugar = 1; }
                if (rbCappuccino2.Checked) { totalPrice += 2 * 0.20m; sugar = 2; }
                if (rbCappuccino3.Checked) { totalPrice += 3 * 0.20m; sugar = 3; }
            }
            else if (rbLatte.Checked && cbSugarLatte.Checked)
            {
                if (rbLatte1.Checked) { totalPrice += 0.20m; sugar = 1; }
                if (rbLatte2.Checked) { totalPrice += 2 * 0.20m; sugar = 2; }
                if (rbLatte3.Checked) { totalPrice += 3 * 0.20m; sugar = 3; }
            }
            else if (rbMocha.Checked && cbSugarMocha.Checked)
            {
                if (rbMocha1.Checked) { totalPrice += 0.20m; sugar = 1; }
                if (rbMocha2.Checked) { totalPrice += 2 * 0.20m; sugar = 2; }
                if (rbMocha3.Checked) { totalPrice += 3 * 0.20m; sugar = 3; }
            }

            decimal sugarPricePerUnit = 0.20m;
            setSugar(sugar);
            return totalPrice;
        }

        public void setSugar(int sugar)
        {
            this.sugar = sugar;
        }

        public void setOption(CoffeeOption option)
        {
            selectedCoffee = option;
        }
        
        private void btnMakeCoffee_Click(object sender, EventArgs e)
        {
            decimal totalPrice = GetTotalPrice();

            if (totalPrice == 0m)
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

                    if (insertedMoney < totalPrice)
                    {
                        MessageBox.Show($"Not enough money. Please insert at least ${totalPrice:F2}.");
                        return;
                    }

                    decimal change = insertedMoney - totalPrice;

                    MessageBox.Show($"Thank you! Change: ${change:F2}");

                    bool addSugar = false;
                    if (sugar == 0) addSugar = false; else addSugar = true;
                    var progress = new FormBillAndProgress(selectedCoffee.CoffeeName, addSugar, sugar); // visualization
                    progress.Show();

                    //reseting buttons and values when ordering again
                    cbSugarAmericano.Checked = false;
                    cbSugarEspresso.Checked = false;    
                    cbSugarMacchiato.Checked = false;
                    cbSugarLatte.Checked = false;
                    cbSugarCappuccino.Checked = false;
                    cbSugarMocha.Checked = false;
                    sugar = 0;
                    addSugar = false;
                }
            }
        }

        private void HideAllSugarControls()
        {
            cbSugarEspresso.Visible = false;
            cbSugarAmericano.Visible = false;
            cbSugarMacchiato.Visible = false;
            cbSugarLatte.Visible = false;
            cbSugarCappuccino.Visible = false;
            cbSugarMocha.Visible = false;

            // Espresso sugar radios
            rbEspresso1.Visible = false;
            rbEspresso2.Visible = false;
            rbEspresso3.Visible = false;

            // Americano sugar radios
            rbAmericano1.Visible = false;
            rbAmericano2.Visible = false;
            rbAmericano3.Visible = false;

            // Macchiato sugar radios
            rbMacchiato1.Visible = false;
            rbMacchiato2.Visible = false;
            rbMacchiato3.Visible = false;

            // Cappuccino sugar radios
            rbCappuccino1.Visible = false;
            rbCappuccino2.Visible = false;
            rbCappuccino3.Visible = false;

            // Latte sugar radios
            rbLatte1.Visible = false;
            rbLatte2.Visible = false;
            rbLatte3.Visible = false;

            // Mocha sugar radios
            rbMocha1.Visible = false;
            rbMocha2.Visible = false;
            rbMocha3.Visible = false;

        }

        private void CoffeeSelectionChanged(object sender, EventArgs e)
        {
            var selectedRadio = sender as RadioButton;
            if (selectedRadio == null || !selectedRadio.Checked)
                return; // Only act when a coffee radio button is checked (not unchecked)

            // Check if it's a new coffee selection, otherwise ignore
            if (_currentlySelectedCoffee == selectedRadio)
                return; // No change, ignore

            _currentlySelectedCoffee = selectedRadio;

            HideAllSugarControls();

            if (rbEspresso.Checked)
            {
                cbSugarEspresso.Visible = true;
                if (cbSugarEspresso.Checked)
                {
                    rbEspresso1.Visible = true;
                    rbEspresso2.Visible = true;
                    rbEspresso3.Visible = true;
                }
            }
            else if (rbAmericano.Checked)
            {
                cbSugarAmericano.Visible = true;
                if (cbSugarAmericano.Checked)
                {
                    rbAmericano1.Visible = true;
                    rbAmericano2.Visible = true;
                    rbAmericano3.Visible = true;
                }
            }
            else if (rbMacchiato.Checked)
            {
                cbSugarMacchiato.Visible = true;
                if (cbSugarMacchiato.Checked)
                {
                    rbMacchiato1.Visible = true;
                    rbMacchiato2.Visible = true;
                    rbMacchiato3.Visible = true;
                }
            }
            else if (rbLatte.Checked)
            {
                cbSugarLatte.Visible = true;
                if (cbSugarLatte.Checked)
                {
                    rbLatte1.Visible = true;
                    rbLatte2.Visible = true;
                    rbLatte3.Visible = true;
                }
            }
            else if (rbCappuccino.Checked)
            {
                cbSugarCappuccino.Visible = true;
                if (cbSugarCappuccino.Checked)
                {
                    rbCappuccino1.Visible = true;
                    rbCappuccino2.Visible = true;
                    rbCappuccino3.Visible = true;
                }
            }
            else if (rbMocha.Checked)
            {
                cbSugarMocha.Visible = true;
                if (cbSugarMocha.Checked)
                {
                    rbMocha1.Visible = true;
                    rbMocha2.Visible = true;
                    rbMocha3.Visible = true;
                }
            }
        }


        private void rbEspresso_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbSugarEspresso_CheckedChanged(object sender, EventArgs e)
        {
            bool show = cbSugarEspresso.Checked;
            rbEspresso1.Visible = true;
            rbEspresso2.Visible = true;
            rbEspresso3.Visible = true;

            if (!show)
            {
                rbEspresso1.Visible = false;
                rbEspresso2.Visible = false;
                rbEspresso3.Visible = false;
            }
        }

        private void cbSugarAmericano_CheckedChanged(object sender, EventArgs e)
        {
            bool show = cbSugarAmericano.Checked;
            rbAmericano1.Visible = show;
            rbAmericano2.Visible = show;
            rbAmericano3.Visible = show;

            if (!show)
            {
                rbAmericano1.Checked = false;
                rbAmericano2.Checked = false;
                rbAmericano3.Checked = false;
            }
        }

        private void cbSugarMacchiato_CheckedChanged(object sender, EventArgs e)
        {
            bool show = cbSugarMacchiato.Checked;
            rbMacchiato1.Visible = show;
            rbMacchiato2.Visible = show;
            rbMacchiato3.Visible = show;

            if (!show)
            {
                rbMacchiato1.Checked = false;
                rbMacchiato2.Checked = false;
                rbMacchiato3.Checked = false;
            }
        }

        private void cbSugarCappuccino_CheckedChanged(object sender, EventArgs e)
        {
            bool show = cbSugarCappuccino.Checked;
            rbCappuccino1.Visible = show;
            rbCappuccino2.Visible = show;
            rbCappuccino3.Visible = show;

            if (!show)
            {
                rbCappuccino1.Checked = false;
                rbCappuccino2.Checked = false;
                rbCappuccino3.Checked = false;
            }
        }

        private void cbSugarLatte_CheckedChanged(object sender, EventArgs e)
        {
            bool show = cbSugarLatte.Checked;
            rbLatte1.Visible = show;
            rbLatte2.Visible = show;
            rbLatte3.Visible = show;

            if (!show)
            {
                rbLatte1.Checked = false;
                rbLatte2.Checked = false;
                rbLatte3.Checked = false;
            }
        }

        private void cbSugarMocha_CheckedChanged(object sender, EventArgs e)
        {
            bool show = cbSugarMocha.Checked;
            rbMocha1.Visible = show;
            rbMocha2.Visible = show;
            rbMocha3.Visible = show;

            if (!show)
            {
                rbMocha1.Checked = false;
                rbMocha2.Checked = false;
                rbMocha3.Checked = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
