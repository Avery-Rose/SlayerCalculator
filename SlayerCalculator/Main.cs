﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlayerCalculator
{
    public partial class Calculator : System.Windows.Forms.Form
    {
        public static Calculator mainInstance;

        public Calculator()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            mainInstance = this;
        }

        private const string UPDATE_URL = "https://api.github.com/repos/Averyyyyyyyy/SlayerCalculator/releases/latest";

        private static readonly HttpClient client = new HttpClient();

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

        private void lblLinkRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Averyyyyyyyy/SlayerCalculator");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show(this);
        }

        /*private static async Task<Object> checkUpdate()
        {
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            //var streamTask = client.GetStreamAsync(UPDATE_URL);
            //return await JsonSerializer.DeserializeAsync<Object>(await streamTask);
        }*/

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Averyyyyyyyy/SlayerCalculator/releases");
            // get tag name
            // get browser_download_url
            //var request = await checkUpdate();
            //MessageBox.Show(request.ToString());
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "1.1.1";
        }
    }
}
