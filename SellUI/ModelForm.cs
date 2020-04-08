using ProductSell.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SellUI
{
    public partial class ModelForm : Form
    {
        ShopModel model = new ShopModel();
        public ModelForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var cashboxs = new List<CashView>();
            for (int i = 0; i < model.Cashs.Count; i++)
            {
                var box = new CashView(model.Cashs[i], i, 10, 26 * i);
                cashboxs.Add(box);
                Controls.Add(box.CashName);
                Controls.Add(box.NumericUpDown);
                Controls.Add(box.ProgressBar);
                Controls.Add(box.CustomerCount);
            }

            model.Start();
        }
        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }
    }
}
