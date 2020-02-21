using System;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(Input1.Text, out var num1) ||
                !double.TryParse(Input2.Text, out var num2))
            {
                labelAnswer.Text = "Input not a valid number.";
                return;
            }

            switch (OperatorSelector.Text)
            {
                case "+":
                    labelAnswer.Text = $"{num1 + num2}";
                    break;
                case "-":
                    labelAnswer.Text = $"{num1 - num2}";
                    break;
                case "*":
                    labelAnswer.Text = $"{num1 * num2}";
                    break;
                case "/":
                    labelAnswer.Text = num2 == 0 ? "Can't divide by zero." : $"{num1 / num2}";
                    break;
                default:
                    labelAnswer.Text = "Operator not chosen.";
                    break;
            }
        }
    }
}