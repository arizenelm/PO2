using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PO2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CtrlTPN = new TCtrl<TPNumber>();
        }

        private TCtrl<TPNumber> CtrlTPN;


        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(15);
        }

        private void buttonMpl_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(16);
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(17);
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(18);
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(19);
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(20);
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(21);
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(22);
        }

        private void buttonReverse_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(23);
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(24);
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(25);
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(26);
        }


        private void buttonMin_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(27);
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(28);
        }

        private void buttonDelim_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(29);
        }

        private void buttonSqr_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(30);
        }

        private void buttonInverse_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CtrlTPN.Command(31);
        }


    }
}
