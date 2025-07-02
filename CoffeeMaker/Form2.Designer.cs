namespace CoffeeMaker
{
    partial class InsertMoneyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nudMoney = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProceedBill = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMoney)).BeginInit();
            this.SuspendLayout();
            // 
            // nudMoney
            // 
            this.nudMoney.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudMoney.Location = new System.Drawing.Point(163, 99);
            this.nudMoney.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudMoney.Name = "nudMoney";
            this.nudMoney.Size = new System.Drawing.Size(200, 20);
            this.nudMoney.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(155, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 45);
            this.label2.TabIndex = 25;
            this.label2.Text = "Insert Money";
            // 
            // btnProceedBill
            // 
            this.btnProceedBill.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnProceedBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceedBill.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceedBill.ForeColor = System.Drawing.Color.White;
            this.btnProceedBill.Location = new System.Drawing.Point(22, 147);
            this.btnProceedBill.Name = "btnProceedBill";
            this.btnProceedBill.Size = new System.Drawing.Size(237, 41);
            this.btnProceedBill.TabIndex = 26;
            this.btnProceedBill.Text = "Proceed";
            this.btnProceedBill.UseVisualStyleBackColor = false;
            this.btnProceedBill.Click += new System.EventHandler(this.btnProceedBill_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(281, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(237, 41);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Back to Selection";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // InsertMoneyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CoffeeMaker.Properties.Resources.beige_background;
            this.ClientSize = new System.Drawing.Size(530, 247);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnProceedBill);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudMoney);
            this.Name = "InsertMoneyForm";
            this.Text = "InsertMoney";
            ((System.ComponentModel.ISupportInitialize)(this.nudMoney)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnProceedBill;
        private System.Windows.Forms.Button btnCancel;
    }
}