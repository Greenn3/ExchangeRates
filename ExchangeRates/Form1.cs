using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeRates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
             ApiHelper.InitializeClient();
           
        }

        private async void buttonOK_Click(object sender, EventArgs e)
        {
            string code = comboBox.Text;
            string rate = await ExchangeRateProcessor.LoadData(code);
            textBoxDisplay.Text = rate;

            //  textBoxDisplay.Text = await ExchangeRateProcessor.LoadData();
           // Console.WriteLine(await ExchangeRateProcessor.LoadData());
        }
    }
}
