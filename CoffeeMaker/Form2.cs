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
    public partial class InsertMoneyForm : Form
    {

        public decimal InsertedMoney { get; private set; }
        public InsertMoneyForm()
        {
            InitializeComponent();
        }

        private void btnProceedBill_Click(object sender, EventArgs e)
        {
            InsertedMoney = nudMoney.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
