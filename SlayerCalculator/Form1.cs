using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlayerCalculator
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        /*
        * Tier Cost and EXP
        * 5: 100,000 Coins | 1,500 XP 
        * 4: 50,000 Coins | 500 XP
        * 3: 20,000 Coins | 100 XP
        * 2: 7,500 Coins | 25 XP
        * 1: 2,000 Coins | 5 XP
        */


        // variables
        int tier = 0;
        bool isXpPerk = false;
        bool isPricePerk = false;
        decimal pricePerSlayer = 0m;
        decimal xpPerSlayer = 0;
        decimal slayersLeft = 0;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tier = 1;
            main();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tier = 2;
            main();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            tier = 3;
            main();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            tier = 4;
            main();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            tier = 5;
            main();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isXpPerk = checkBox1.Checked;
            main();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            isPricePerk = checkBox2.Checked;
            main();
        }

        private void main()
        {
            decimal price = 0m;
            decimal xp = 0;
            switch (tier)
            {
                case 1:
                    price = 2000m;
                    xp = 5;
                    pricePerSlayer = isPricePerk ? (price / 2) : price;
                    xpPerSlayer = isXpPerk ? Decimal.Ceiling(xp * 1.25m) : xp;
                    break;
                case 2:
                    price = 7500m;
                    xp = 25;
                    pricePerSlayer = isPricePerk ? (price / 2) : price;
                    xpPerSlayer = isXpPerk ? Decimal.Ceiling(xp * 1.25m) : xp;
                    break;
                case 3:
                    price = 20000m;
                    xp = 100;
                    
                    pricePerSlayer = isPricePerk ? (price / 2) : price;
                    xpPerSlayer = isXpPerk ? Decimal.Ceiling(xp * 1.25m) : xp;
                    break;
                case 4:
                    price = 50000m;
                    xp = 500;
                    pricePerSlayer = isPricePerk ? (price / 2) : price;
                    xpPerSlayer = isXpPerk ? Decimal.Ceiling(xp * 1.25m) : xp;
                    break;
                case 5:
                    price = 100000m;
                    xp = 1500;
                    pricePerSlayer = isPricePerk ? (price / 2) : price;
                    xpPerSlayer = isXpPerk ? Decimal.Ceiling(xp * 1.25m) : xp;
                    break;
                default:
                    break;
            }
            decimal xpNeeded = 0;
            Decimal.TryParse(txtXpNeeded.Text, out xpNeeded);
            if (xpNeeded < 0)
            {
                txtXpNeeded.Text = "0";
            }

            // slayer left calculation
            try
            {
                decimal input = Convert.ToDecimal(txtXpNeeded.Text);
                slayersLeft = input / xpPerSlayer;
                txtSlayerLeft.Text = Decimal.Ceiling(slayersLeft).ToString();
                txtSlayerLeft.ForeColor = Color.Black;
            }
            catch
            {
                txtSlayerLeft.ForeColor = Color.Red;
                txtSlayerLeft.Text = "Invalid Input";
                slayersLeft = 0;
            }

            // total cost calculation
            try
            {
                txtTotalCost.ForeColor = Color.Black;
                txtTotalCost.Text = (slayersLeft * pricePerSlayer).ToString("C0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message);
                txtTotalCost.ForeColor = Color.Red;
                txtTotalCost.Text = "Invalid Input";
                
            }
            txtPricePerSlayer.Text = pricePerSlayer.ToString("C0");
            txtXpPerSlayer.Text = xpPerSlayer.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void TextChangedXpNeeded(object sender, EventArgs e)
        {
            main();
        }

        private void buttonAdd1_Click(object sender, EventArgs e)
        {
            try
            {
                txtXpNeeded.Text = (Convert.ToDecimal(txtXpNeeded.Text) - xpPerSlayer).ToString();
                main();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.GetType().ToString());
            }
        }

        private void buttonSub1_Click(object sender, EventArgs e)
        {
            try
            {
                txtXpNeeded.Text = (Convert.ToDecimal(txtXpNeeded.Text) + xpPerSlayer).ToString();
                main();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.GetType().ToString());
            }
        }

        private void lblLinkCredit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Averyyyyyyyy");
        }
    }
}
