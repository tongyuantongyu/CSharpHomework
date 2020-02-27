using System;
using System.Windows.Forms;
using CalculateTools;

namespace GUICalc
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

            labelAnswer.Text = Calculator.Calc(num1, num2, OperatorSelector.Text, out var result, out var expression)
                ? $@"{result}"
                : expression;
        }
    }
}