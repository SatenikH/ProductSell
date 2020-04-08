using ProductSell.Model;
using System;
using System.Windows.Forms;

namespace SellUI
{
    public class CashView
    {
        Cash cash;
        public Label CashName { get; set; } 
        public NumericUpDown NumericUpDown { get; set; }
        public ProgressBar ProgressBar { get; set; }
        public Label CustomerCount { get; set; }
        public CashView(Cash cash, int number, int x, int y)
        {
            this.cash = cash;

            CashName = new Label();
            NumericUpDown = new NumericUpDown();
            ProgressBar = new ProgressBar();
            CustomerCount = new Label();

            CashName.AutoSize = true;
            CashName.Location = new System.Drawing.Point(x, y);
            CashName.Name = "label1" + number;
            CashName.Size = new System.Drawing.Size(35, 13);
            CashName.TabIndex = number;
            CashName.Text = cash.ToString();

            NumericUpDown.Location = new System.Drawing.Point(x + 70, y);
            NumericUpDown.Name = "numericUpDown" + number;
            NumericUpDown.Size = new System.Drawing.Size(120, 20);
            NumericUpDown.Maximum = 10000000000000000;
            NumericUpDown.TabIndex = number;

            ProgressBar.Location = new System.Drawing.Point(x + 300, y);
            ProgressBar.Maximum = cash.MaxQueueCount;
            ProgressBar.Name = "progressBar" + number;
            ProgressBar.Size = new System.Drawing.Size(100, 23);
            ProgressBar.TabIndex = number;
            ProgressBar.Value = 0;

            CustomerCount.AutoSize = true;
            CustomerCount.Location = new System.Drawing.Point(x + 400, y);
            CustomerCount.Name = "label2" + number;
            CustomerCount.Size = new System.Drawing.Size(35, 13);
            CustomerCount.TabIndex = number;
            CustomerCount.Text = "";

            cash.checkClosed += Cash_checkClosed;
        }
        private void Cash_checkClosed(object sender, Check e)
        {
            NumericUpDown.Invoke((Action)delegate
            { 
                NumericUpDown.Value = e.Price;
                ProgressBar.Value = cash.Count;
                CustomerCount.Text = cash.ExitCustomer.ToString();
            });
        }
    }
}
