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
    public partial class Settings : Form
    {
        public double opacity = 1;

        public Settings()
        {
            InitializeComponent();
            chkAlwaysTop.Checked = Calculator.mainInstance.TopMost;
            tbOpacity.Value = Convert.ToInt32(Calculator.mainInstance.Opacity * 100);
            this.TopMost = true;
            this.Focus();
        }

        private void chkAlwaysTop_CheckedChanged(object sender, EventArgs e)
        {
            Calculator.mainInstance.TopMost = chkAlwaysTop.Checked;
            this.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbOpacity_Scroll(object sender, EventArgs e)
        {
            opacity = Convert.ToDouble(tbOpacity.Value) / 100;
            Calculator.mainInstance.Opacity = opacity;
            lblOpacity.Text = opacity.ToString();
        }
    }
}
