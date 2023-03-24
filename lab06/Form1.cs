using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            foreach (TextBox textbox in Controls.OfType<TextBox>()) 
                textbox.Text = "";
        }

        private void plusbutton_Click(object sender, EventArgs e)
        {
            int maxLen = 1 +
                Math.Max(FirstNumberTextBox.Text.Length, 
                SecondNumberTextBox.TextLength);
            int[] number1= new int[maxLen];
            int[] number2 = new int[maxLen];
            int[] sum = new int[maxLen];
            int[] extra = new int[maxLen];
            int numberIdx, textIdx;
            numberIdx = maxLen  - 1;
            textIdx = FirstNumberTextBox.Text.Length - 1;
            while (textIdx >= 0)
            {
                number1[numberIdx] = (FirstNumberTextBox.Text[textIdx] - '0');
                textIdx--;
                numberIdx--;
            }
            numberIdx = maxLen - 1;
            textIdx = SecondNumberTextBox.Text.Length - 1;
            while (textIdx >= 0)
            {
                number2[numberIdx] = (SecondNumberTextBox.Text[textIdx] - '0');
                textIdx--;
                numberIdx--;
            }
            for(numberIdx = maxLen - 1; numberIdx > 0;numberIdx--) 
            {
                sum[numberIdx] = (number1[numberIdx] + number2[numberIdx] + extra[numberIdx]) % 10;
                extra[numberIdx - 1] = (number1[numberIdx] + number2[numberIdx] + extra[numberIdx]) / 10;
            }
            sum[0] = extra[0];
            bool isNumber = false;
            foreach (int digit in sum) 
            {
            if (digit > 0)
                {
                    isNumber= true;
                    SumNumberTextBox.Text += digit;
                }
            else
                {
                    if (isNumber)
                    {
                        SumNumberTextBox.Text += digit;
                    }
                }
            }
        }
    }
}
