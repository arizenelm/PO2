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
            Buttons = new Button[16];

            Buttons[0] = button0;
            Buttons[1] = button1;
            Buttons[2] = button2;
            Buttons[3] = button3;
            Buttons[4] = button4;
            Buttons[5] = button5;
            Buttons[6] = button6;
            Buttons[7] = button7;
            Buttons[8] = button8;
            Buttons[9] = button9;
            Buttons[10] = button10;
            Buttons[11] = button11;
            Buttons[12] = button12;
            Buttons[13] = button13;
            Buttons[14] = button14;
            Buttons[15] = button15;

            checkedListBox1.SetItemChecked(0, true);


            
        }

        private TCtrl<TPNumber> CtrlTPN;

        private Button[] Buttons;

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            label1.Focus();
            int n = Convert.ToInt32(domainUpDown1.SelectedItem.ToString());
            for (int i = 1; i < 16; i++)
                Buttons[i].Enabled = i < n ? true : false;
            richTextBox1.Text = CtrlTPN.Command(30 + n);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                    button0.PerformClick();
                    break;
                case Keys.D1:
                    button1.PerformClick();
                    break;
                case Keys.D2:
                    button2.PerformClick();
                    break;
                case Keys.D3:
                    button3.PerformClick();
                    break;
                case Keys.D4:
                    button4.PerformClick();
                    break;
                case Keys.D5:
                    button5.PerformClick();
                    break;
                case Keys.D6:
                    button6.PerformClick();
                    break;
                case Keys.D7:
                    button7.PerformClick();
                    break;
                case Keys.D8:
                    if ((e.Modifiers & Keys.Shift) == Keys.Shift)
                        buttonMul.PerformClick();
                    else
                        button8.PerformClick();
                    break;
                case Keys.D9:
                    button9.PerformClick();
                    break;
                case Keys.OemMinus:
                    buttonMin.PerformClick();
                    break;
                case Keys.Oemcomma:
                    buttonComma.PerformClick();
                    break;
                
                case Keys.Oemplus:
                    if ((e.Modifiers & Keys.Shift) == Keys.Shift)
                        buttonPlus.PerformClick();
                    else
                        buttonEq.PerformClick();
                    break;
                case Keys.Oem2:
                    buttonDelim.PerformClick();
                    break;

                case Keys.Back:
                    buttonC.PerformClick();
                    break;
                case Keys.Enter:
                    buttonEq.PerformClick();
                    break;
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(15);
        }

        private void buttonMpl_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(16);
            MemoryValue.Text = CtrlTPN.Memory.GetStr();
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(17);
            MemoryValue.Text = CtrlTPN.Memory.GetStr();
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(18);
            MemoryValue.Text = CtrlTPN.Memory.GetStr();
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(19);
            MemoryValue.Text = CtrlTPN.Memory.GetStr();
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(20);
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(21);
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(22);
        }

        private void buttonReverse_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(23);
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(24);
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(25);
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(26);
        }


        private void buttonMin_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(27);
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(28);
        }

        private void buttonDelim_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(29);
        }

        private void buttonSqr_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(30);
        }

        private void buttonInverse_Click(object sender, EventArgs e)
        {
            label1.Focus();
            richTextBox1.Text = CtrlTPN.Command(31);
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 1)
            {
                checkedListBox1.SetItemChecked(0, false);
                buttonComma.Enabled = true;
                richTextBox1.Text = CtrlTPN.Command(48);
            }
            else
            {
                checkedListBox1.SetItemChecked(1, false);
                buttonComma.Enabled = false;
                richTextBox1.Text = CtrlTPN.Command(47);
            }

        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {
            label1.Focus();
            int n = Convert.ToInt32(domainUpDown2.SelectedItem.ToString());
            richTextBox1.Text = CtrlTPN.Command(47 + n);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                richTextBox1.Text = CtrlTPN.Command(58);
            else
                richTextBox1.Text = CtrlTPN.Command(57);
            MemoryValue.Text = CtrlTPN.Memory.GetStr();
        }


    }
}
